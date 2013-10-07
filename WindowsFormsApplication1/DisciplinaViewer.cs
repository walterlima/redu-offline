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
    public partial class DisciplinaViewer : UserControl
    {
        public DisciplinaViewer()
        {
            InitializeComponent();
        }

        public Space Disciplina
        {
            get;
            set;
        }

        public String Nome_Disciplina
        {
            get { return lnk_name_disciplina.Text; }
            set { lnk_name_disciplina.Text = value; }
        }

        public void load_event(Action<object, EventArgs> method_to_call)
        {
            lnk_name_disciplina.Click += new EventHandler(method_to_call);
        }
    }
}
