using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReduOffline
{
    public partial class Form1 : Form
    {

        private ReduOAuth _reduOAuth = new ReduOAuth();
        private ReduClientOnline _reduOnline;

        public Form1()
        {
            InitializeComponent();
            _reduOnline = new ReduClientOnline(_reduOAuth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checa se é a primeira vez que tal pessoa loga nesta máquina
            //se for primeira vez, deve fazer autenticação
            //se houver internet -> autenticar
            //se não houver -> informar e pedir para voltar quando houver internet
            if (!loginTxt.Text.Equals(string.Empty))
            {
                bool already_authorized = _reduOAuth.demand_authorize(loginTxt.Text);
                if (already_authorized)
                {
                    panel2.Visible = false;
                    //começar a bagaça
                }
                else
                {
                    panel2.Visible = false;
                    panel1.Visible = true;
                    
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String pin = pinTxt.Text;
            //tratamento de texto...
            _reduOAuth.enter_authorization_pin(pin);            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Azure,
            e.ClipRectangle.Left,
            e.ClipRectangle.Top,
            e.ClipRectangle.Width - 1,
            e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //_reduOnline.get_me();
            _reduOnline.get_user_first_data();
        }
    }
}
