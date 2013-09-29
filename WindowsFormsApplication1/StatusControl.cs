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
    public abstract partial class StatusControl : UserControl
    {
        public StatusControl()
        {
            InitializeComponent();
        }

        abstract public String Image_URL { get; set; }
        abstract public String Text_Status { get; set; }
        abstract public String Name_User { get; set; }
        
    }
}
