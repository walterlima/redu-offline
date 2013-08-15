using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
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
        private List<Link> _links;

        [XmlElement("Id")]
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlElement("Created_At")]
        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        [XmlElement("Role")]
        public String Role
        {
            get { return _role; }
            set { _role = value; }
        }

        [XmlElement("Updated_At")]
        public String Updated_At
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }

        [XmlElement("State")]
        public String State
        {
            get { return _state; }
            set { _state = value; }
        }

        [XmlArray("Links")]
        [XmlArrayItem("Link", typeof(Link))]
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }

    }
}
