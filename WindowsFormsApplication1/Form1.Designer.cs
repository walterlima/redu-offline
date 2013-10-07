namespace ReduOffline
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loginTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_pin = new System.Windows.Forms.Button();
            this.pinTxt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_nome_user = new System.Windows.Forms.Label();
            this.bw_load = new System.ComponentModel.BackgroundWorker();
            this.pn_post_status = new System.Windows.Forms.Panel();
            this.btn_post_status = new System.Windows.Forms.Button();
            this.txt_post_status = new System.Windows.Forms.TextBox();
            this.pn_load = new System.Windows.Forms.Panel();
            this.pn_wall = new System.Windows.Forms.Panel();
            this.pn_avas = new System.Windows.Forms.FlowLayoutPanel();
            this.pn_main_wall = new System.Windows.Forms.FlowLayoutPanel();
            this.bw_post_user = new System.ComponentModel.BackgroundWorker();
            this.btn_update = new System.Windows.Forms.Button();
            this.pn_disciplina = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_user = new System.Windows.Forms.PictureBox();
            this.pn_menu_avas = new System.Windows.Forms.Panel();
            this.pn_menu_mural = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pn_post_status.SuspendLayout();
            this.pn_load.SuspendLayout();
            this.pn_wall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).BeginInit();
            this.SuspendLayout();
            // 
            // loginTxt
            // 
            this.loginTxt.Location = new System.Drawing.Point(106, 58);
            this.loginTxt.Name = "loginTxt";
            this.loginTxt.Size = new System.Drawing.Size(100, 20);
            this.loginTxt.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_pin);
            this.panel1.Controls.Add(this.pinTxt);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(370, 284);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 153);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.MaximumSize = new System.Drawing.Size(280, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Você foi redirecionado para o Navegador, insira aqui o PIN de autorização";
            // 
            // btn_pin
            // 
            this.btn_pin.Location = new System.Drawing.Point(107, 98);
            this.btn_pin.Name = "btn_pin";
            this.btn_pin.Size = new System.Drawing.Size(75, 23);
            this.btn_pin.TabIndex = 1;
            this.btn_pin.Text = "Confirmar";
            this.btn_pin.UseVisualStyleBackColor = true;
            this.btn_pin.Click += new System.EventHandler(this.button2_Click);
            // 
            // pinTxt
            // 
            this.pinTxt.Location = new System.Drawing.Point(92, 67);
            this.pinTxt.Name = "pinTxt";
            this.pinTxt.Size = new System.Drawing.Size(100, 20);
            this.pinTxt.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.loginTxt);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(354, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 146);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bem vindo ao REDU, por favor informe o seu login";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_nome_user);
            this.panel3.Controls.Add(this.pic_user);
            this.panel3.Location = new System.Drawing.Point(12, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 191);
            this.panel3.TabIndex = 7;
            // 
            // lbl_nome_user
            // 
            this.lbl_nome_user.AutoSize = true;
            this.lbl_nome_user.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_user.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_nome_user.Location = new System.Drawing.Point(100, 166);
            this.lbl_nome_user.Name = "lbl_nome_user";
            this.lbl_nome_user.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_nome_user.Size = new System.Drawing.Size(67, 15);
            this.lbl_nome_user.TabIndex = 1;
            this.lbl_nome_user.Text = "nome_user";
            this.lbl_nome_user.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bw_load
            // 
            this.bw_load.WorkerReportsProgress = true;
            this.bw_load.WorkerSupportsCancellation = true;
            this.bw_load.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_load_DoWork);
            this.bw_load.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_load_ProgressChanged);
            this.bw_load.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_load_RunWorkerCompleted);
            // 
            // pn_post_status
            // 
            this.pn_post_status.BackColor = System.Drawing.Color.White;
            this.pn_post_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_post_status.Controls.Add(this.pictureBox1);
            this.pn_post_status.Controls.Add(this.btn_post_status);
            this.pn_post_status.Controls.Add(this.txt_post_status);
            this.pn_post_status.Location = new System.Drawing.Point(237, 19);
            this.pn_post_status.Name = "pn_post_status";
            this.pn_post_status.Size = new System.Drawing.Size(590, 83);
            this.pn_post_status.TabIndex = 9;
            // 
            // btn_post_status
            // 
            this.btn_post_status.Location = new System.Drawing.Point(496, 57);
            this.btn_post_status.Name = "btn_post_status";
            this.btn_post_status.Size = new System.Drawing.Size(75, 23);
            this.btn_post_status.TabIndex = 1;
            this.btn_post_status.Text = "Publicar";
            this.btn_post_status.UseVisualStyleBackColor = true;
            this.btn_post_status.Click += new System.EventHandler(this.btn_post_status_Click);
            // 
            // txt_post_status
            // 
            this.txt_post_status.Location = new System.Drawing.Point(3, 3);
            this.txt_post_status.MaxLength = 800;
            this.txt_post_status.Multiline = true;
            this.txt_post_status.Name = "txt_post_status";
            this.txt_post_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_post_status.Size = new System.Drawing.Size(584, 52);
            this.txt_post_status.TabIndex = 0;
            this.txt_post_status.Text = "Compatilhe conosco seus pensamentos";
            // 
            // pn_load
            // 
            this.pn_load.AutoScroll = true;
            this.pn_load.BackColor = System.Drawing.Color.White;
            this.pn_load.Controls.Add(this.panel1);
            this.pn_load.Controls.Add(this.panel2);
            this.pn_load.Controls.Add(this.pictureBox3);
            this.pn_load.Location = new System.Drawing.Point(0, -1);
            this.pn_load.Name = "pn_load";
            this.pn_load.Size = new System.Drawing.Size(1008, 690);
            this.pn_load.TabIndex = 10;
            // 
            // pn_wall
            // 
            this.pn_wall.AutoScroll = true;
            this.pn_wall.Controls.Add(this.pn_disciplina);
            this.pn_wall.Controls.Add(this.pn_avas);
            this.pn_wall.Controls.Add(this.pn_main_wall);
            this.pn_wall.Location = new System.Drawing.Point(227, 119);
            this.pn_wall.MinimumSize = new System.Drawing.Size(0, 565);
            this.pn_wall.Name = "pn_wall";
            this.pn_wall.Size = new System.Drawing.Size(781, 565);
            this.pn_wall.TabIndex = 5;
            // 
            // pn_avas
            // 
            this.pn_avas.AutoSize = true;
            this.pn_avas.BackColor = System.Drawing.Color.White;
            this.pn_avas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_avas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_avas.Location = new System.Drawing.Point(3, 3);
            this.pn_avas.MinimumSize = new System.Drawing.Size(610, 560);
            this.pn_avas.Name = "pn_avas";
            this.pn_avas.Size = new System.Drawing.Size(610, 560);
            this.pn_avas.TabIndex = 12;
            this.pn_avas.Visible = false;
            // 
            // pn_main_wall
            // 
            this.pn_main_wall.AutoSize = true;
            this.pn_main_wall.BackColor = System.Drawing.Color.White;
            this.pn_main_wall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_main_wall.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.pn_main_wall.Location = new System.Drawing.Point(3, 3);
            this.pn_main_wall.MinimumSize = new System.Drawing.Size(610, 560);
            this.pn_main_wall.Name = "pn_main_wall";
            this.pn_main_wall.Size = new System.Drawing.Size(610, 560);
            this.pn_main_wall.TabIndex = 11;
            // 
            // bw_post_user
            // 
            this.bw_post_user.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_post_user_DoWork);
            this.bw_post_user.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_post_user_RunWorkerCompleted);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(925, 38);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(20, 23);
            this.btn_update.TabIndex = 11;
            this.btn_update.Text = "O";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // pn_disciplina
            // 
            this.pn_disciplina.AutoSize = true;
            this.pn_disciplina.BackColor = System.Drawing.Color.White;
            this.pn_disciplina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_disciplina.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_disciplina.Location = new System.Drawing.Point(3, 3);
            this.pn_disciplina.MinimumSize = new System.Drawing.Size(610, 560);
            this.pn_disciplina.Name = "pn_disciplina";
            this.pn_disciplina.Size = new System.Drawing.Size(610, 560);
            this.pn_disciplina.TabIndex = 13;
            this.pn_disciplina.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = global::ReduOffline.images.loading_blue;
            this.pictureBox3.InitialImage = global::ReduOffline.images.loading_blue;
            this.pictureBox3.Location = new System.Drawing.Point(448, 300);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 128);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ReduOffline.images.loading_blue_24;
            this.pictureBox1.InitialImage = global::ReduOffline.images.loading_blue_24;
            this.pictureBox1.Location = new System.Drawing.Point(455, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pic_user
            // 
            this.pic_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_user.Location = new System.Drawing.Point(8, 3);
            this.pic_user.Name = "pic_user";
            this.pic_user.Size = new System.Drawing.Size(160, 160);
            this.pic_user.TabIndex = 0;
            this.pic_user.TabStop = false;
            // 
            // pn_menu_avas
            // 
            this.pn_menu_avas.BackgroundImage = global::ReduOffline.images.ambientes;
            this.pn_menu_avas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_menu_avas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_menu_avas.Location = new System.Drawing.Point(32, 290);
            this.pn_menu_avas.Name = "pn_menu_avas";
            this.pn_menu_avas.Size = new System.Drawing.Size(192, 38);
            this.pn_menu_avas.TabIndex = 13;
            this.pn_menu_avas.Click += new System.EventHandler(this.pn_menu_avas_Click);
            // 
            // pn_menu_mural
            // 
            this.pn_menu_mural.BackgroundImage = global::ReduOffline.images.visao_geral;
            this.pn_menu_mural.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_menu_mural.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_menu_mural.Location = new System.Drawing.Point(32, 238);
            this.pn_menu_mural.Name = "pn_menu_mural";
            this.pn_menu_mural.Size = new System.Drawing.Size(192, 36);
            this.pn_menu_mural.TabIndex = 12;
            this.pn_menu_mural.Click += new System.EventHandler(this.pn_menu_mural_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 690);
            this.Controls.Add(this.pn_load);
            this.Controls.Add(this.pn_post_status);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pn_wall);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.pn_menu_avas);
            this.Controls.Add(this.pn_menu_mural);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Redu OFFLine";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pn_post_status.ResumeLayout(false);
            this.pn_post_status.PerformLayout();
            this.pn_load.ResumeLayout(false);
            this.pn_wall.ResumeLayout(false);
            this.pn_wall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox loginTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_pin;
        private System.Windows.Forms.TextBox pinTxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pic_user;
        private System.ComponentModel.BackgroundWorker bw_load;
        private System.Windows.Forms.Panel pn_post_status;
        private System.Windows.Forms.Button btn_post_status;
        private System.Windows.Forms.TextBox txt_post_status;
        private System.Windows.Forms.Panel pn_load;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pn_wall;
        private System.Windows.Forms.FlowLayoutPanel pn_main_wall;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bw_post_user;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label lbl_nome_user;
        private System.Windows.Forms.Panel pn_menu_mural;
        private System.Windows.Forms.Panel pn_menu_avas;
        private System.Windows.Forms.FlowLayoutPanel pn_avas;
        private System.Windows.Forms.FlowLayoutPanel pn_disciplina;
    }
}

