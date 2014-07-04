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
    /// Represents an Enrollment of a certain user inside Redu
    /// </summary>
    [Serializable()]
    public class Enrollment
    {

        public Enrollment()
        {}

        public Enrollment(String id, String created_at, String role, String updated_at, String state, List<Link> links)
        {
            _id = id;
            _created_at = created_at;
            _role = role;
            _updated_at = updated_at;
            _state = state;
            _links = links;
        }

        private String _id;
        private String _created_at;
        private String _role;
        private String _updated_at;
        private String _state;
        private String _ava_name;
        private List<Link> _links;

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

        [XmlElement("role")]
        public String Role
        {
            get { return _role; }
            set { _role = value; }
        }

        [XmlElement("updated-at")]
        public String Updated_At
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }

        [XmlElement("state")]
        public String State
        {
            get { return _state; }
            set { _state = value; }
        }

        [XmlElement("ava-name")]
        public String Ava_Name
        {
            get { return _ava_name; }
            set { _ava_name = value; }
        }

        [XmlArray("links")]
        [XmlArrayItem("link", typeof(Link))]
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

    }
}
