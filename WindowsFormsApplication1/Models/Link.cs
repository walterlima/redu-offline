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
    /// Auxiliar Link structure used by Redu API
    /// Represents explicit links between many of Redu's base objects
    /// </summary>
    [Serializable()]
    public class Link
    {

        public Link() { }

        public Link(String rel, String href)
        {
            _rel = rel;
            _href = href;
        }        

        private String _rel;
        private String _href;

        [XmlElement("rel")]
        public String Rel 
        {
            get { return _rel; }
            set { _rel = value; }
        }

        [XmlElement("href")]
        public String Href 
        {
            get { return _href; }
            set { _href = value; }
        }

        [XmlElement("name")]
        public String Name { get; set; }

        [XmlElement("permalink")]
        public String Permalink { get; set; }

    }
}
