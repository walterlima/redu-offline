using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    public class Social_Network
    {
        public Social_Network()
        {
        }
        public Social_Network(String profile, String name)
        {
            _profile = profile;
            _name = name;
        }

        private String _profile;
        private String _name;

        public String Profile 
        {
            get { return _profile; }
            set { _profile = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
