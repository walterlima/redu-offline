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
    [XmlRoot("subject")]
    public class Subject
    {

        public Subject() { }

        private String _id;
        private String _name;
        private String _description;
        private String _created_at;
        private List<Link> _links;
        private List<Lecture> _lectures;
        private Space _parent_space;
        private List<String> _lecture_ids;
        

        [XmlElement("parent-space")]
        public Space Parent_Space
        {
            get { return _parent_space; }
            set { _parent_space = value; }
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

        [XmlArray("lectures")]
        [XmlArrayItem("lecture", typeof(Lecture))]
        public List<Lecture> Lectures
        {
            get { return _lectures; }
            set { _lectures = value; }
        }

        [XmlArray("lectures-ids")]
        [XmlArrayItem("lecture-id", typeof(String))]
        public List<String> Lecture_Ids
        {
            get { return _lecture_ids; }
            set { _lecture_ids = value; }
        }
    }
}
