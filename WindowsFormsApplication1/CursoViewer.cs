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
    public partial class CursoViewer : UserControl
    {
        public CursoViewer()
        {
            InitializeComponent();
        }

        public String Nome_Curso
        {
            get { return lbl_nome_curso.Text; }
            set { lbl_nome_curso.Text = value; }
        }

        public void load_disciplinas(List<Space> spaces, Action<object, EventArgs> method_to_call)
        {
            foreach (Space s in spaces)
            {
                DisciplinaViewer space_control = new DisciplinaViewer();
                space_control.Nome_Disciplina = s.Name;
                space_control.Disciplina = s;
                space_control.load_event(method_to_call);
                pn_disciplinas.Controls.Add(space_control);
            }
        }
    }
}
