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

        public void load_aulas(List<Lecture> aulas, Action<object, EventArgs, string> method_to_call)
        {
            int i = 1;
            foreach (Lecture l in aulas)
            {
                AulaViewer aula_control = new AulaViewer();
                aula_control.Nome_Aula = l.Name;
                aula_control.Ordem = i+"";
                aula_control.Lecture_Id = l.Id;
                i++;
                aula_control.load_events(method_to_call);
                pn_aulas.Controls.Add(aula_control);
            }
        }
    }
}
