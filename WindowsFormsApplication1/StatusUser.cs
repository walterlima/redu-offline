using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReduOffline
{
    public partial class StatusUser : StatusControl
    {
        public StatusUser()
        {
            InitializeComponent();
        }

        public override String Image_URL
        {
            get { return pic_user.ImageLocation; }
            set { pic_user.ImageLocation = value; }
        }

        public override String Text_Status
        {
            get { return lbl_txt.Text; }
            set { lbl_txt.Text = value; }
        }        

        public override String Name_User
        {
            get { return lbl_status_action.Text; }
            set { lbl_status_action.Text = value + " publicou em seu próprio mural:"; }
        }

    }
}
