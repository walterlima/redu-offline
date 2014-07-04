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
    partial class DisciplinaViewer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnk_name_disciplina = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ReduOffline.images.modulo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(11, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 18);
            this.panel1.TabIndex = 0;
            // 
            // lnk_name_disciplina
            // 
            this.lnk_name_disciplina.AutoSize = true;
            this.lnk_name_disciplina.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnk_name_disciplina.Location = new System.Drawing.Point(29, 6);
            this.lnk_name_disciplina.Name = "lnk_name_disciplina";
            this.lnk_name_disciplina.Size = new System.Drawing.Size(98, 13);
            this.lnk_name_disciplina.TabIndex = 1;
            this.lnk_name_disciplina.TabStop = true;
            this.lnk_name_disciplina.Text = "Nome da Disciplina";
            this.lnk_name_disciplina.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            // 
            // DisciplinaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lnk_name_disciplina);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(500, 25);
            this.MinimumSize = new System.Drawing.Size(500, 25);
            this.Name = "DisciplinaViewer";
            this.Size = new System.Drawing.Size(500, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnk_name_disciplina;
    }
}
