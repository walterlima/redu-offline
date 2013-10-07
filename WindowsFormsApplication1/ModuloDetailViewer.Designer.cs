namespace ReduOffline
{
    partial class ModuloDetailViewer
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
            this.lbl_nome_mod = new System.Windows.Forms.Label();
            this.lbl_descr_mod = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pn_aulas = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_nome_mod
            // 
            this.lbl_nome_mod.AutoSize = true;
            this.lbl_nome_mod.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_mod.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_nome_mod.Location = new System.Drawing.Point(42, 3);
            this.lbl_nome_mod.Name = "lbl_nome_mod";
            this.lbl_nome_mod.Size = new System.Drawing.Size(150, 22);
            this.lbl_nome_mod.TabIndex = 1;
            this.lbl_nome_mod.Text = "Nome do Módulo";
            // 
            // lbl_descr_mod
            // 
            this.lbl_descr_mod.AutoSize = true;
            this.lbl_descr_mod.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descr_mod.Location = new System.Drawing.Point(3, 0);
            this.lbl_descr_mod.MaximumSize = new System.Drawing.Size(515, 0);
            this.lbl_descr_mod.Name = "lbl_descr_mod";
            this.lbl_descr_mod.Size = new System.Drawing.Size(125, 15);
            this.lbl_descr_mod.TabIndex = 2;
            this.lbl_descr_mod.Text = "Descrição do módulo";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ReduOffline.images.aula_2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Location = new System.Drawing.Point(4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 20);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ReduOffline.images.livre;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(3, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 22);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(23, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Aulas";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lbl_descr_mod);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.pn_aulas);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(46, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(519, 87);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 26);
            this.panel3.TabIndex = 6;
            // 
            // pn_aulas
            // 
            this.pn_aulas.AutoSize = true;
            this.pn_aulas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_aulas.Location = new System.Drawing.Point(3, 50);
            this.pn_aulas.MaximumSize = new System.Drawing.Size(513, 0);
            this.pn_aulas.MinimumSize = new System.Drawing.Size(513, 0);
            this.pn_aulas.Name = "pn_aulas";
            this.pn_aulas.Size = new System.Drawing.Size(513, 0);
            this.pn_aulas.TabIndex = 7;
            // 
            // ModuloDetailViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbl_nome_mod);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(565, 0);
            this.MinimumSize = new System.Drawing.Size(565, 75);
            this.Name = "ModuloDetailViewer";
            this.Size = new System.Drawing.Size(565, 118);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_nome_mod;
        private System.Windows.Forms.Label lbl_descr_mod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel pn_aulas;
    }
}
