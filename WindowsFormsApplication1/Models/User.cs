using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    class User
    {
        public String Login { get; set; }
        public String Email { get; set; }
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public String Birthday { get; set; }
        public String Birth_Site { get; set; }
        //public int Friends_Count { get; set; }
        public int Id { get; set; }
        public List<Link> Links { get; set; }
        //public List<SocialNetwork> Social_Networks { get; set; }
        public List<Thumbnail> Thumbnails { get; set; }



    }
}
