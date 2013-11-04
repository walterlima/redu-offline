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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline
{
    public class Redu
    {
        private ReduClientOffline _redu_offline;
        private ReduClientOnline _redu_online;
        private ReduOAuth _redu_oauth;
        private User _current_user;
        private List<EnvironmentRedu> _current_user_avas;
        private List<Course> _current_user_courses = new List<Course>();
        private List<Space> _current_user_spaces = new List<Space>();
        private List<Subject> _current_user_subjects = new List<Subject>();
        private List<Lecture> _current_user_lectures = new List<Lecture>();
        private List<Status> _feed;
        private List<Enrollment> _current_user_enrollments;
        private List<Status> _current_lecture_feed;        
        private List<Status> _current_space_feed;        
        private bool _is_first_login = true;
        private string _current_login = "";
        private string _last_seen_lecture;
        private string _last_seen_space;        

        public Redu()
        {
            XMLReader xml_reader = new XMLReader();
            XMLWriter xml_writer = new XMLWriter();
            _redu_oauth = new ReduOAuth();
            _redu_offline = new ReduClientOffline(xml_writer, xml_reader);
            _redu_online = new ReduClientOnline(_redu_oauth, xml_writer, xml_reader);
        }

        /// <summary>
        /// If the user has already logged in before in the current machine and there is a internet connection available,
        /// it loads the information already hosted and tries to update the data. If there is no connection it just loads the offline data.
        /// If the user has not logged in before, it tries to do the oauth process.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>1 if the login was possible, 0 if the oauth was demanded and -1 if there was no connection available</returns>
        public int login_procedure(string login)
        {
            bool is_client_connected = is_connected();
            _current_login = login;
            bool already_authorized = _redu_oauth.has_user_authorized(login);
            if (already_authorized)
            {
                _is_first_login = false;
                return 1;
            }
            else
            {
                if (is_client_connected)
                {
                    _redu_oauth.demand_authorize(login);
                }
                else
                {
                    //pede para tentar mais tarde
                    return -1;
                }
                return 0;
            }
            
        }

        /// <summary>
        /// Calls procedure to validate the pin for the OAuth Login authorization
        /// </summary>
        /// <param name="pin">Pin</param>
        /// <returns>True if it was successful, False if not</returns>
        public bool enter_authorization_pin(String pin)
        {
            bool sucess = _redu_oauth.enter_authorization_pin(pin);
            return sucess;
        }

        /// <summary>
        /// Loads the user data according to the following rules:
        /// If it is the first login or the user doesn't have data on the machine, download it from the server
        /// Otherwise load stored data from the local machine
        /// </summary>
        public void load_data()
        {
            if (_is_first_login)
            {
                this.download_data_online();
                load_offline_data();
            }
            else
            {
                if (!_redu_oauth.user_has_data(_current_login))
                {
                    this.download_data_online();                    
                }
                load_offline_data();
                //TODO: try to update local data
            }
        }

        /// <summary>
        /// Calls load procedures to read the user's data stored in xml files
        /// </summary>
        private void load_offline_data()
        {
            _redu_offline.set_current_user_login(_current_login);
            _current_user = _redu_offline.get_me();
            _current_user_enrollments = _redu_offline.get_enrollment_by_user(_current_user);
            _current_user_avas = _redu_offline.get_environment_by_user(_current_user_enrollments);
            _current_user_avas.ForEach(ava => _current_user_courses.AddRange(ava.Courses));
            _current_user_courses.ForEach(course => _current_user_spaces.AddRange(course.Spaces));
            _current_user_spaces.ForEach(space => _current_user_subjects.AddRange(space.Subjects));
            _current_user_subjects.ForEach(subject => _current_user_lectures.AddRange(subject.Lectures));
            _feed = _redu_offline.get_user_feed(_current_user.Login);
            //pass info through
            _redu_online.Current_User = _current_user;
            _redu_online.Current_User_Avas = _current_user_avas;
            _redu_online.Current_User_Enrollments = _current_user_enrollments;
            _redu_online.Feed = _feed;
        }

        /// <summary>
        /// Calls procedures to download user's data from the online servers
        /// </summary>
        private void download_data_online()
        {
            if (is_connected())
            {
                _redu_online.get_user_first_data();
                _current_user = _redu_online.Current_User;
                _feed = _redu_online.Feed;
                _current_user_enrollments = _redu_online.Current_User_Enrollments;
                _current_user_avas = _redu_online.Current_User_Avas;
                //pass info thruough
                
            }
            else { }
        }

        /// <summary>
        /// If there is a connection, tries to reply the status online by calling the ReduOnline handler.
        /// Else stores the reply locally and create a pending activity for future synchronization
        /// </summary>
        /// <param name="user">User who is replying</param>
        /// <param name="status_to_reply">Status to be replied</param>
        /// <param name="text">Answer text</param>
        /// <param name="feed">List of previous statuses showing on the GUI</param>
        /// <returns>Updated Feed</returns>
        public List<Status> reply_status(User user, Status status_to_reply, string text, List<Status> feed)
        {
            feed = is_connected() ? _redu_online.reply_status(feed, status_to_reply, text) : _redu_offline.reply_status(feed, user, status_to_reply, text);
            return feed;
        }

        /// <summary>
        /// If there is a connection, tries to post the user status online by calling the ReduOnline handler.
        /// Else stores the status locally and create a pending activity for future synchronization
        /// </summary>
        /// <param name="text">Post text</param>
        public void post_status_user(string text)
        {
            _feed = is_connected() ? _redu_online.post_status_user(_feed, _current_user.Id + "", text) : _redu_offline.post_status_user(_feed, _current_user, text);
        }

        /// <summary>
        /// If there is a connection, tries to post the status online by calling the ReduOnline handler.
        /// Else stores the status locally and create a pending activity for future synchronization
        /// </summary>
        /// <param name="space_id">Id of the space where the post was made</param>
        /// <param name="user">User who posted the status</param>
        /// <param name="text">Status text</param>
        public void post_status_space(String space_id, User user, string text)
        {
            _feed = is_connected() ? _redu_online.post_status_space(_feed, space_id, text) : _redu_offline.post_status_space(_feed, _current_user_spaces.Find(x => x.Id.Equals(space_id)), user, text);
        }

        /// <summary>
        /// If there is a connection, tries to post the status online by calling the ReduOnline handler.
        /// Else stores the status locally and create a pending activity for future synchronization
        /// </summary>
        /// <param name="user">User who posted the status</param>
        /// <param name="lecture_id">Id of the lecture where the post was made</param>
        /// <param name="text">Status text</param>
        /// <param name="is_help">True if it is a help status, False if not</param>
        public void post_status_lecture(User user, String lecture_id, string text, bool is_help)
        {
            _feed = is_connected() ? _redu_online.post_status_lecture(_feed, lecture_id, text, is_help) : _redu_offline.post_status_lecture(_feed, user, _current_user_lectures.Find(x => x.Id.Equals(lecture_id)), text, is_help);
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        /// <summary>
        /// Method for testing if theres an available internet connection
        /// </summary>
        /// <returns>True if it is connected, False if it is not</returns>
        private bool is_connected()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        /// <summary>
        /// Calls the synchronization process
        /// </summary>
        public void synchronize_pending_activities()
        {
            _feed = _redu_online.synchronize_pending_activities(_feed);
        }

        /// <summary>
        /// Searches for the feed of a particular Lecture among the user's lectures
        /// </summary>
        /// <param name="lecture_id">Lecture Id</param>
        /// <returns>Lecture's feed</returns>
        public List<Status> find_lecture_feed(String lecture_id)
        {
            _last_seen_lecture = lecture_id;
            Lecture lecture = _current_user_lectures.Find(x => x.Id.Equals(lecture_id));
            return lecture.Timeline;
        }

        /// <summary>
        /// Searches for the feed of a particular Space among the user's spaces
        /// </summary>
        /// <param name="space_id">Space Id</param>
        /// <returns>Space's Feed</returns>
        public List<Status> find_space_feed(String space_id)
        {
            _last_seen_space = space_id;
            Space space = _current_user_spaces.Find(x => x.Id.Equals(space_id));
            return space.Timeline;
        }

        /// <summary>
        /// User logged in at the moment
        /// </summary>
        public User Current_user
        {
            get { return _current_user; }
            set { _current_user = value; }
        }

        /// <summary>
        /// Feed of the current logged in user
        /// </summary>
        public List<Status> Feed
        {
            get { return _feed; }
            set { _feed = value; }
        }

        /// <summary>
        /// Avas in which the current logged in user is enrolled
        /// </summary>
        public List<EnvironmentRedu> Current_User_Avas
        {
            get { return _current_user_avas; }
            set { _current_user_avas = value; }
        }

        /// <summary>
        /// Lectures of the current logged in user
        /// </summary>
        public List<Status> Current_Lecture_Feed
        {
            get { return _current_lecture_feed; }
            set { _current_lecture_feed = value; }
        }
        
        /// <summary>
        /// Spaces of the current logged in user
        /// </summary>
        public List<Status> Current_Space_Feed
        {
            get { return _current_space_feed; }
            set { _current_space_feed = value; }
        }

        /// <summary>
        /// Id of the last seen space by the current logged in user
        /// </summary>
        public string Last_Seen_Space
        {
            get { return _last_seen_space; }
            set { _last_seen_space = value; }
        }
        
        /// <summary>
        /// Id of the last seen lecture by the current logged in user
        /// </summary>
        public string Last_Seen_Lecture
        {
            get { return _last_seen_lecture; }
            set { _last_seen_lecture = value; }
        }
    }
}
