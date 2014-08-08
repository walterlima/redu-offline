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

        /// <summary>
        /// Helps identify where in the Redu hierarchy the status was posted.
        /// </summary>
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

        /// <summary>
        /// Gets the Statusable Id for the given status
        /// </summary>
        public String Statusable_Id
        {
            get
            {
                string statusable = Links.Find(p => p.Rel.Equals(Constants.REL_STATUSABLE)).Href;
                string justNumbers = this.format_string_to_id(statusable);
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

        /// <summary>
        /// Format string to match the standard of Redy
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string format_string_to_id(string url)
        {
            url = this.reverse_string(url);
            int index = url.IndexOf('/');
            url = url.Remove(index);
            url = this.reverse_string(url);
            index = url.IndexOf('-');
            if (index >= 0)
            {
                url = url.Remove(index);
            }
            return url;
        }

        /// <summary>
        /// Reverses a given string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string reverse_string(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Overrides Equals method to ease the removal from List of Status.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {            
            Status s = obj as Status;

            if ((object)s == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }
            
            return this.Id.Equals(s.Id);
        }
    }
}
