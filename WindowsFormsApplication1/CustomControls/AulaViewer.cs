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

namespace ReduOffline
{
    public partial class AulaViewer : UserControl
    {

        private String _lecture_id;        

        public AulaViewer()
        {
            InitializeComponent();
        }

        public String Nome_Aula
        {
            get { return lbl_nome_aula.Text; }
            set { lbl_nome_aula.Text = value; }
        }

        public String Ordem
        {
            get { return lbl_cardinal.Text; }
            set { lbl_cardinal.Text = value + "."; }
        }

        public String Lecture_Id
        {
            get { return _lecture_id; }
            set { _lecture_id = value; }
        }

        public void load_events(Action<object, EventArgs, String> method_to_call)
        {
            EventArgs event_args = new EventArgs();
            lbl_nome_aula.Click += new EventHandler((sender, e) => method_to_call(sender, e, _lecture_id));            
        }
    }
}
