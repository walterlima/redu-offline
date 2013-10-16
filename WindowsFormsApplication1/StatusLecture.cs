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
    public partial class StatusLecture : StatusControl
    {
        private Action<object, EventArgs> method_to_send_answer;
        private bool _control_answer_active = false;

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

        public void load_respostas(List<Status> respostas)
        {
            foreach (Status s in respostas)
            {
                AnswerViewer answer_control = new AnswerViewer();
                answer_control.Name_User = s.User.First_Name + " " + s.User.Last_Name;
                answer_control.Text_Resposta = s.Text;
                answer_control.Image_URL = Constants.URL_DEFAULT_THUMBNAIL_USER_32;
                pn_answer_container.Controls.Add(answer_control);
            }
        }

        public void hide_answer_box(object sender, EventArgs e)
        {
            pn_to_add_answer.Controls.RemoveAt(pn_to_add_answer.Controls.Count - 1);
            _control_answer_active = false;
        }

        private void lnk_responder_Click(object sender, EventArgs e)
        {
            if (!_control_answer_active)
            {
                StatusAnswerControl answer_box = new StatusAnswerControl();
                pn_to_add_answer.Controls.Add(answer_box);
                answer_box.load_events(this.method_to_send_answer, this.hide_answer_box);
                _control_answer_active = true;
            }
        }

        public Action<object, EventArgs> Method_To_Send_Answer
        {
            get { return method_to_send_answer; }
            set { method_to_send_answer = value; }
        }

        private void lnk_responder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!_control_answer_active)
            {
                StatusAnswerControl answer_box = new StatusAnswerControl();
                pn_to_add_answer.Controls.Add(answer_box);
                answer_box.load_events(this.method_to_send_answer, this.hide_answer_box);
                _control_answer_active = true;
            }
        }

    }
}
