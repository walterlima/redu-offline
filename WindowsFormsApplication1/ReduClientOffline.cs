using ReduOffline.API_Functions;
using ReduOffline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline
{
    public class ReduClientOffline : UserFunctions
    {
        private XMLReader _xml_reader;
        private XMLWriter _xml_writer;
        private string _current_user_login;
        private List<EnvironmentRedu> _current_user_avas = new List<EnvironmentRedu>();
        private List<Space> _current_user_spaces = new List<Space>();
        private List<Lecture> _current_user_lectures = new List<Lecture>();

        public ReduClientOffline(XMLWriter xml_writer, XMLReader xml_reader)
        {
            this._xml_writer = xml_writer;
            this._xml_reader = xml_reader;
        }

        public User get_user(string user_id)
        {
            User result = _xml_reader.read_user_data(user_id);
            return result;
        }

        public User get_me()
        {
            User result = _xml_reader.read_user_data(_current_user_login);            
            return result;
        }

        public List<Enrollment> get_enrollment_by_user(User user)
        {
            List<Enrollment> result = user.Enrollments;
            return result;
        }

        public List<EnvironmentRedu> get_environment_by_user(List<Enrollment> enrollments)
        {
            List<EnvironmentRedu> avas = new List<EnvironmentRedu>();
            foreach (Enrollment enroll in enrollments)
            {
                Tuple<EnvironmentRedu,List<Space>,List<Lecture>> result = _xml_reader.read_ava_data(enroll.Ava_Name);
                EnvironmentRedu ava = result.Item1;
                List<Space> spaces = result.Item2;
                List<Lecture> lectures = result.Item3;
                avas.Add(ava);
                _current_user_avas.Add(ava);
                _current_user_spaces.AddRange(spaces);
                _current_user_lectures.AddRange(lectures);
            }
            return avas;

        }

        public List<Status> reply_status(List<Status> feed, User user, Status status_to_reply, string text)
        {
            Status answer = new Status();
            answer.Id = get_next_status_id().ToString();
            answer.Type = Constants.STATUS_ANSWER;
            answer.Text = text;
            answer.User = user;
            answer.Created_At = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00";
            answer.Links = new List<Link>();
            add_temp_status(answer, PendingActivity.TypePendingActivity.AnswerStatus);
            return feed;
        }

        public List<Status> post_status_user(List<Status> feed, User user, string text)
        {
            Status status = new Status();
            status.Id = get_next_status_id().ToString();
            status.User = user;
            status.Type = Constants.STATUS_ACTIVITY;
            status.Text = text;
            status.Created_At = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")+"-03:00";
            status.Links = new List<Link>();            
            Link statusable = new Link(Constants.REL_STATUSABLE, "users");
            status.Links.Add(statusable);
            add_temp_status(status, PendingActivity.TypePendingActivity.SubmitStatusUser);
            feed.Insert(0, status);
            return feed;
        }

        public List<Status> post_status_space(List<Status> feed, Space space, User user, string text)
        {
            Status status = new Status();
            status.Id = get_next_status_id().ToString();
            status.User = user;
            status.Type = Constants.STATUS_ACTIVITY;
            status.Text = text;
            status.Created_At = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00";
            status.Links = new List<Link>();
            Link statusable = new Link(Constants.REL_STATUSABLE, "spaces");            
            status.Links.Add(statusable);
            add_temp_status(status, PendingActivity.TypePendingActivity.SubmitStatusSpace);
            feed.Insert(0, status);
            return feed;
        }

        public List<Status> post_status_lecture(List<Status> feed, User user, Lecture lecture_id, string text, bool is_help)
        {
            Status status = new Status();
            status.Id = get_next_status_id().ToString();
            status.User = user;
            status.Type = is_help ? Constants.STATUS_HELP : Constants.STATUS_ACTIVITY;
            status.Text = text;
            status.Created_At = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00";
            status.Links = new List<Link>();
            Link statusable = new Link(Constants.REL_STATUSABLE, "lectures");
            status.Links.Add(statusable);            
            add_temp_status(status, PendingActivity.TypePendingActivity.SubmitStatusLecture);
            feed.Insert(0, status);
            return feed;
        }

        public void add_temp_status(Status temp_status, PendingActivity.TypePendingActivity type)
        {
            //create pending activity
            PendingActivity pa = new PendingActivity();
            pa.Date = temp_status.Created_At;
            pa.Id_User = temp_status.User.Id.ToString();
            pa.Status_Id = temp_status.Id.ToString();
            pa.Wrapped_Status = temp_status;
            pa.Type_pending_activity = type;
            _xml_writer.write_new_statuses(new List<Status> { temp_status }, string.Format(Constants.XML_USER_TIMELINE_PATH, _current_user_login));//save status with a negative ID to be able to erase it after
            _xml_writer.save_pending_activity(new List<PendingActivity> { pa });//save pending activity for later synchronization
        }

        public List<Status> get_user_feed(string login)
        {
            List<Status> feed = _xml_reader.read_feed_data(login);
            foreach (Status status in feed)
            {
                if (status.Post_Local.Equals(Constants.STATUS_LECTURE))
                {
                    Lecture lecture = _current_user_lectures.Find(l => l.Id.Equals(status.Statusable_Id));
                    status.Link_Tree = lecture.Link_Tree;
                    status.Link_Source = lecture.Name;
                }
                else if (status.Post_Local.Equals(Constants.STATUS_SPACE))
                {
                    Space space = _current_user_spaces.Find(s => s.Id.Equals(status.Statusable_Id));
                    status.Link_Tree = space.Link_Tree;
                    status.Link_Source = space.Name;
                }
            }
            return feed;
        }

        public List<User> getUsersBySpace(string space_id, string role)
        {
            throw new NotImplementedException();
        }

        private int get_next_status_id()
        {
            int temp = ReduOffline.Properties.Settings.Default.PENDING_STATUS_ID;
            temp--;
            ReduOffline.Properties.Settings.Default.PENDING_STATUS_ID = temp;
            return temp;
        }

        public void set_current_user_login(string login)
        {
            this._current_user_login = login;
        }

        public List<EnvironmentRedu> Current_User_Avas
        {
            get { return _current_user_avas; }
            set { _current_user_avas = value; }
        }

        public List<Space> Current_User_Spaces
        {
            get { return _current_user_spaces; }
            set { _current_user_spaces = value; }
        }

        public List<Lecture> Current_User_Lectures
        {
            get { return _current_user_lectures; }
            set { _current_user_lectures = value; }
        }
    }
}
