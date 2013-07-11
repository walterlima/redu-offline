using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    class Space
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Created_At { get; set; }
        public List<Link> Links { get; set; }

    }
}
