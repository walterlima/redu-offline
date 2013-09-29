using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
    [Serializable()]
    [XmlRoot("status")]
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
        private String _post_local;        
        private List<Status> _answers;
        private String _link_tree;
        private String _link_source;
        
        
        [XmlElement("id")]
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlElement("created-at")]
        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        [XmlElement("text")]
        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [XmlArray("links")]
        [XmlArrayItem("link", typeof(Link))]
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

        [XmlElement("user")]
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        [XmlElement("answers-count")]
        public int Answers_Count
        {
            get { return _answers_count; }
            set { _answers_count = value; }
        }

        [XmlElement("type")]
        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [XmlElement("post-local")]
        public String Post_Local
        {
            get
            {
                string statusable = Links.Find(p => p.Rel.Equals(Constants.REL_STATUSABLE)).Href;
                if (statusable != null)
                {
                    if (statusable.Contains("lectures"))
                    {
                        return Constants.STATUS_LECTURE;
                    }
                    else if (statusable.Contains("users"))
                    {
                        return Constants.STATUS_USER;
                    }
                    else if (statusable.Contains("spaces"))
                    {
                        return Constants.STATUS_SPACE;
                    }
                    else
                    {
                        return "none";
                    }
                }
                else
                {
                    return "none";
                }
            }
        }

        public String Statusable_Id
        {
            get
            {
                string statusable = Links.Find(p => p.Rel.Equals(Constants.REL_STATUSABLE)).Href;
                string justNumbers = new String(statusable.Where(Char.IsDigit).ToArray());
                return justNumbers;
            }
        }

        [XmlArray("answers")]
        [XmlArrayItem("status", typeof(Status))]
        public List<Status> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        [XmlElement("link-tree")]
        public String Link_Tree
        {
            get { return _link_tree; }
            set { _link_tree = value; }
        }

        [XmlElement("link-source")]
        public String Link_Source
        {
            get { return _link_source; }
            set { _link_source = value; }
        }
    }
}
