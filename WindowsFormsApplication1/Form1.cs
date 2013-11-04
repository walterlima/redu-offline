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
using ReduOffline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReduOffline
{
    public partial class MainScreen : Form
    {
        public enum UserView
        {
            User=1,
            Ava=2,
            Course=3,
            Space=4,
            Subject=5,
            Lecture=6
        }
        
        private Redu _redu = new Redu();
        private bool _avas_loaded = false;
        private List<StatusControl> _list_controls = new List<StatusControl>();
        private UserView _user_view = UserView.User;

        public MainScreen()
        {
            InitializeComponent();            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //checa se é a primeira vez que tal pessoa loga nesta máquina
            //se for primeira vez, deve fazer autenticação
            //se houver internet -> autenticar
            //se não houver -> informar e pedir para voltar quando houver internet
            if (!loginTxt.Text.Equals(string.Empty))
            {
                int login_answer = _redu.login_procedure(loginTxt.Text);
                if (login_answer == 1)//is already authorized
                {
                    pn_login.Visible = false;
                    call_load_process();
                }
                else if (login_answer == 0) //waits for the pin
                {
                    pn_login.Visible = false;
                    pn_pin.Visible = true;
                }
                else //it's not possible at the moment
                {

                }
                
            }
        }

        private void call_load_process()
        {
            if (bw_load.IsBusy != true)
            {
                pn_load.Visible = true;
                bw_load.RunWorkerAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_pin_Click(object sender, EventArgs e)
        {
            String pin = pinTxt.Text;
            //tratamento de texto...
            bool sucess =_redu.enter_authorization_pin(pin);
            if (sucess)
            {
                pn_pin.Visible = false;
                call_load_process();
            }
            else
            {
                //mostrar erro
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.CornflowerBlue, 0.1f);                        
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            e.Graphics.DrawRectangle(pen,
            e.ClipRectangle.Left,
            e.ClipRectangle.Top,
            e.ClipRectangle.Width - 1,
            e.ClipRectangle.Height - 1);            
            base.OnPaint(e);
        }
        
        private void bw_load_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((bw_load.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {                
                _redu.load_data();
            }
        }

        private void bw_load_ProgressChanged(object sender, ProgressChangedEventArgs e) { }

        private void bw_load_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true)) { }

            else if (!(e.Error == null)) { }

            else
            {
                load_data_on_screen();
                pn_load.Visible = false;
            }
        }

        private void load_data_on_screen()
        {
            string[] image_paths = Directory.GetFiles(string.Format(Constants.XML_USER_THUMBNAIL_FOLDER, _redu.Current_user.Login));
            pic_user.ImageLocation = image_paths.First(a => a.Contains("160"));
            lbl_nome_user.Text = _redu.Current_user.First_Name + " " + _redu.Current_user.Last_Name;
            //load user's feed
            load_user_feed();            
        }
        
        private void create_status_control(List<Status> statuses, FlowLayoutPanel pn_feed)
        {                        
            for (int i = statuses.Count - 1; i >= 0; i--)
            {                
                Status status = statuses[i];
                add_status_control(status, pn_feed);
            }                
        }

        /// <summary>
        /// Adds status control according to its type
        /// </summary>
        /// <param name="status"></param>
        private void add_status_control(Status status, FlowLayoutPanel pn_feed)
        {
            int x = 5;
            int y = 0;
            
            switch (status.Post_Local)
            {
                case Constants.STATUS_USER:
                    StatusUser status_control_user = new StatusUser();
                    status_control_user.Text_Status = status.Text;
                    status_control_user.Name = "status" + status.Id;
                    status_control_user.Name_User = status.User.First_Name;
                    status_control_user.Image_URL = Constants.URL_DEFAULT_THUMBNAIL_USER_32;
                    status_control_user.Status = status;
                    status_control_user.Method_To_Send_Answer = this.method_reply_status;
                    if (status.Answers_Count > 0)
                    {
                        status_control_user.load_respostas(status.Answers);
                    }                    
                    pn_feed.Controls.Add(status_control_user);
                    //y = _list_controls.Count > 0 ? _list_controls[_list_controls.Count - 1].Location.Y + _list_controls[_list_controls.Count - 1].Size.Height + 10 : 5;
                    //status_control_user.Location = new Point(x, y);
                    //_list_controls.Add(status_control_user);
                    break;
                case Constants.STATUS_LECTURE:
                    StatusLecture status_control_lecture = new StatusLecture();
                    status_control_lecture.Text_Status = status.Text;
                    status_control_lecture.Name_Lecture = status.Link_Source;
                    status_control_lecture.Name = "status" + status.Id;
                    status_control_lecture.Name_User = status.User.First_Name;
                    status_control_lecture.Image_URL = Constants.URL_DEFAULT_THUMBNAIL_USER_32;
                    status_control_lecture.Link_Tree = status.Link_Tree;
                    status_control_lecture.Status = status;
                    status_control_lecture.Method_To_Send_Answer = this.method_reply_status;
                    if (status.Answers_Count > 0)
                    {
                        status_control_lecture.load_respostas(status.Answers);
                    }
                    pn_feed.Controls.Add(status_control_lecture);
                    //y = _list_controls.Count > 0 ? _list_controls[_list_controls.Count - 1].Location.Y + _list_controls[_list_controls.Count - 1].Size.Height + 10 : 5;
                    //status_control_lecture.Location = new Point(x, y);
                    //_list_controls.Add(status_control_lecture);
                    break;
                case Constants.STATUS_SPACE:
                    StatusLecture status_control_space = new StatusLecture();
                    status_control_space.Text_Status = status.Text;
                    status_control_space.Name_Lecture = status.Link_Source;
                    status_control_space.Name = "status" + status.Id;
                    status_control_space.Name_User = status.User.First_Name;
                    status_control_space.Image_URL = Constants.URL_DEFAULT_THUMBNAIL_USER_32;
                    status_control_space.Link_Tree = status.Link_Tree;
                    status_control_space.Status = status;
                    status_control_space.Method_To_Send_Answer = this.method_reply_status;
                    if (status.Answers_Count > 0)
                    {
                        status_control_space.load_respostas(status.Answers);
                    }
                    pn_feed.Controls.Add(status_control_space);
                    //y = _list_controls.Count > 0 ? _list_controls[_list_controls.Count - 1].Location.Y + _list_controls[_list_controls.Count - 1].Size.Height + 10 : 5;
                    //status_control_space.Location = new Point(x, y);
                    //_list_controls.Add(status_control_space);
                    break;

            }
        }

        private void btn_post_status_Click(object sender, EventArgs e)
        {
            if (bw_post_user.IsBusy != true)
            {
                pic_small_load.Visible = true;
                bw_post_user.RunWorkerAsync();
            }   
        }

        private void bw_post_user_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((bw_post_user.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {                
                string text = txt_post_status.Text;
                switch (_user_view)
                {
                    case (UserView.Lecture):
                        _redu.post_status_lecture(_redu.Current_user, _redu.Last_Seen_Lecture, text, false);
                        break;
                    case (UserView.Space):
                        _redu.post_status_space(_redu.Last_Seen_Space, _redu.Current_user, text);
                        break;
                    case (UserView.Ava):
                    case (UserView.Course):
                    case (UserView.User):
                    case (UserView.Subject):
                        _redu.post_status_user(text);
                        break;

                }
            }            
        }

        private void bw_post_user_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (_user_view)
            {
                case (UserView.Lecture):
                    add_status_control(_redu.find_lecture_feed(_redu.Last_Seen_Lecture)[0], pn_lecture_or_space_feed);
                    break;
                case (UserView.Space):
                    add_status_control(_redu.find_space_feed(_redu.Last_Seen_Space)[0], pn_lecture_or_space_feed);
                    break;
                case (UserView.Ava):
                case (UserView.Course):
                case (UserView.User):
                case (UserView.Subject):
                    add_status_control(_redu.Feed[0], pn_main_wall);
                    break;

            }
            
            pic_small_load.Visible = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            _redu.synchronize_pending_activities();
        }

        private void pn_menu_avas_Click(object sender, EventArgs e)
        {
            //load avas
            if (!_avas_loaded)
            {
                load_panel_avas();                
            }
            _user_view = UserView.Ava;
            show_panel(pn_avas, "Compartilhe conosco suas ideias.");            
        }

        private void load_panel_avas()
        {
            List<EnvironmentRedu> avas = _redu.Current_User_Avas;
            foreach (EnvironmentRedu a in avas)
            {
                AvasViewer ava_control = new AvasViewer();
                ava_control.Nome_Ava = a.Name;
                ava_control.load_ava(a.Courses, load_disciplina);
                pn_avas.Controls.Add(ava_control);
            }
            _avas_loaded = true;
        }

        private void pn_menu_mural_Click(object sender, EventArgs e)
        {
            _user_view = UserView.User;
            show_panel(pn_main_wall, "Compartilhe conosco suas ideias.");            
        }

        private void load_disciplina(object sender, EventArgs e, Space space)
        {
            pn_disciplina.Controls.Clear();
            Space disciplina = space;
            ModulosViewer disciplina_control = new ModulosViewer();
            disciplina_control.Nome_Disciplina = disciplina.Name;
            disciplina_control.Descricao_Disciplina = disciplina.Description;
            disciplina_control.load_modulos(disciplina.Subjects, load_lecture_feed);
            pn_disciplina.Controls.Add(disciplina_control);
            _redu.Last_Seen_Space = space.Id;
            _user_view = UserView.Space;
            show_panel(pn_disciplina, "Compartilhe alguma ideia sobre esta disciplina");            
        }

        private void load_user_feed()
        {
            pn_main_wall.Controls.Clear();
            this.create_status_control(_redu.Feed, pn_main_wall);
            _user_view = UserView.User;
            show_panel(pn_main_wall, "Compartilhe conosco suas ideias.");            
        }

        private void load_lecture_feed(object sender, EventArgs e, String lecture_id)
        {
            pn_lecture_or_space_feed.Controls.Clear();
            //go look for the lecture's feed
            List<Status> feed = _redu.find_lecture_feed(lecture_id);
            this.create_status_control(feed, pn_lecture_or_space_feed);
            _redu.Last_Seen_Lecture = lecture_id;
            _user_view = UserView.Lecture;
            show_panel(pn_lecture_or_space_feed, "Compartilhe alguma ideia sobre esta aula, ou peça ajuda caso tenha dúvidas.");                        
        }

        private void load_space_feed(object sender, EventArgs e, String space_id)
        {
            pn_lecture_or_space_feed.Controls.Clear();
            //go look for the space's feed
            List<Status> feed = _redu.find_space_feed(space_id);
            this.create_status_control(feed, pn_lecture_or_space_feed);
            _user_view = UserView.Space;
            show_panel(pn_lecture_or_space_feed, "Compartilhe alguma ideia sobre esta disciplina.");            
        }

        /// <summary>
        /// Assynchronous method to reply status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_reply_status_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((bw_reply_status.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Tuple<Status, String> tuple_id_plus_text = e.Argument as Tuple<Status, String>;                
                string text = tuple_id_plus_text.Item2;
                Status status = tuple_id_plus_text.Item1;                
                switch (_user_view)
                {
                    case (UserView.Lecture):
                        _redu.reply_status(_redu.Current_user, status, text, _redu.find_lecture_feed(_redu.Last_Seen_Lecture));
                        break;
                    case (UserView.Space):
                        _redu.reply_status(_redu.Current_user, status, text, _redu.find_space_feed(_redu.Last_Seen_Space));
                        break;
                    case (UserView.User):
                        _redu.reply_status(_redu.Current_user, status, text, _redu.Feed);
                        break;
                }                
            }
        }

        private void method_reply_status(object sender, EventArgs e, Tuple<Status, String> tuple_id_plus_text)
        {            
            if (bw_post_user.IsBusy != true)
            {                             
                bw_reply_status.RunWorkerAsync(tuple_id_plus_text);
                pic_small_load.Visible = true;
            }   
        }

        private void bw_reply_status_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //carregar informação na tela
            switch (_user_view)
            {
                case(UserView.Lecture):
                    load_lecture_feed(null, null, _redu.Last_Seen_Lecture);
                    break;
                case(UserView.Space):
                    load_space_feed(null, null, _redu.Last_Seen_Space);
                    break;
                case(UserView.User):
                    load_user_feed();
                    break;
            }
            pic_small_load.Visible = false;
        }
        
        /// <summary>
        /// Shows target panel and changes status box
        /// </summary>
        /// <param name="panel_to_show"></param>
        /// <param name="txt_postbox"></param>
        private void show_panel(FlowLayoutPanel panel_to_show, String txt_postbox)
        {
            pn_disciplina.Visible = pn_main_wall.Visible = pn_avas.Visible = pn_lecture_or_space_feed.Visible = false;
            panel_to_show.Visible = true;
            txt_post_status.Text = txt_postbox.Equals(string.Empty)? txt_post_status.Text : txt_postbox;
            pn_menu_mural.Visible = _user_view == UserView.Space ? true : false;
            pn_more_status.Visible = _user_view == UserView.User || _user_view == UserView.Lecture || _user_view == UserView.Space ? true : false;
            if (pn_more_status.Visible)
                pn_wall_Resize(null, null);
            
        }


        /// <summary>
        /// Load the panel that shows the latest synchronized activities
        /// </summary>
        /// <param name="pending_activities"></param>
        private void load_sync_notification(List<PendingActivity> pending_activities)
        {
            var list = from pa in pending_activities where pa.Done == true select pa;
            list.OrderBy(x => x.Sync_Time_Stamp);
            List<PendingActivity> synchronized = list.ToList();

            foreach (PendingActivity pa in synchronized)
            {
                Label lb = new Label();
                lb.Text = "";
                
            }
        }

        /// <summary>
        /// Method to reposition the + button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pn_wall_Resize(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = _user_view == UserView.User ? pn_main_wall : pn_lecture_or_space_feed;
            int x = 614;
            int y = panel.Size.Height - 38;
            pn_wall.VerticalScroll.Value = pn_wall.VerticalScroll.Minimum;
            Point location = new Point(x,y);
            pn_more_status.Location = location;
        }

        private void pn_menu_mural_Click_1(object sender, EventArgs e)
        {
            this.load_space_feed(null, null, _redu.Last_Seen_Space);
        }

        private void pn_notif_hidden_Click(object sender, EventArgs e)
        {
            pn_notif_hidden.Visible = false;
            pn_notification.Visible = true;
        }

        private void pn_click_hide_notf_Click(object sender, EventArgs e)
        {
            pn_notif_hidden.Visible = true;
            pn_notification.Visible = false;
        }
       
    }
}
