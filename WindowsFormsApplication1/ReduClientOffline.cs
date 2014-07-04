/*
    Copyright 2013 Walter Ferreira de Lima Filho
    
    This file is part of ReduOffline.

    ReduOffline is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ReduOffline is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ReduOffline.  If not, see <http://www.gnu.org/licenses/>. 

*/
using ReduOffline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline
{
    /// <summary>
    /// ReduClientOffline represents the offline core of the application. 
    /// It communicates only with the database core to gather the offline stored previously and allow the user
    /// to still work on Redu.
    /// It hosts the logic for creating Pending Activities to postpone the sending of datas the server.
    /// </summary>
    public class ReduClientOffline
    {
        //Database connection auxiliar classes
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

        /// <summary>
        /// Loads offline user data from XML database
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public User get_user(string user_id)
        {
            User result = _xml_reader.read_user_data(user_id);
            return result;
        }

        /// <summary>
        /// Loads offline data of current user from XML database
        /// </summary>
        /// <returns></returns>
        public User get_me()
        {
            User result = _xml_reader.read_user_data(_current_user_login);            
            return result;
        }

        /// <summary>
        /// Gets enrollment from a certain user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Enrollment> get_enrollment_by_user(User user)
        {
            List<Enrollment> result = user.Enrollments;
            return result;
        }

        /// <summary>
        /// Gets user AVAs complete data according to their enrollments
        /// </summary>
        /// <param name="enrollments"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a Status answer for the specified status.
        /// Stores the answer offline as a pending activity.
        /// Adds the answer to its related Status in the current feed list.
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="user"></param>
        /// <param name="status_to_reply"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<Status> reply_status(List<Status> feed, User user, Status status_to_reply, string text)
        {
            Status answer = new Status();
            answer.Id = get_next_status_id().ToString();
            answer.Type = Constants.STATUS_ANSWER;
            answer.Text = text;
            answer.User = user;
            answer.Created_At = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00";
            answer.Links = new List<Link>();
            add_temp_status(answer, PendingActivity.TypePendingActivity.AnswerStatus, status_to_reply.Id, status_to_reply);
            Status to_update = feed.Find(x => x.Id.Equals(status_to_reply.Id));
            feed.Remove(to_update);
            to_update.Answers.Add(answer);
            feed.Insert(0, to_update);
            return feed;
        }

        /// <summary>
        /// Creates a new Status object in the user Timeline.
        /// Links the Status to a Pending Activity.
        /// Adds the Status to the current feed list.
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="user"></param>
        /// <param name="text"></param>
        /// <returns></returns>
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
            add_temp_status(status, PendingActivity.TypePendingActivity.SubmitStatusUser, user.Id.ToString(), null);
            feed.Insert(0, status);
            return feed;
        }

        /// <summary>
        /// Creates a new Status object in the specified Space Timeline.
        /// Links the Status to a Pending Activity.
        /// Adds the Status to the current feed list.
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="space"></param>
        /// <param name="user"></param>
        /// <param name="text"></param>
        /// <returns></returns>
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
            add_temp_status(status, PendingActivity.TypePendingActivity.SubmitStatusSpace, space.Id, null);
            feed.Insert(0, status);
            return feed;
        }

        /// <summary>
        /// Creates a new Status object in the specified Space Timeline.
        /// Links the Status to a Pending Activity.
        /// Adds the Status to the current feed list.
        /// </summary>
        /// <param name="feed"></param>
        /// <param name="user"></param>
        /// <param name="lecture_id"></param>
        /// <param name="text"></param>
        /// <param name="is_help">Whether the post is a help post or not</param>
        /// <returns></returns>
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
            add_temp_status(status, PendingActivity.TypePendingActivity.SubmitStatusLecture, lecture_id.Id, null);
            feed.Insert(0, status);
            return feed;
        }

        /// <summary>
        /// Creates a Pending Activity for the given Status.
        /// Calls the database to store the Pending Activity.
        /// </summary>
        /// <param name="temp_status"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="status_to_answer"></param>
        public void add_temp_status(Status temp_status, PendingActivity.TypePendingActivity type, string id, Status status_to_answer)
        {
            //create pending activity
            PendingActivity pa = new PendingActivity();
            pa.Id_User = temp_status.User.Id.ToString();
            pa.Date = temp_status.Created_At;
            pa.Wrapped_Status = temp_status;
            pa.Type_pending_activity = type;
            pa.Status_To_Answer = status_to_answer;
            switch (type)
            {
                case PendingActivity.TypePendingActivity.SubmitStatusUser:
                    _xml_writer.write_new_statuses(new List<Status> { temp_status }, string.Format(Constants.XML_USER_TIMELINE_PATH, _current_user_login));//save status with a negative ID to be able to erase it after
                    break;
                case PendingActivity.TypePendingActivity.SubmitStatusSpace:
                    pa.Space_Id = id;
                    _xml_writer.write_new_statuses(new List<Status> { temp_status }, string.Format(Constants.XML_SPACE_TIMELINE_PATH, _current_user_login));
                    break;
                case PendingActivity.TypePendingActivity.SubmitStatusLecture:
                    pa.Lecture_Id = id;
                    _xml_writer.write_new_statuses(new List<Status> { temp_status }, string.Format(Constants.XML_LECTURE_TIMELINE_PATH, _current_user_login));
                    break;
                case PendingActivity.TypePendingActivity.AnswerStatus:
                    pa.Status_Id = id;
                    //_xml_writer.write_new_statuses(new List<Status> { temp_status }, string.Format(Constants.XML_USER_TIMELINE_PATH, _current_user_login));
                    break;
            }
            
            _xml_writer.save_pending_activity(new List<PendingActivity> { pa });//save pending activity for later synchronization
        }

        /// <summary>
        /// Reads all the feed for the specified user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Auxiliar function to help build a consistent ID system.
        /// Gets the next ID stored in XMLs.
        /// </summary>
        /// <returns></returns>
        private int get_next_status_id()
        {
            int temp = _xml_reader.read_pending_activities_max_id();
            temp--;
            _xml_writer.save_pending_activities_max_id(temp); //TODO: just read and save when openning and closing the program
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
