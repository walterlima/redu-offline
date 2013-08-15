using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    public class Thumbnail
    {
        public Thumbnail()
        {
        }
        public Thumbnail(String href, String size)
        {
            _href = href;
            _size = size;
        }

        private String _href;
        private String _size;

        public String Href
        {
            get { return _href; }
            set { _href = value; }
        }

        public String Size
        {
            get { return _size; }
            set { _size = value; }
        }

    }
}
