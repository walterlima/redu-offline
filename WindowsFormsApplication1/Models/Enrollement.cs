using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    class Enrollement
    {
        public String ID { get; set; }
        public String State { get; set; }
        public String Created_At { get; set; }
        public String Role { get; set; }
        public List<Link> Links { get; set; }

    }
}
