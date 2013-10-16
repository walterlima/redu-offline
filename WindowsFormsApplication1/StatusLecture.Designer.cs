namespace ReduOffline
{
    partial class StatusLecture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusLecture));
            this.main_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_status_link = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pic_user = new System.Windows.Forms.PictureBox();
            this.lbl_status_action = new System.Windows.Forms.Label();
            this.lbl_status_link_action = new System.Windows.Forms.LinkLabel();
            this.pn_to_add_answer = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_txt = new System.Windows.Forms.Label();
            this.pn_answer_container = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lnk_responder = new System.Windows.Forms.LinkLabel();
            this.main_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).BeginInit();
            this.pn_to_add_answer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.AutoSize = true;
            this.main_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.main_panel.BackColor = System.Drawing.Color.White;
            this.main_panel.Controls.Add(this.panel1);
            this.main_panel.Controls.Add(this.panel2);
            this.main_panel.Controls.Add(this.pn_to_add_answer);
            this.main_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.main_panel.Location = new System.Drawing.Point(1, 0);
            this.main_panel.MaximumSize = new System.Drawing.Size(595, 0);
            this.main_panel.MinimumSize = new System.Drawing.Size(595, 2);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(595, 166);
            this.main_panel.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lbl_status_link);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MaximumSize = new System.Drawing.Size(595, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 14);
            this.panel1.TabIndex = 5;
            // 
            // lbl_status_link
            // 
            this.lbl_status_link.AutoSize = true;
            this.lbl_status_link.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status_link.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_status_link.Location = new System.Drawing.Point(6, 0);
            this.lbl_status_link.MaximumSize = new System.Drawing.Size(595, 0);
            this.lbl_status_link.Name = "lbl_status_link";
            this.lbl_status_link.Size = new System.Drawing.Size(221, 14);
            this.lbl_status_link.TabIndex = 0;
            this.lbl_status_link.Text = "Ava > Course > Space > Subject > Lecture";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.pic_user);
            this.panel2.Controls.Add(this.lbl_status_action);
            this.panel2.Controls.Add(this.lbl_status_link_action);
            this.panel2.Location = new System.Drawing.Point(3, 23);
            this.panel2.MaximumSize = new System.Drawing.Size(595, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(157, 37);
            this.panel2.TabIndex = 6;
            // 
            // pic_user
            // 
            this.pic_user.Location = new System.Drawing.Point(6, 2);
            this.pic_user.Name = "pic_user";
            this.pic_user.Size = new System.Drawing.Size(32, 32);
            this.pic_user.TabIndex = 1;
            this.pic_user.TabStop = false;
            // 
            // lbl_status_action
            // 
            this.lbl_status_action.AutoSize = true;
            this.lbl_status_action.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status_action.Location = new System.Drawing.Point(45, 2);
            this.lbl_status_action.Name = "lbl_status_action";
            this.lbl_status_action.Size = new System.Drawing.Size(109, 14);
            this.lbl_status_action.TabIndex = 2;
            this.lbl_status_action.Text = "Fulano fez algo em :";
            // 
            // lbl_status_link_action
            // 
            this.lbl_status_link_action.AutoSize = true;
            this.lbl_status_link_action.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status_link_action.Location = new System.Drawing.Point(45, 17);
            this.lbl_status_link_action.Name = "lbl_status_link_action";
            this.lbl_status_link_action.Size = new System.Drawing.Size(95, 14);
            this.lbl_status_link_action.TabIndex = 3;
            this.lbl_status_link_action.TabStop = true;
            this.lbl_status_link_action.Text = "Nome da Lecture";
            // 
            // pn_to_add_answer
            // 
            this.pn_to_add_answer.AutoSize = true;
            this.pn_to_add_answer.Controls.Add(this.lbl_txt);
            this.pn_to_add_answer.Controls.Add(this.pn_answer_container);
            this.pn_to_add_answer.Controls.Add(this.panel3);
            this.pn_to_add_answer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_to_add_answer.Location = new System.Drawing.Point(3, 66);
            this.pn_to_add_answer.MaximumSize = new System.Drawing.Size(590, 0);
            this.pn_to_add_answer.MinimumSize = new System.Drawing.Size(590, 0);
            this.pn_to_add_answer.Name = "pn_to_add_answer";
            this.pn_to_add_answer.Size = new System.Drawing.Size(590, 97);
            this.pn_to_add_answer.TabIndex = 7;
            // 
            // lbl_txt
            // 
            this.lbl_txt.AutoSize = true;
            this.lbl_txt.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_txt.Location = new System.Drawing.Point(3, 0);
            this.lbl_txt.MaximumSize = new System.Drawing.Size(585, 0);
            this.lbl_txt.Name = "lbl_txt";
            this.lbl_txt.Size = new System.Drawing.Size(584, 70);
            this.lbl_txt.TabIndex = 4;
            this.lbl_txt.Text = resources.GetString("lbl_txt.Text");
            // 
            // pn_answer_container
            // 
            this.pn_answer_container.AutoSize = true;
            this.pn_answer_container.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_answer_container.Location = new System.Drawing.Point(3, 73);
            this.pn_answer_container.MaximumSize = new System.Drawing.Size(585, 0);
            this.pn_answer_container.MinimumSize = new System.Drawing.Size(585, 0);
            this.pn_answer_container.Name = "pn_answer_container";
            this.pn_answer_container.Size = new System.Drawing.Size(585, 0);
            this.pn_answer_container.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(3, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(584, 15);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::ReduOffline.images.responder;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.Controls.Add(this.lnk_responder);
            this.panel4.Location = new System.Drawing.Point(510, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(71, 17);
            this.panel4.TabIndex = 0;
            // 
            // lnk_responder
            // 
            this.lnk_responder.AutoSize = true;
            this.lnk_responder.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnk_responder.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnk_responder.Location = new System.Drawing.Point(14, 2);
            this.lnk_responder.Name = "lnk_responder";
            this.lnk_responder.Size = new System.Drawing.Size(54, 12);
            this.lnk_responder.TabIndex = 0;
            this.lnk_responder.TabStop = true;
            this.lnk_responder.Text = "responder";
            this.lnk_responder.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnk_responder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_responder_LinkClicked);
            // 
            // StatusLecture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.main_panel);
            this.Name = "StatusLecture";
            this.Size = new System.Drawing.Size(599, 169);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).EndInit();
            this.pn_to_add_answer.ResumeLayout(false);
            this.pn_to_add_answer.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbl_status_link_action;
        private System.Windows.Forms.Label lbl_status_action;
        private System.Windows.Forms.PictureBox pic_user;
        private System.Windows.Forms.Label lbl_status_link;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel main_panel;
        private System.Windows.Forms.FlowLayoutPanel pn_to_add_answer;
        private System.Windows.Forms.Label lbl_txt;
        private System.Windows.Forms.FlowLayoutPanel pn_answer_container;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel lnk_responder;
    }
}
