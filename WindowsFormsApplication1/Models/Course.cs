﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
    [Serializable()]
    [XmlRoot("course")]
    public class Course
    {

        public Course() { }

        private String _name;
        private String _id;
        private String _created_at;
        private String _path;
        private String _workload;
        private String _description;
        private List<Link> _links;
        private List<Space> _spaces;
        private EnvironmentRedu _parent_ava;

        [XmlElement("parent-ava")]
        public EnvironmentRedu Parent_Ava
        {
            get { return _parent_ava; }
            set { _parent_ava = value; }
        }

        [XmlElement("name")]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

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

        [XmlElement("path")]
        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }

        [XmlElement("workload")]
        public String Workload
        {
            get { return _workload; }
            set { _workload = value; }
        }

        [XmlElement("description")]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [XmlArray("links")]
        [XmlArrayItem("link", typeof(Link))]
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

        [XmlArray("spaces")]
        [XmlArrayItem("space", typeof(Space))]
        public List<Space> Spaces
        {
            get { return _spaces; }
            set { _spaces = value; }
        }
        
    }
}
