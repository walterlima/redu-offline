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

        public void load_modulos(List<Subject> modulos, Action<object, EventArgs, string> method_to_call)
        {
            foreach (Subject s in modulos)
            {
                ModuloDetailViewer modulo_control = new ModuloDetailViewer();
                modulo_control.Nome_Modulo = s.Name;
                modulo_control.Descricao_Modeulo = s.Description;
                modulo_control.load_aulas(s.Lectures, method_to_call);
                pn_modulos.Controls.Add(modulo_control);
            }
        }
    }
}
