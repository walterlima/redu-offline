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
    public partial class AulaViewer : UserControl
    {
        public AulaViewer()
        {
            InitializeComponent();
        }

        public String Nome_Aula
        {
            get { return lbl_nome_aula.Text; }
            set { lbl_nome_aula.Text = value; }
        }

        public String Ordem
        {
            get { return lbl_cardinal.Text; }
            set { lbl_cardinal.Text = value + "."; }
        }
    }
}
