namespace ReduOffline
{
    partial class StatusUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusUser));
            this.main_panel = new System.Windows.Forms.Panel();
            this.lbl_txt = new System.Windows.Forms.Label();
            this.lbl_status_action = new System.Windows.Forms.Label();
            this.pic_user = new System.Windows.Forms.PictureBox();
            this.main_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).BeginInit();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.AutoSize = true;
            this.main_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.main_panel.BackColor = System.Drawing.Color.White;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.main_panel.Controls.Add(this.lbl_txt);
            this.main_panel.Controls.Add(this.lbl_status_action);
            this.main_panel.Controls.Add(this.pic_user);
            this.main_panel.Location = new System.Drawing.Point(1, 0);
            this.main_panel.MinimumSize = new System.Drawing.Size(595, 2);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(595, 116);
            this.main_panel.TabIndex = 9;
            // 
            // lbl_txt
            // 
            this.lbl_txt.AutoSize = true;
            this.lbl_txt.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_txt.Location = new System.Drawing.Point(6, 44);
            this.lbl_txt.MaximumSize = new System.Drawing.Size(585, 0);
            this.lbl_txt.Name = "lbl_txt";
            this.lbl_txt.Size = new System.Drawing.Size(584, 70);
            this.lbl_txt.TabIndex = 4;
            this.lbl_txt.Text = resources.GetString("lbl_txt.Text");
            // 
            // lbl_status_action
            // 
            this.lbl_status_action.AutoSize = true;
            this.lbl_status_action.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status_action.Location = new System.Drawing.Point(46, 6);
            this.lbl_status_action.Name = "lbl_status_action";
            this.lbl_status_action.Size = new System.Drawing.Size(109, 14);
            this.lbl_status_action.TabIndex = 2;
            this.lbl_status_action.Text = "Fulano fez algo em :";
            // 
            // pic_user
            // 
            this.pic_user.Location = new System.Drawing.Point(6, 6);
            this.pic_user.Name = "pic_user";
            this.pic_user.Size = new System.Drawing.Size(32, 32);
            this.pic_user.TabIndex = 1;
            this.pic_user.TabStop = false;
            // 
            // StatusUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.main_panel);
            this.Name = "StatusUser";
            this.Size = new System.Drawing.Size(599, 119);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Label lbl_txt;
        private System.Windows.Forms.Label lbl_status_action;
        private System.Windows.Forms.PictureBox pic_user;
    }
}
