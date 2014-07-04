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

        public void load_disciplinas(List<Space> spaces, Action<object, EventArgs, Space> method_to_call)
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
