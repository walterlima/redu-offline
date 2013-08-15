using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
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

        [XmlElement("Rel")]
        public String Rel 
        {
            get { return _rel; }
            set { _rel = value; }
        }

        [XmlElement("Href")]
        public String Href 
        {
            get { return _href; }
            set { _href = value; }
        }

        [XmlElement("Name")]
        public String Name { get; set; }

        [XmlElement("Permalink")]
        public String Permalink { get; set; }

    }
}
