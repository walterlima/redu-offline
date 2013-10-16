using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduOffline.API_Functions;
using ReduOffline.Models;
using RestSharp;
using System.IO;
using System.ComponentModel;

namespace ReduOffline
{
    public class ReduClientOnline : UserFunctions
    {
        
        private HttpRequests _http = new HttpRequests();
        private ReduOAuth _reduOAuth;
        private XMLWriter _xml_writer;
        private XMLReader _xml_reader;

        private User _current_user;
        private List<EnvironmentRedu> _current_user_avas;
        private List<Status> _feed;
        private List<Enrollment> _current_user_enrollments;

        private System.ComponentModel.BackgroundWorker bw_download_thumb_user;

        public ReduClientOnline(ReduOAuth reduOAuth, XMLWriter xml_writer, XMLReader xml_reader)
        {
            this._xml_writer = xml_writer;
            this._xml_reader = xml_reader;
            _reduOAuth = reduOAuth;
            this.bw_download_thumb_user = new System.ComponentModel.BackgroundWorker();
            this.bw_download_thumb_user.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_download_thumb_user_DoWork);
            this.bw_download_thumb_user.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_download_thumb_user_RunWorkerCompleted);
        }

        public User get_user(string user_id)
        {
            User result = _http.get<User>(Constants.USER_URL + user_id, _reduOAuth.get_access_token());
            return result;
        }

        /// <summary>
        /// Downloads data from the current user
        /// </summary>
        /// <returns>User's profile data</returns>
        public User get_me()
        {
            User result = _http.get<User>("me", _reduOAuth.get_access_token());
            return result;            
        }

        /// <summary>
        /// Downloads the current user's enrollments
        /// </summary>
        /// <param name="url">Enrollment url</param>
        /// <returns>List of current user's enrollments</returns>
        public List<Enrollment> get_enrollment_by_user(string url)
        {
            List<Enrollment> result = _http.get<List<Enrollment>>(url, _reduOAuth.get_access_token());
            return result;
        }

        /// <summary>
        /// Downloads the current user's Avas according to the user's enrollments
        /// </summary>
        /// <param name="enrollments">User's enrollments</param>
        /// <returns>List of Avas</returns>
        public List<EnvironmentRedu> get_environment_by_user(List<Enrollment> enrollments)
        {
            List<EnvironmentRedu> avas = new List<EnvironmentRedu>();
            foreach(Enrollment enroll in enrollments)
            {
                if (!enroll.State.Equals("waiting"))
                {
                    EnvironmentRedu ava = _http.get<EnvironmentRedu>
                        (trim_base_url(enroll.Links.First(p => p.Rel.Equals(Constants.REL_ENVIRONMENT)).Href), _reduOAuth.get_access_token());
                    avas.Add(ava);
                    enroll.Ava_Name = ava.Initials;
                }
            }
            return avas;

        }

        /// <summary>
        /// Download from the Internet: Ava, Course, Space and Lecture Data
        /// </summary>
        /// <param name="avas">Avas that contain the courses in which the current user is enrolled</param>
        /// <param name="enrolled_courses">Courses in which the current user is enrolled</param>
        /// <returns>Ava filled with the data</returns>
        public List<EnvironmentRedu> fill_up_avas_data(List<EnvironmentRedu> avas, List<Link> enrolled_courses)
        {
            foreach (EnvironmentRedu ava in avas)
            {
                if (this.exists_local_ava_data(ava))
                {
                    this.get_ava_thumbnail(ava);
                    ava.Courses = _http.get<List<Course>>(trim_base_url(ava.Links.First(p => p.Rel.Equals(Constants.REL_COURSES)).Href), _reduOAuth.get_access_token());
                    ava.Courses = validate_enrolled_courses(ava.Courses, enrolled_courses);
                    
                    foreach (Course course in ava.Courses)
                    {                        
                        course.Spaces = _http.get<List<Space>>(trim_base_url(course.Links.First(p => p.Rel.Equals(Constants.REL_SPACE)).Href), _reduOAuth.get_access_token());
                        foreach (Space space in course.Spaces)
                        {
                            space.Subjects = _http.get<List<Subject>>(trim_base_url(space.Links.First(p => p.Rel.Equals(Constants.REL_SUBJECT)).Href), _reduOAuth.get_access_token());
                            space.Timeline = _http.get<List<Status>>(trim_base_url(space.Links.First(p => p.Rel.Equals(Constants.REL_TIMELINE)).Href), _reduOAuth.get_access_token());
                            if (space.Timeline != null)
                            {
                                space.Timeline = this.get_statuses_answers(space.Timeline);
                            }
                            space.Name_Course = course.Name;
                            space.Name_Ava = ava.Name;
                            foreach (Subject subject in space.Subjects)
                            {
                                subject.Lectures = _http.get<List<Lecture>>(trim_base_url(subject.Links.First(p => p.Rel.Equals(Constants.REL_LECTURE)).Href), _reduOAuth.get_access_token());
                                foreach (Lecture lecture in subject.Lectures)
                                {
                                    string url_status = "lectures/{0}/statuses";
                                    lecture.Timeline = _http.get<List<Status>>(String.Format(url_status, lecture.Id), _reduOAuth.get_access_token());
                                    if (lecture.Timeline != null)
                                    {
                                        lecture.Timeline = this.get_statuses_answers(lecture.Timeline);
                                    }
                                    lecture.Name_Ava = ava.Name;
                                    lecture.Name_Course = course.Name;
                                    lecture.Name_Space = space.Name;
                                    lecture.Name_Subject = subject.Name;
                                }
                            }
                        }
                    }
                }
            }
            return avas;
        }

        /// <summary>
        /// Check if the downloaded courses from the ava correspond to the list of courses in which the user is enrolled.
        /// Eliminate the courses that don't match the list to avoid permission problems.
        /// </summary>
        /// <param name="ava_courses">Courses downloaded from AVA</param>
        /// <param name="enrolled_courses">Links of enrolled courses</param>
        /// <returns>List of valid courses</returns>
        private List<Course> validate_enrolled_courses(List<Course> ava_courses, List<Link> enrolled_courses)
        {
            List<Course> new_list = new List<Course>();
            for (int i = 0; i < enrolled_courses.Count; i++)
            {
                Course course = ava_courses.Find(p => p.Links.Find(q => q.Rel.Equals(Constants.REL_SELF)).Href.Equals(enrolled_courses[i].Href));
                new_list.Add(course);
            }
            return new_list;
        }

        /// <summary>
        /// Downloads async user's thumbnails
        /// </summary>
        /// <param name="user">Current user</param>
        private void get_user_thumbnails(User user)
        {
            Directory.CreateDirectory(String.Format(Constants.XML_USER_THUMBNAIL_FOLDER, user.Login));
            foreach (Thumbnail thumbnail in user.Thumbnails)
            {
                _http.download_file(thumbnail.Href, String.Format(Constants.XML_USER_THUMBNAIL_FOLDER, user.Login, user.Login+thumbnail.Size));
            }
            //if (bw_download_thumb_user.IsBusy != true)
            //{
            //    bw_download_thumb_user.RunWorkerAsync();
            //}
        }

        private void bw_download_thumb_user_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((bw_download_thumb_user.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                User user = e.Argument as User;
                Directory.CreateDirectory(String.Format(Constants.XML_USER_THUMBNAIL_FOLDER, user.Login));
                foreach (Thumbnail thumbnail in user.Thumbnails)
                {
                    _http.download_file(thumbnail.Href, String.Format(Constants.XML_USER_THUMBNAIL_FOLDER, user.Login));
                }    
            }
        }

        private void bw_download_thumb_user_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true)) { }

            else if (!(e.Error == null)) { }

            else
            {

            }
        }

        /// <summary>
        /// Downloads async ava's thumbnails
        /// </summary>
        /// <param name="ava">Ava</param>
        private void get_ava_thumbnail(EnvironmentRedu ava)
        {
            Directory.CreateDirectory(String.Format(Constants.XML_AVA_THUMBNAIL_FOLDER, ava.Initials));
            foreach (Thumbnail thumbnail in ava.Thumbnails)
            {
                _http.download_file(thumbnail.Href, String.Format(Constants.XML_AVA_THUMBNAIL_FOLDER, ava.Initials));
            }
        }

        public List<Status> get_user_feed(string url)
        {
            //não é muito interessante o feed LOG
            List<Status> feed = _http.get<List<Status>>(url, _reduOAuth.get_access_token());
            feed = this.get_statuses_answers(feed);
            return feed;
        }

        /// <summary>
        /// Tries to retrieve the new feeds after the last one locally saved
        /// </summary>
        /// <param name="url">Url to the users timeline</param>
        /// <param name="id_last_status">Date from the last feed locally saved</param>
        /// <returns></returns>
        public List<Status> update_user_feed(string url, string id_last_status)
        {
            List<Status> feed_total = new List<Status>();
            List<Status> feed;
            bool has_found;
            int list_position;
            int page_list = 1;
            string url_update_feed = "";
            do
            {
                url_update_feed = string.Format(url, page_list);//considering {0} has already been marked
                feed = _http.get<List<Status>>(url_update_feed, _reduOAuth.get_access_token());//downloads the next page
                list_position = feed.FindIndex(p => p.Id.Equals(id_last_status));//checks if the last feed is included
                has_found = list_position >= 0;//if it's there, we found the page where the last feed is
                page_list++;
                if(has_found)
                {
                    feed.RemoveRange(list_position, feed.Count - list_position);//remove the duplicate
                }
                feed_total.AddRange(feed);//add the new feeds to the range
            }
            while (!has_found);
            return feed_total;
        }

        public List<Status> get_statuses_answers(List<Status> statuses)
        {
            foreach (Status status in statuses)
            {
                if (status.Answers_Count > 0)
                {
                    status.Answers = _http.get<List<Status>>(trim_base_url(status.Links.Find(p => p.Rel.Equals(Constants.LINK_ANSWERS)).Href), _reduOAuth.get_access_token());                    
                }
            }

            return statuses;
        }

        /// <summary>
        /// Tries to retrieve the old feeds after the oldest one locally saved
        /// </summary>
        /// <param name="url">Url to the users timeline</param>
        /// <param name="id_last_status">Id from the oldest feed locally saved</param>
        /// <returns></returns>
        public List<Status> update_old_user_feed(string url, string id_oldest_status)
        {
            List<Status> feed_total = new List<Status>();
            List<Status> feed;
            bool has_found;
            int list_position;
            int page_list = 1;
            string url_update_feed = "";
            do
            {
                url_update_feed = string.Format(url, page_list);//considering {0} has already been marked
                feed = _http.get<List<Status>>(url_update_feed, _reduOAuth.get_access_token());//downloads the next page
                list_position = feed.FindIndex(p => p.Id.Equals(id_oldest_status));//checks if the last feed is included
                has_found = list_position >= 0;//if it's there, we found the page where the last feed is                                
                page_list++;
            }
            while (!has_found);

            if (has_found)
            {
                feed.RemoveRange(0, list_position + 1);//remove the duplicate
            }
            feed_total.AddRange(feed);//add the new (old) feeds to the range
            url_update_feed = string.Format(url, page_list);//considering {0} has already been marked
            feed = _http.get<List<Status>>(url_update_feed, _reduOAuth.get_access_token());//downloads the next page of old feeds
            feed_total.AddRange(feed);//add the new page to the range

            return feed_total;
        }

        /// <summary>
        /// Replies to a specific status via a POST request and adds the new Status to the user feed list
        /// </summary>
        /// <param name="feed">User initial feed</param>
        /// <param name="status_id">Status to reply</param>
        /// <param name="text">Text</param>
        /// <returns>Updated user feed</returns>
        public List<Status> reply_status(List<Status> feed, string status_id, string text)
        {
            string url = string.Format(Constants.POST_STATUS_ANSWER_URL, status_id);
            Dictionary<string, object> paramz = new Dictionary<string, object>();
            String json_model = "[ \"status_id\" : \"{0}\" , \"status\" : [ \"text\" : \"{1}\" ] ]";
            String json = string.Format(json_model, status_id, text);
            json = json.Replace('[', '{');
            json = json.Replace(']', '}');
            Status status = _http.post<Status>(url, _reduOAuth.get_access_token(), null, json);
            feed.Insert(0, status);
            return feed;
        }

        /// <summary>
        /// Posts on the user's own wall and adds the new Status to the user feed list
        /// </summary>
        /// <param name="feed">User inital feed</param>
        /// <param name="user_id">User id</param>
        /// <param name="text">Text</param>
        /// <returns>Updated user feed</returns>
        public List<Status> post_status_user(List<Status> feed, string user_id, string text)
        {
            string url = string.Format(Constants.POST_USER_FEED_URL, user_id);
            Dictionary<string, object> paramz = new Dictionary<string, object>();            
            String json_model = "[ \"user_id\" : \"{0}\" , \"status\" : [ \"text\" : \"{1}\" ] ]"; //temporary
            String json = string.Format(json_model, user_id, text);
            json = json.Replace('[', '{');
            json = json.Replace(']', '}');           
            Status status = _http.post<Status>(url, _reduOAuth.get_access_token(), null, json);
            feed.Insert(0, status);
            this._xml_writer.write_new_statuses(new List<Status>{status}, string.Format(Constants.XML_USER_TIMELINE_PATH, _current_user.Login));
            return feed;
        }

        /// <summary>
        /// Posts on the specified space's wall and adds the new Status to the space status list
        /// </summary>
        /// <param name="feed">Space inital feed</param>
        /// <param name="space_id">Space id</param>
        /// <param name="text">Text</param>
        /// <returns>Updated space feed</returns>
        public List<Status> post_status_space(List<Status> feed, string space_id, string text)
        {
            string url = string.Format(Constants.POST_SPACE_FEED_URL, space_id);
            Dictionary<string, object> paramz = new Dictionary<string, object>();
            String json_model = "[ \"spacer_id\" : \"{0}\" , \"status\" : [ \"text\" : \"{1}\" ] ]";
            String json = string.Format(json_model, space_id, text);
            json = json.Replace('[', '{');
            json = json.Replace(']', '}');
            Status status = _http.post<Status>(url, _reduOAuth.get_access_token(), null, json);
            feed.Insert(0, status);
            return feed;
        }

        /// <summary>
        /// Posts on the specified lecture's wall and adds the new Status to the lecture feed list
        /// The post may be an Activity or Help
        /// </summary>
        /// <param name="feed">Lecture initial feed</param>
        /// <param name="lecture_id">Lecture id</param>
        /// <param name="text">Text</param>
        /// <param name="is_help">True if the Post is a Help</param>
        /// <returns>Updated lecture feed</returns>
        public List<Status> post_status_lecture(List<Status> feed, string lecture_id, string text, bool is_help)
        {
            string url = string.Format(Constants.POST_LECTURE_FEED_URL, lecture_id);
            Dictionary<string, object> paramz = new Dictionary<string, object>();
            String json_model = "[ \"lecture_id\" : \"{0}\" , \"status\" : [ \"text\" : \"{1}\", \"type\" : \"{2}\" ] ] ";
            String json = string.Format(json_model, lecture_id, text, is_help ? "Help" : "Activity");
            json = json.Replace('[', '{');
            json = json.Replace(']', '}');
            Status status = _http.post<Status>(url, _reduOAuth.get_access_token(), null, json);
            feed.Insert(0, status);
            return feed;
        }

        public void synchronize_pending_activities()
        {
            //read pending activities for current user -- for the first moment we will just upload the activities for a logged in user

            //realize each task described by each activity saving the informations within their respective xml files

            //erase the statuses with minus IDs

            //set pending activity as synchronized (timestamp + bool)
        }

        public void get_user_first_data()
        {
            User user = this.get_me();
            get_user_thumbnails(user);
            Current_User = user;

            String enrollement_url = this.trim_base_url(user.Links.First(p => p.Rel.Equals(Constants.REL_ENROLLMENTS)).Href);
            List<Enrollment> enrollments = this.get_enrollment_by_user(enrollement_url);            
            user.Enrollments = (from enroll in enrollments where !enroll.State.Equals("waiting") select enroll).ToList();
            

            Current_User_Enrollments = user.Enrollments;

            List<Link> courses_enrolled = new List<Link>();
            foreach (Enrollment enroll in user.Enrollments)
            {
                courses_enrolled.Add(enroll.Links.Find(p => p.Rel.Equals(Constants.REL_COURSE)));
            }

            String feed_url = String.Format(Constants.URL_FEED_USER, user.Id);
            List<Status> feed = this.get_user_feed(feed_url);

            Feed = feed;

            List<EnvironmentRedu> avas = this.get_environment_by_user(user.Enrollments);
            //if(avas.Exists) -> tentar apenas atualizar
                                    
            avas = this.fill_up_avas_data(avas, courses_enrolled);

            Current_User_Avas = avas;

            _xml_writer.save_user_data(user, feed);
            foreach (EnvironmentRedu ava in avas)
            {
                _xml_writer.save_ava_data(ava);
            }
        }

        public List<User> getUsersBySpace(string space_id, string role)
        {
            throw new NotImplementedException();
        }

        private string trim_base_url(string url)
        {
            return url.Substring(Constants.BASE_URL.Length);
        }

        private bool exists_local_ava_data(EnvironmentRedu ava)
        {
            return true;//File.Exists(string.Format(Constants.XML_AVA_PATH, ava.Initials));
        }

        public User Current_User
        {
            get { return _current_user; }
            set { _current_user = value; }
        }

        public List<EnvironmentRedu> Current_User_Avas
        {
            get { return _current_user_avas; }
            set { _current_user_avas = value; }
        }

        public List<Status> Feed
        {
            get { return _feed; }
            set { _feed = value; }
        }

        public List<Enrollment> Current_User_Enrollments
        {
            get { return _current_user_enrollments; }
            set { _current_user_enrollments = value; }
        }
    }
}
