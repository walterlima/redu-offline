using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    class Environment
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Initials { get; set; }
        public String Path { get; set; }
        public String Description { get; set; }
        public String Course_Count { get; set; }
        public String Created_at { get; set; }
        public List<Thumbnail> Thumbnails { get; set; }
        public List<Link> Links { get; set; }
    }
}
