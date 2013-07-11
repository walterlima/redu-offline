using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduOffline.API_Functions;
using ReduOffline.Models;

namespace ReduOffline
{
    class ReduClientOnline : UserFunctions<User>
    {

        public User getUser(string user_id)
        {
            throw new NotImplementedException();
        }

        public User getMe()
        {
            throw new NotImplementedException();
        }

        public List<User> getUsersBySpace(string space_id, string role)
        {
            throw new NotImplementedException();
        }
    }
}
