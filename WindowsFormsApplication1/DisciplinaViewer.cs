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

        public void load_event(Action<object, EventArgs, Space> method_to_call)
        {
            lnk_name_disciplina.Click += new EventHandler((sender, e) => method_to_call(sender, e, Disciplina));
        }
    }
}
