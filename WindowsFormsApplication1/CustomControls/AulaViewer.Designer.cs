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
    partial class AulaViewer
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
            this.lbl_cardinal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_nome_aula = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_cardinal
            // 
            this.lbl_cardinal.AutoSize = true;
            this.lbl_cardinal.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardinal.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_cardinal.Location = new System.Drawing.Point(3, 4);
            this.lbl_cardinal.Name = "lbl_cardinal";
            this.lbl_cardinal.Size = new System.Drawing.Size(18, 15);
            this.lbl_cardinal.TabIndex = 0;
            this.lbl_cardinal.Text = "1.";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ReduOffline.images.aula;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(22, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(18, 23);
            this.panel1.TabIndex = 1;
            // 
            // lbl_nome_aula
            // 
            this.lbl_nome_aula.AutoSize = true;
            this.lbl_nome_aula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_nome_aula.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_aula.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_nome_aula.Location = new System.Drawing.Point(39, 5);
            this.lbl_nome_aula.Name = "lbl_nome_aula";
            this.lbl_nome_aula.Size = new System.Drawing.Size(84, 15);
            this.lbl_nome_aula.TabIndex = 2;
            this.lbl_nome_aula.Text = "Nome da Aula";
            // 
            // AulaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_nome_aula);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_cardinal);
            this.MaximumSize = new System.Drawing.Size(513, 25);
            this.MinimumSize = new System.Drawing.Size(513, 25);
            this.Name = "AulaViewer";
            this.Size = new System.Drawing.Size(513, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_cardinal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_nome_aula;
    }
}
