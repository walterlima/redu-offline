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
    public partial class ModuloDetailViewer : UserControl
    {
        public ModuloDetailViewer()
        {
            InitializeComponent();
        }

        public String Nome_Modulo
        {
            get { return lbl_nome_mod.Text; }
            set { lbl_nome_mod.Text = value; }
        }

        public String Descricao_Modeulo
        {
            get { return lbl_descr_mod.Text; }
            set { lbl_descr_mod.Text = value; }
        }

        public void load_aulas(List<Lecture> aulas)
        {
            int i = 1;
            foreach (Lecture l in aulas)
            {
                AulaViewer aula_control = new AulaViewer();
                aula_control.Nome_Aula = l.Name;
                aula_control.Ordem = i+"";
                i++;
                pn_aulas.Controls.Add(aula_control);
            }
        }
    }
}
