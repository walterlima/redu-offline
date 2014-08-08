/*
    Copyright 2013 Walter Ferreira de Lima Filho
    
    This file is part of ReduOffline.

    ReduOffline is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ReduOffline is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ReduOffline.  If not, see <http://www.gnu.org/licenses/>. 

*/
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
    public partial class StatusUser : StatusControl
    {

        private Action<object, EventArgs, Tuple<Status,String>> method_to_send_answer;
        private Status _status;

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

        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public void load_respostas(List<Status> respostas)
        {
            pn_answer_container.Visible = true;
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
        }

        private void lnk_responder_Click(object sender, EventArgs e)
        {
            StatusAnswerControl answer_box = new StatusAnswerControl();
            answer_box.Responding_Status = this._status;
            pn_to_add_answer.Controls.Add(answer_box);
            answer_box.load_events(this.method_to_send_answer, this.hide_answer_box);
        }

        public Action<object, EventArgs, Tuple<Status,String>> Method_To_Send_Answer
        {
            get { return method_to_send_answer; }
            set { method_to_send_answer = value; }
        }

    }
}
