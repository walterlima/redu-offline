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
            _reduOAuth.demand_authorize();
            panel2.Visible = false;
            panel1.Visible = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String pin = textBox3.Text;
            //tratamento de texto...
            _reduOAuth.enter_authorization_pin(pin);
        }
    }
}
