using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduOffline.API_Functions;
using ReduOffline.Models;
using RestSharp;
using System.IO;

namespace ReduOffline
{
    public class ReduClientOnline : UserFunctions
    {
        
        private HttpRequests _http = new HttpRequests();
        private ReduOAuth _reduOAuth;
        private XMLWriter _xml_writer = new XMLWriter();
       

        public ReduClientOnline(ReduOAuth reduOAuth)
        {
            _reduOAuth = reduOAuth;
        }

        public User get_user(string user_id)
        {
            User result = _http.get<User>(Constants.USER_URL + user_id, _reduOAuth.get_access_token());
            return result;
        }

        public User get_me()
        {
            User result = _http.get<User>("me", _reduOAuth.get_access_token());
            return result;            
        }

        public List<Enrollment> get_enrollment_by_user(string url)
        {
            List<Enrollment> result = _http.get<List<Enrollment>>(url, _reduOAuth.get_access_token());
            return result;
        }

        public List<EnvironmentRedu> get_environment_by_user(List<Enrollment> enrollments)
        {
            List<EnvironmentRedu> avas = new List<EnvironmentRedu>();
            foreach(Enrollment enroll in enrollments)
            {
                EnvironmentRedu ava = _http.get<EnvironmentRedu>
                    (trim_base_url(enroll.Links.First(p => p.Rel.Equals(Constants.REL_ENVIRONMENT)).Href), _reduOAuth.get_access_token());
                avas.Add(ava);
            }
            return avas;

        }

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
                            foreach (Subject subject in space.Subjects)
                            {
                                subject.Lectures = _http.get<List<Lecture>>(trim_base_url(subject.Links.First(p => p.Rel.Equals(Constants.REL_LECTURE)).Href), _reduOAuth.get_access_token());
                                foreach (Lecture lecture in subject.Lectures)
                                {
                                    string url_status = "lectures/{0}/statuses";
                                    lecture.Timeline = _http.get<List<Status>>(String.Format(url_status, lecture.Id), _reduOAuth.get_access_token());
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

        private void get_user_thumbnails(User user)
        {
            Directory.CreateDirectory(String.Format(Constants.XML_USER_THUMBNAIL_FOLDER, user.Login));
            foreach (Thumbnail thumbnail in user.Thumbnails)
            {
                _http.download_file(thumbnail.Href, String.Format(Constants.XML_USER_THUMBNAIL_FOLDER, user.Login));
            }
        }

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
            return feed;
        }

        public void get_user_first_data()
        {
            User user = this.get_me();
            get_user_thumbnails(user);

            String enrollement_url = this.trim_base_url(user.Links.First(p => p.Rel.Equals(Constants.REL_ENROLLMENTS)).Href);
            List<Enrollment> enrollments = this.get_enrollment_by_user(enrollement_url);
            user.Enrollments = enrollments;
            List<Link> courses_enrolled = new List<Link>();
            foreach (Enrollment enroll in enrollments)
            {
                courses_enrolled.Add(enroll.Links.Find(p => p.Rel.Equals(Constants.REL_COURSE)));
            }

            String feed_url = String.Format(Constants.URL_FEED_USER, user.Id);
            List<Status> feed = this.get_user_feed(feed_url);          

            List<EnvironmentRedu> avas = this.get_environment_by_user(enrollments);
            //if(avas.Exists) -> tentar apenas atualizar
                                    
            avas = this.fill_up_avas_data(avas, courses_enrolled);

            _xml_writer.save_user_data(user, feed);
            foreach (EnvironmentRedu ava in avas)
            {
                _xml_writer.save_ava_data(ava);
            }
            //salvar as informações, cada coisa como um xml de acordo com a seguinte hierarquia:
            //usuario.xml -> guarda link para usuario_ava.xml && usuario_feed.xml
            //usuario_ava.xml -> ambientes do usuário : guarda link para ava.xml
            //ava.xml -> ambiente : guarda link para ava_courses.xml
            //ava_courses.xml -> cursos de uma ava : guarda link para ava_course_spaces.xml
            //ava_course_spaces -> spaces de um curso : guarda link para ava_course_spaces_timeline.xml && ava_course_space_sujects.xml
            //ava_course_space_sujects -> módulos de um curso : guarda link para ava_course_space_suject_lectures.xml
            //ava_course_space_suject_lectures -> aula : guarda os links para o conteúdo baixado.

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
    }
}
