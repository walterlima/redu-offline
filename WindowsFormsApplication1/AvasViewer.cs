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
    public partial class AvasViewer : UserControl
    {
        public AvasViewer()
        {
            InitializeComponent();
        }

        public String Nome_Ava
        {
            get { return lbl_name_ava.Text; }
            set { lbl_name_ava.Text = value; }
        }

        public void load_ava(List<Course> courses, Action<object, EventArgs> method_to_call)
        {
            //create controls
            foreach (Course c in courses)
            {
                CursoViewer course_control = new CursoViewer();
                course_control.Nome_Curso = c.Name;
                course_control.load_disciplinas(c.Spaces, method_to_call);
                pn_cursos.Controls.Add(course_control);
            }
        }
    }
}
