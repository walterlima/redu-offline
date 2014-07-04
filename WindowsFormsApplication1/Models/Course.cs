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
    /// <summary>
    /// Represents a Course inside Redu
    /// </summary>
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
        private List<String> _spaces_ids;        

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

        [XmlArray("spaces-ids")]
        [XmlArrayItem("space-id", typeof(String))]
        public List<String> Spaces_Ids
        {
            get { return _spaces_ids; }
            set { _spaces_ids = value; }
        }
        
    }
}
