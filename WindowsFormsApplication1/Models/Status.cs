using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    public class Status
    {
        public Status() { }        

        private String _id;
        private String _created_at;
        private String _text;
        private List<Link> _links;
        private User _user;
        private int _answers_count;
        private String _type;
        
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public int Answers_Count
        {
            get { return _answers_count; }
            set { _answers_count = value; }
        }

        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
