namespace ReduOffline
{
    partial class AnswerViewer
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
            this.pic_user = new System.Windows.Forms.PictureBox();
            this.lbl_nome_user = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_resposta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_user
            // 
            this.pic_user.Location = new System.Drawing.Point(6, 6);
            this.pic_user.Name = "pic_user";
            this.pic_user.Size = new System.Drawing.Size(32, 32);
            this.pic_user.TabIndex = 0;
            this.pic_user.TabStop = false;
            // 
            // lbl_nome_user
            // 
            this.lbl_nome_user.AutoSize = true;
            this.lbl_nome_user.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_user.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_nome_user.Location = new System.Drawing.Point(3, 0);
            this.lbl_nome_user.Name = "lbl_nome_user";
            this.lbl_nome_user.Size = new System.Drawing.Size(98, 15);
            this.lbl_nome_user.TabIndex = 1;
            this.lbl_nome_user.Text = "Fulano da Silva";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbl_nome_user);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(39, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(541, 18);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(107, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "respondeu:";
            // 
            // lbl_resposta
            // 
            this.lbl_resposta.AutoSize = true;
            this.lbl_resposta.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_resposta.Location = new System.Drawing.Point(42, 30);
            this.lbl_resposta.MaximumSize = new System.Drawing.Size(543, 0);
            this.lbl_resposta.Name = "lbl_resposta";
            this.lbl_resposta.Size = new System.Drawing.Size(98, 15);
            this.lbl_resposta.TabIndex = 3;
            this.lbl_resposta.Text = "Meu Comentário";
            // 
            // AnswerViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_resposta);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pic_user);
            this.MaximumSize = new System.Drawing.Size(585, 0);
            this.MinimumSize = new System.Drawing.Size(585, 0);
            this.Name = "AnswerViewer";
            this.Size = new System.Drawing.Size(585, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_user;
        private System.Windows.Forms.Label lbl_nome_user;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_resposta;
    }
}
