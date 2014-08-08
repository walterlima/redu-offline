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
    partial class ModulosViewer
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
            this.pn_modulos = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_nome_disc = new System.Windows.Forms.Label();
            this.pn_descr = new System.Windows.Forms.Panel();
            this.lbl_descr = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_conteudo = new System.Windows.Forms.Label();
            this.pn_descr.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_modulos
            // 
            this.pn_modulos.AutoSize = true;
            this.pn_modulos.BackColor = System.Drawing.Color.Transparent;
            this.pn_modulos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_modulos.Location = new System.Drawing.Point(3, 51);
            this.pn_modulos.MaximumSize = new System.Drawing.Size(565, 0);
            this.pn_modulos.MinimumSize = new System.Drawing.Size(565, 0);
            this.pn_modulos.Name = "pn_modulos";
            this.pn_modulos.Size = new System.Drawing.Size(565, 0);
            this.pn_modulos.TabIndex = 0;
            // 
            // lbl_nome_disc
            // 
            this.lbl_nome_disc.AutoSize = true;
            this.lbl_nome_disc.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_disc.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_nome_disc.Location = new System.Drawing.Point(4, 4);
            this.lbl_nome_disc.Name = "lbl_nome_disc";
            this.lbl_nome_disc.Size = new System.Drawing.Size(324, 43);
            this.lbl_nome_disc.TabIndex = 1;
            this.lbl_nome_disc.Text = "Nome da Disciplina";
            // 
            // pn_descr
            // 
            this.pn_descr.AutoSize = true;
            this.pn_descr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pn_descr.Controls.Add(this.lbl_descr);
            this.pn_descr.Location = new System.Drawing.Point(3, 3);
            this.pn_descr.MaximumSize = new System.Drawing.Size(570, 0);
            this.pn_descr.MinimumSize = new System.Drawing.Size(570, 0);
            this.pn_descr.Name = "pn_descr";
            this.pn_descr.Size = new System.Drawing.Size(570, 17);
            this.pn_descr.TabIndex = 2;
            // 
            // lbl_descr
            // 
            this.lbl_descr.AutoSize = true;
            this.lbl_descr.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descr.Location = new System.Drawing.Point(3, 2);
            this.lbl_descr.MaximumSize = new System.Drawing.Size(565, 0);
            this.lbl_descr.Name = "lbl_descr";
            this.lbl_descr.Size = new System.Drawing.Size(136, 15);
            this.lbl_descr.TabIndex = 0;
            this.lbl_descr.Text = "Descrição da disciplina";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.pn_descr);
            this.flowLayoutPanel2.Controls.Add(this.lbl_conteudo);
            this.flowLayoutPanel2.Controls.Add(this.pn_modulos);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(21, 50);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(576, 85);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // lbl_conteudo
            // 
            this.lbl_conteudo.AutoSize = true;
            this.lbl_conteudo.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_conteudo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_conteudo.Location = new System.Drawing.Point(3, 23);
            this.lbl_conteudo.Name = "lbl_conteudo";
            this.lbl_conteudo.Size = new System.Drawing.Size(99, 25);
            this.lbl_conteudo.TabIndex = 3;
            this.lbl_conteudo.Text = "Conteúdo";
            // 
            // ModulosViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_nome_disc);
            this.Controls.Add(this.flowLayoutPanel2);
            this.MaximumSize = new System.Drawing.Size(595, 0);
            this.MinimumSize = new System.Drawing.Size(595, 0);
            this.Name = "ModulosViewer";
            this.Size = new System.Drawing.Size(595, 138);
            this.pn_descr.ResumeLayout(false);
            this.pn_descr.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pn_modulos;
        private System.Windows.Forms.Label lbl_nome_disc;
        private System.Windows.Forms.Panel pn_descr;
        private System.Windows.Forms.Label lbl_descr;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lbl_conteudo;
    }
}
