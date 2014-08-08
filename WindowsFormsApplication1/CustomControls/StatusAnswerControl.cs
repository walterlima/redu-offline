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
    public partial class StatusAnswerControl : UserControl
    {
        public StatusAnswerControl()
        {
            InitializeComponent();
        }

        public Status Responding_Status
        {
            get;
            set;
        }        

        public String Text_Answer
        {
            get { return txt_resposta.Text; }
        }

        public void load_events(Action<object, EventArgs, Tuple<Status,String>> method_to_call_enviar, Action<object, EventArgs> method_to_call_cancelar)
        {            
            EventArgs event_args = new EventArgs();            
            btn_enviar.Click += new EventHandler((sender, e) => method_to_call_enviar(sender, e, new Tuple<Status,String>(Responding_Status,Text_Answer)));
            btn_cancelar.Click += new EventHandler(method_to_call_cancelar);
        }
    }
}
