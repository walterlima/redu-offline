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
    public partial class AnswerViewer : UserControl
    {
        public AnswerViewer()
        {
            InitializeComponent();
        }

        public override String Image_URL
        {
            get { return pic_user.ImageLocation; }
            set { pic_user.ImageLocation = value; }
        }

        public override String Text_Resposta
        {
            get { return lbl_resposta.Text; }
            set { lbl_resposta.Text = value; }
        }

        public override String Name_User
        {
            get { return lbl_nome_user.Text; }
            set { lbl_nome_user.Text = value; }
        }
    }
}
