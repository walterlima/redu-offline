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
    public partial class Form1 : Form
    {
        private Redu _redu = new Redu();
        private List<StatusControl> _list_controls = new List<StatusControl>();
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
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
                    panel2.Visible = false;
                    call_load_process();
                }
                else if (login_answer == 0) //waits for the pin
                {
                    panel2.Visible = false;
                    panel1.Visible = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            String pin = pinTxt.Text;
            //tratamento de texto...
            bool sucess =_redu.enter_authorization_pin(pin);
            if (sucess)
            {
                call_load_process();
            }
            else
            {
                //mostrar erro
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Blue,
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
            }
        }

        private void load_data_on_screen()
        {
            string[] image_paths = Directory.GetFiles(string.Format(Constants.XML_USER_THUMBNAIL_FOLDER, _redu.Current_user.Login));
            pic_user.ImageLocation = image_paths.First(a => a.Contains("160"));
            lbl_nome_user.Text = _redu.Current_user.First_Name + " " + _redu.Current_user.Last_Name;
            this.create_status_control(_redu.Feed);
            pn_load.Visible = false;
        }
        
        private void create_status_control(List<Status> statuses)
        {                        
            for (int i = statuses.Count - 1; i >= 0; i--)
            {                
                Status status = statuses[i];
                add_status_control(status);
            }                
        }

        private void add_status_control(Status status)
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
                    pn_main_wall.Controls.Add(status_control_user);
                    y = _list_controls.Count > 0 ? _list_controls[_list_controls.Count - 1].Location.Y + _list_controls[_list_controls.Count - 1].Size.Height + 10 : 5;
                    status_control_user.Location = new Point(x, y);
                    _list_controls.Add(status_control_user);
                    break;
                case Constants.STATUS_LECTURE:
                    StatusLecture status_control_lecture = new StatusLecture();
                    status_control_lecture.Text_Status = status.Text;
                    status_control_lecture.Name_Lecture = status.Link_Source;
                    status_control_lecture.Name = "status" + status.Id;
                    status_control_lecture.Name_User = status.User.First_Name;
                    status_control_lecture.Image_URL = Constants.URL_DEFAULT_THUMBNAIL_USER_32;
                    status_control_lecture.Link_Tree = status.Link_Tree;
                    pn_main_wall.Controls.Add(status_control_lecture);
                    y = _list_controls.Count > 0 ? _list_controls[_list_controls.Count - 1].Location.Y + _list_controls[_list_controls.Count - 1].Size.Height + 10 : 5;
                    status_control_lecture.Location = new Point(x, y);
                    _list_controls.Add(status_control_lecture);
                    break;
                case Constants.STATUS_SPACE:
                    StatusLecture status_control_space = new StatusLecture();
                    status_control_space.Text_Status = status.Text;
                    status_control_space.Name_Lecture = status.Link_Source;
                    status_control_space.Name = "status" + status.Id;
                    status_control_space.Name_User = status.User.First_Name;
                    status_control_space.Image_URL = Constants.URL_DEFAULT_THUMBNAIL_USER_32;
                    status_control_space.Link_Tree = status.Link_Tree;
                    pn_main_wall.Controls.Add(status_control_space);
                    y = _list_controls.Count > 0 ? _list_controls[_list_controls.Count - 1].Location.Y + _list_controls[_list_controls.Count - 1].Size.Height + 10 : 5;
                    status_control_space.Location = new Point(x, y);
                    _list_controls.Add(status_control_space);
                    break;

            }
        }

        private void btn_post_status_Click(object sender, EventArgs e)
        {
            if (bw_post_user.IsBusy != true)
            {
                pictureBox1.Visible = true;
                bw_post_user.RunWorkerAsync();
            }   
        }

        private void bw_post_user_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((bw_load.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {                
                string text = txt_post_status.Text;
                _redu.post_status_user(text);                
            }            
        }

        private void bw_post_user_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            add_status_control(_redu.Feed[0]);
            pictureBox1.Visible = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }
    }
}
