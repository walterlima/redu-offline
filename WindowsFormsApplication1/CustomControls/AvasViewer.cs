/*
    Copyright 2013 Walter Ferreira de Lima Filho
    
    This file is part of ReduOffline.

    ReduOffline is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ReduOffline is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ReduOffline.  If not, see <http://www.gnu.org/licenses/>. 

*/
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

        public void load_ava(List<Course> courses, Action<object, EventArgs, Space> method_to_call)
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
