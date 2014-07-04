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
namespace ReduOffline
{
    partial class AvasViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_name_ava = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pn_cursos = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lbl_name_ava
            // 
            this.lbl_name_ava.AutoSize = true;
            this.lbl_name_ava.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name_ava.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_name_ava.Location = new System.Drawing.Point(39, 10);
            this.lbl_name_ava.Name = "lbl_name_ava";
            this.lbl_name_ava.Size = new System.Drawing.Size(106, 19);
            this.lbl_name_ava.TabIndex = 2;
            this.lbl_name_ava.Text = "Nome da AVA";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ReduOffline.images.logo_redu;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(33, 32);
            this.panel2.TabIndex = 1;
            // 
            // pn_cursos
            // 
            this.pn_cursos.AutoSize = true;
            this.pn_cursos.BackColor = System.Drawing.Color.Transparent;
            this.pn_cursos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_cursos.Location = new System.Drawing.Point(40, 35);
            this.pn_cursos.MaximumSize = new System.Drawing.Size(550, 0);
            this.pn_cursos.MinimumSize = new System.Drawing.Size(550, 0);
            this.pn_cursos.Name = "pn_cursos";
            this.pn_cursos.Size = new System.Drawing.Size(550, 0);
            this.pn_cursos.TabIndex = 3;
            // 
            // AvasViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pn_cursos);
            this.Controls.Add(this.lbl_name_ava);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(595, 0);
            this.MinimumSize = new System.Drawing.Size(595, 0);
            this.Name = "AvasViewer";
            this.Size = new System.Drawing.Size(595, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_name_ava;
        private System.Windows.Forms.FlowLayoutPanel pn_cursos;
    }
}
