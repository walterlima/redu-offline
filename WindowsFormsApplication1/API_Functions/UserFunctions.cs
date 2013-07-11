using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduOffline.Models;


namespace ReduOffline.API_Functions
{
    interface UserFunctions<T>
    {

        public T getUser(String user_id);

        public T getMe();

        public List<T> getUsersBySpace(String space_id, String role);
    }
}
