using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduOffline.Models;


namespace ReduOffline.API_Functions
{
    interface UserFunctions
    {

        User get_user(String user_id);

        User get_me();

        List<User> getUsersBySpace(String space_id, String role);
    }
}
