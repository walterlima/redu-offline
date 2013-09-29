using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
    [Serializable()]
    [XmlRoot("space")]
    public class Space
    {

        public Space() { }

        private String _id;
        private String _name;
        private String _description;
        private String _created_at;
        private List<Link> _links;
        private List<Subject> _subjects;
        private List<Status> _timeline;
        private Course _parent_course;
        private String _name_course;
        private String _name_ava;
        

        [XmlElement("parent-course")]
        public Course Parent_Course
        {
            get { return _parent_course; }
            set { _parent_course = value; }
        }

        [XmlElement("id")]
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlElement("name")]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement("description")]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [XmlElement("created-at")]
        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }
        
        [XmlArray("links")]
        [XmlArrayItem("link", typeof(Link))]
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

        [XmlArray("subjects")]
        [XmlArrayItem("subject", typeof(Subject))]
        public List<Subject> Subjects
        {
            get { return _subjects; }
            set { _subjects = value; }
        }

        [XmlArray("timeline")]
        [XmlArrayItem("status", typeof(Status))]
        public List<Status> Timeline
        {
            get { return _timeline; }
            set { _timeline = value; }
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
                string format = "{0} > {1} > {2}";
                return string.Format(format, Name_Ava, Name_Course, Name);
            }
        }
    }
}
