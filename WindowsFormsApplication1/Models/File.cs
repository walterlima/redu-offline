using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    class File
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Mimetype { get; set; }
        public String Size { get; set; }
        public String Bytes { get; set; }
        public String Created_At { get; set; }
        public String Path_System { get; set; }
        public List<Link> Links { get; set; }

    }
}
