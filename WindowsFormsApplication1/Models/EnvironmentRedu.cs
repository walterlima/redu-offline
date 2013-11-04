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
    [XmlRoot("environment-redu")]
    public class EnvironmentRedu
    {

        public EnvironmentRedu() { }

        private String _id;
        private String _name;
        private String _initials;
        private String _path;
        private String _description;
        private String _course_count;
        private String _created_at;
        private List<Thumbnail> _thumbnails;
        private List<Link> _links;
        private List<Course> _courses;
        private List<String> _courses_ids;
        
        
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

        [XmlElement("initials")]
        public String Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

        [XmlElement("path")]
        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }

        [XmlElement("description")]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [XmlElement("course-count")]
        public String Course_Count
        {
            get { return _course_count; }
            set { _course_count = value; }
        }

        [XmlElement("created-at")]
        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        [XmlArray("thumbnails")]
        [XmlArrayItem("thumbnail", typeof(Thumbnail))]
        public List<Thumbnail> Thumbnails
        {
            get { return _thumbnails; }
            set { _thumbnails = value; }
        }

        [XmlArray("links")]
        [XmlArrayItem("link", typeof(Link))]
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

        [XmlArray("courses")]
        [XmlArrayItem("course", typeof(Course))]
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        [XmlArray("courses-ids")]
        [XmlArrayItem("course-id", typeof(String))]
        public List<String> Courses_Ids
        {
            get { return _courses_ids; }
            set { _courses_ids = value; }
        }
    }
}
