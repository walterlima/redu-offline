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
    public partial class StatusLecture : StatusControl
    {
        public StatusLecture()
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

        public String Name_Lecture
        {
            get { return lbl_status_link_action.Text; }
            set { lbl_status_link_action.Text = value; }
        }

        public override String Name_User
        {
            get { return lbl_status_action.Text; }
            set { lbl_status_action.Text = value + " publicou em:"; }
        }

        public String Link_Tree
        {
            get { return lbl_status_link.Text; }
            set { lbl_status_link.Text = value; }
        }

    }
}
