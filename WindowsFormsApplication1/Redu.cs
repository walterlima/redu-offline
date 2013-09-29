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
        private List<Status> _feed;
        private List<Enrollment> _current_user_enrollments;
        private bool _is_first_login = true;
        private string _current_login = "";


        public Redu()
        {
            _redu_oauth = new ReduOAuth();
            _redu_offline = new ReduClientOffline();
            _redu_online = new ReduClientOnline(_redu_oauth);
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

        public bool enter_authorization_pin(String pin)
        {
            bool sucess = _redu_oauth.enter_authorization_pin(pin);
            return sucess;
        }

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
            }
        }

        private void load_offline_data()
        {
            _redu_offline.set_current_user_login(_current_login);
            _current_user = _redu_offline.get_me();
            _current_user_enrollments = _redu_offline.get_enrollment_by_user(_current_user);
            _current_user_avas = _redu_offline.get_environment_by_user(_current_user_enrollments);
            _feed = _redu_offline.get_user_feed(_current_user.Login);
            //pass info through
            _redu_online.Current_User = _current_user;
            _redu_online.Current_User_Avas = _current_user_avas;
            _redu_online.Current_User_Enrollments = _current_user_enrollments;
            _redu_online.Feed = _feed;
        }

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

        public void reply_status(User user, Status status_to_reply, string text)
        {
            _feed = is_connected() ? _redu_online.reply_status(_feed, status_to_reply.Id, text) : _redu_offline.reply_status(_feed, user, status_to_reply, text);
        }

        public void post_status_user(string text)
        {
            _feed = is_connected() ? _redu_online.post_status_user(_feed, _current_user.Id + "", text) : _redu_offline.post_status_user(_feed, _current_user, text);
        }

        public void post_status_space(Space space, User user, string text)
        {
            _feed = is_connected() ? _redu_online.post_status_space(_feed, space.Id, text) : _redu_offline.post_status_space(_feed, space, user, text);
        }

        public void post_status_lecture(User user, Lecture lecture_id, string text, bool is_help)
        {
            _feed = is_connected() ? _redu_online.post_status_lecture(_feed, lecture_id.Id, text, is_help) : _redu_offline.post_status_lecture(_feed, user, lecture_id, text, is_help);
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        private bool is_connected()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        public User Current_user
        {
            get { return _current_user; }
            set { _current_user = value; }
        }

        public List<Status> Feed
        {
            get { return _feed; }
            set { _feed = value; }
        }
    }
}
