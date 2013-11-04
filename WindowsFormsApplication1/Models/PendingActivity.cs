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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
    [Serializable()]
    public class PendingActivity
    {
        public enum TypePendingActivity
        {
            SubmitStatusUser=1,
            SubmitStatusSpace=2,
            SubmitStatusLecture=3,
            AnswerStatus=4
        }

        private String _id_user;
        private String _text;
        private String _date;
        private String _space_id;        
        private String _lecture_id;
        private String _status_id;
        private String _sync_time_stamp;        
        private bool _done;        
        private TypePendingActivity _type_pending_activity;
        private Status _wrapped_status;
        private Status _status_to_answer;
        

        [XmlElement("wrapped-status")]
        public Status Wrapped_Status
        {
            get { return _wrapped_status; }
            set { _wrapped_status = value; }
        }

        [XmlElement("id-user")]
        public String Id_User
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

        [XmlElement("text")]
        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [XmlElement("date")]
        public String Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [XmlElement("status-id")]
        public String Status_Id
        {
            get { return _status_id; }
            set { _status_id = value; }
        }

        [XmlElement("lecture-id")]
        public String Lecture_Id
        {
            get { return _lecture_id; }
            set { _lecture_id = value; }
        }

        [XmlElement("space-id")]
        public String Space_Id
        {
            get { return _space_id; }
            set { _space_id = value; }
        }

        [XmlElement("type-pending-activity")]
        public TypePendingActivity Type_pending_activity
        {
            get { return _type_pending_activity; }
            set { _type_pending_activity = value; }
        }

        [XmlElement("sync-time-stamp")]
        public String Sync_Time_Stamp
        {
            get { return _sync_time_stamp; }
            set { _sync_time_stamp = value; }
        }

        [XmlElement("done")]
        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }

        [XmlElement("status-to-answer")]
        public Status Status_To_Answer
        {
            get { return _status_to_answer; }
            set { _status_to_answer = value; }
        }
        
    }
}
