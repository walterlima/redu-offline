using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReduOffline.Models
{
    [Serializable()]
    public class Thumbnail
    {
        public Thumbnail() { }

        public Thumbnail(String href, String size)
        {
            _href = href;
            _size = size;
        }

        private String _href;
        private String _size;

        [XmlElement("href")]
        public String Href
        {
            get { return _href; }
            set { _href = value; }
        }

        [XmlElement("size")]
        public String Size
        {
            get { return _size; }
            set { _size = value; }
        }

    }
}
