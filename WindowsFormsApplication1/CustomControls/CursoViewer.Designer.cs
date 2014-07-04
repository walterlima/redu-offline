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
    partial class CursoViewer
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
            this.lbl_nome_curso = new System.Windows.Forms.Label();
            this.pn_disciplinas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lbl_nome_curso
            // 
            this.lbl_nome_curso.AutoSize = true;
            this.lbl_nome_curso.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_curso.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lbl_nome_curso.Location = new System.Drawing.Point(3, 1);
            this.lbl_nome_curso.Name = "lbl_nome_curso";
            this.lbl_nome_curso.Size = new System.Drawing.Size(120, 19);
            this.lbl_nome_curso.TabIndex = 1;
            this.lbl_nome_curso.Text = "Nome do Curso";
            // 
            // pn_disciplinas
            // 
            this.pn_disciplinas.AutoSize = true;
            this.pn_disciplinas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_disciplinas.Location = new System.Drawing.Point(20, 25);
            this.pn_disciplinas.MaximumSize = new System.Drawing.Size(505, 0);
            this.pn_disciplinas.MinimumSize = new System.Drawing.Size(505, 0);
            this.pn_disciplinas.Name = "pn_disciplinas";
            this.pn_disciplinas.Size = new System.Drawing.Size(505, 20);
            this.pn_disciplinas.TabIndex = 2;
            // 
            // CursoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pn_disciplinas);
            this.Controls.Add(this.lbl_nome_curso);
            this.MaximumSize = new System.Drawing.Size(545, 0);
            this.MinimumSize = new System.Drawing.Size(545, 0);
            this.Name = "CursoViewer";
            this.Size = new System.Drawing.Size(545, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_nome_curso;
        private System.Windows.Forms.FlowLayoutPanel pn_disciplinas;
    }
}
