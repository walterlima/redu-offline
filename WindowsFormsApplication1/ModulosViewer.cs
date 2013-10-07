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
    public partial class ModulosViewer : UserControl
    {
        public ModulosViewer()
        {
            InitializeComponent();
        }

        public String Nome_Disciplina
        {
            get { return lbl_nome_disc.Text; }
            set { lbl_nome_disc.Text = value; }
        }

        public String Descricao_Disciplina
        {
            get { return lbl_descr.Text; }
            set { lbl_descr.Text = value; }
        }

        public void load_modulos(List<Subject> modulos)
        {
            foreach (Subject s in modulos)
            {
                ModuloDetailViewer modulo_control = new ModuloDetailViewer();
                modulo_control.Nome_Modulo = s.Name;
                modulo_control.Descricao_Modeulo = s.Description;
                modulo_control.load_aulas(s.Lectures);
                pn_modulos.Controls.Add(modulo_control);
            }
        }
    }
}
