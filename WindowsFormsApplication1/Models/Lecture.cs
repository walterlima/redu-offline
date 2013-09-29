using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
    [Serializable()]
    [XmlRoot("lecture")]
    public class Lecture
    {

        public Lecture() { }       

        private String _created_at;
        private String _name;
        private int _position;
        private String _type;
        private String _id;
        private int _rating;
        private int _view_count;
        private String _updated_at;
        private List<Link> _links;
        private String _content;
        private String _raw;
        private String _mimetype;
        private List<Status> _timeline;
        private Subject _parent_subject;
        private String _name_space;
        private String _name_subject;
        private String _name_course;
        private String _name_ava;
        
        [XmlElement("created-at")]
        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }
        
        [XmlElement("name")]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement("position")]
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        [XmlElement("type")]
        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [XmlElement("id")]
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlElement("rating")]
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        [XmlElement("view-count")]
        public int View_Count
        {
            get { return _view_count; }
            set { _view_count = value; }
        }

        [XmlElement("updated-at")]
        public String Updated_At
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }
        
        [XmlArray("links")]
        [XmlArrayItem("link", typeof(Link))]
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

        [XmlElement("content")]
        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        [XmlElement("raw")]
        public String Raw
        {
            get { return _raw; }
            set { _raw = value; }
        }

        [XmlElement("mimetype")]
        public String Mimetype
        {
            get { return _mimetype; }
            set { _mimetype = value; }
        }

        [XmlArray("timeline")]
        [XmlArrayItem("status", typeof(Status))]
        public List<Status> Timeline
        {
            get { return _timeline; }
            set { _timeline = value; }
        }

        [XmlElement("name-space")]
        public String Name_Space
        {
            get { return _name_space; }
            set { _name_space = value; }
        }

        [XmlElement("name-subject")]
        public String Name_Subject
        {
            get { return _name_subject; }
            set { _name_subject = value; }
        }

        [XmlElement("name-course")]
        public String Name_Course
        {
            get { return _name_course; }
            set { _name_course = value; }
        }

        [XmlElement("name-ava")]
        public String Name_Ava
        {
            get { return _name_ava; }
            set { _name_ava = value; }
        }

        public String Link_Tree
        {
            get
            {
                string format = "{0} > {1} > {2} > {3} > {4}";
                return string.Format(format, Name_Ava, Name_Course, Name_Space, Name_Subject, Name);
            }
        }
    }
}
