using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReduOffline.Models;

namespace ReduOffline
{
    public partial class StatusUser : UserControl//StatusControl
    {

        private Action<object, EventArgs> method_to_send_answer;        

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

        public void load_respostas(List<Status> respostas)
        {
            foreach (Status s in respostas)
            {
                AnswerViewer answer_control = new AnswerViewer();
                answer_control.Name_User = s.User.First_Name + " " + s.User.Last_Name;
                answer_control.Text_Resposta = s.Text;
                pn_answer_container.Controls.Add(answer_control);
            }
        }

        public void hide_answer_box(object sender, EventArgs e)
        {
            pn_to_add_answer.Controls.RemoveAt(pn_to_add_answer.Controls.Count - 1);
        }

        private void lnk_responder_Click(object sender, EventArgs e)
        {
            StatusAnswerControl answer_box = new StatusAnswerControl();
            pn_to_add_answer.Controls.Add(answer_box);
            answer_box.load_events(this.method_to_send_answer, this.hide_answer_box);
        }

        public Action<object, EventArgs> Method_To_Send_Answer
        {
            get { return method_to_send_answer; }
            set { method_to_send_answer = value; }
        }

    }
}
