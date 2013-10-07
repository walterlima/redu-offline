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
    public partial class StatusAnswerControl : UserControl
    {
        public StatusAnswerControl()
        {
            InitializeComponent();
        }

        public Status parent_status;

        public String answer
        {
            get { return txt_resposta.Text; }
        }

        public void load_events(Action<object, EventArgs> method_to_call_enviar, Action<object, EventArgs> method_to_call_cancelar)
        {
            btn_enviar.Click += new EventHandler(method_to_call_enviar);
            btn_cancelar.Click += new EventHandler(method_to_call_cancelar);
        }
    }
}
