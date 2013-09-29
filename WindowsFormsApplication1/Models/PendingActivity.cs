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
        private String _lecture_id;
        private String _status_id;        
        private TypePendingActivity _type_pending_activity;

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

        [XmlElement("type-pending-activity")]
        public TypePendingActivity Type_pending_activity
        {
            get { return _type_pending_activity; }
            set { _type_pending_activity = value; }
        }
        
    }
}
