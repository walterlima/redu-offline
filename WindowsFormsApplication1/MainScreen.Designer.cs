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
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.loginTxt = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.pn_pin = new System.Windows.Forms.Panel();
            this.lbl_pin = new System.Windows.Forms.Label();
            this.btn_pin = new System.Windows.Forms.Button();
            this.pinTxt = new System.Windows.Forms.TextBox();
            this.pn_login = new System.Windows.Forms.Panel();
            this.lbl_login = new System.Windows.Forms.Label();
            this.pn_user_picture = new System.Windows.Forms.Panel();
            this.lbl_nome_user = new System.Windows.Forms.Label();
            this.bw_load = new System.ComponentModel.BackgroundWorker();
            this.pn_load = new System.Windows.Forms.Panel();
            this.pn_wall = new System.Windows.Forms.Panel();
            this.pn_lecture_or_space_feed = new System.Windows.Forms.FlowLayoutPanel();
            this.pn_disciplina = new System.Windows.Forms.FlowLayoutPanel();
            this.pn_avas = new System.Windows.Forms.FlowLayoutPanel();
            this.pn_main_wall = new System.Windows.Forms.FlowLayoutPanel();
            this.bw_post_user = new System.ComponentModel.BackgroundWorker();
            this.bw_reply_status = new System.ComponentModel.BackgroundWorker();
            this.pic_big_load = new System.Windows.Forms.PictureBox();
            this.pn_notification = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pn_update = new System.Windows.Forms.Panel();
            this.lbl_notif = new System.Windows.Forms.Label();
            this.pn_menu_geral = new System.Windows.Forms.Panel();
            this.pn_menu_avas = new System.Windows.Forms.Panel();
            this.pn_post_status = new System.Windows.Forms.Panel();
            this.pic_small_load = new System.Windows.Forms.PictureBox();
            this.btn_post_status = new System.Windows.Forms.Button();
            this.txt_post_status = new System.Windows.Forms.TextBox();
            this.pic_user = new System.Windows.Forms.PictureBox();
            this.pn_menu_mural = new System.Windows.Forms.Panel();
            this.pn_more_status = new System.Windows.Forms.Panel();
            this.pn_notif_hidden = new System.Windows.Forms.Panel();
            this.pn_click_hide_notf = new System.Windows.Forms.Panel();
            this.pn_pin.SuspendLayout();
            this.pn_login.SuspendLayout();
            this.pn_user_picture.SuspendLayout();
            this.pn_load.SuspendLayout();
            this.pn_wall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_big_load)).BeginInit();
            this.pn_notification.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pn_post_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_small_load)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).BeginInit();
            this.SuspendLayout();
            // 
            // loginTxt
            // 
            this.loginTxt.Location = new System.Drawing.Point(106, 58);
            this.loginTxt.Name = "loginTxt";
            this.loginTxt.Size = new System.Drawing.Size(100, 20);
            this.loginTxt.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(118, 97);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // pn_pin
            // 
            this.pn_pin.Controls.Add(this.lbl_pin);
            this.pn_pin.Controls.Add(this.btn_pin);
            this.pn_pin.Controls.Add(this.pinTxt);
            this.pn_pin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pn_pin.Location = new System.Drawing.Point(370, 284);
            this.pn_pin.Name = "pn_pin";
            this.pn_pin.Size = new System.Drawing.Size(282, 153);
            this.pn_pin.TabIndex = 3;
            this.pn_pin.Visible = false;
            // 
            // lbl_pin
            // 
            this.lbl_pin.AutoSize = true;
            this.lbl_pin.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pin.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_pin.Location = new System.Drawing.Point(15, 17);
            this.lbl_pin.MaximumSize = new System.Drawing.Size(280, 0);
            this.lbl_pin.Name = "lbl_pin";
            this.lbl_pin.Size = new System.Drawing.Size(266, 32);
            this.lbl_pin.TabIndex = 2;
            this.lbl_pin.Text = "Você foi redirecionado para o Navegador, insira aqui o PIN de autorização";
            // 
            // btn_pin
            // 
            this.btn_pin.Location = new System.Drawing.Point(107, 98);
            this.btn_pin.Name = "btn_pin";
            this.btn_pin.Size = new System.Drawing.Size(75, 23);
            this.btn_pin.TabIndex = 1;
            this.btn_pin.Text = "Confirmar";
            this.btn_pin.UseVisualStyleBackColor = true;
            this.btn_pin.Click += new System.EventHandler(this.btn_pin_Click);
            // 
            // pinTxt
            // 
            this.pinTxt.Location = new System.Drawing.Point(92, 67);
            this.pinTxt.Name = "pinTxt";
            this.pinTxt.Size = new System.Drawing.Size(100, 20);
            this.pinTxt.TabIndex = 0;
            // 
            // pn_login
            // 
            this.pn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_login.Controls.Add(this.lbl_login);
            this.pn_login.Controls.Add(this.loginTxt);
            this.pn_login.Controls.Add(this.btn_login);
            this.pn_login.Location = new System.Drawing.Point(348, 291);
            this.pn_login.Name = "pn_login";
            this.pn_login.Size = new System.Drawing.Size(326, 146);
            this.pn_login.TabIndex = 4;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_login.Location = new System.Drawing.Point(6, 22);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(317, 16);
            this.lbl_login.TabIndex = 3;
            this.lbl_login.Text = "Bem vindo ao REDU, por favor informe o seu login";
            // 
            // pn_user_picture
            // 
            this.pn_user_picture.Controls.Add(this.lbl_nome_user);
            this.pn_user_picture.Controls.Add(this.pic_user);
            this.pn_user_picture.Location = new System.Drawing.Point(43, 19);
            this.pn_user_picture.Name = "pn_user_picture";
            this.pn_user_picture.Size = new System.Drawing.Size(176, 191);
            this.pn_user_picture.TabIndex = 7;
            // 
            // lbl_nome_user
            // 
            this.lbl_nome_user.AutoSize = true;
            this.lbl_nome_user.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_user.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl_nome_user.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_nome_user.Location = new System.Drawing.Point(100, 166);
            this.lbl_nome_user.Name = "lbl_nome_user";
            this.lbl_nome_user.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_nome_user.Size = new System.Drawing.Size(73, 15);
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
            // pn_load
            // 
            this.pn_load.AutoScroll = true;
            this.pn_load.BackColor = System.Drawing.Color.White;
            this.pn_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_load.Controls.Add(this.pn_login);
            this.pn_load.Controls.Add(this.pn_pin);
            this.pn_load.Controls.Add(this.pic_big_load);
            this.pn_load.Location = new System.Drawing.Point(-1, 0);
            this.pn_load.Name = "pn_load";
            this.pn_load.Size = new System.Drawing.Size(1009, 691);
            this.pn_load.TabIndex = 10;
            // 
            // pn_wall
            // 
            this.pn_wall.AutoScroll = true;
            this.pn_wall.Controls.Add(this.pn_more_status);
            this.pn_wall.Controls.Add(this.pn_lecture_or_space_feed);
            this.pn_wall.Controls.Add(this.pn_disciplina);
            this.pn_wall.Controls.Add(this.pn_avas);
            this.pn_wall.Controls.Add(this.pn_main_wall);
            this.pn_wall.Location = new System.Drawing.Point(264, 119);
            this.pn_wall.MinimumSize = new System.Drawing.Size(0, 565);
            this.pn_wall.Name = "pn_wall";
            this.pn_wall.Size = new System.Drawing.Size(744, 565);
            this.pn_wall.TabIndex = 0;
            // 
            // pn_lecture_or_space_feed
            // 
            this.pn_lecture_or_space_feed.AutoSize = true;
            this.pn_lecture_or_space_feed.BackColor = System.Drawing.Color.White;
            this.pn_lecture_or_space_feed.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_lecture_or_space_feed.Location = new System.Drawing.Point(3, 3);
            this.pn_lecture_or_space_feed.MinimumSize = new System.Drawing.Size(610, 560);
            this.pn_lecture_or_space_feed.Name = "pn_lecture_or_space_feed";
            this.pn_lecture_or_space_feed.Size = new System.Drawing.Size(610, 560);
            this.pn_lecture_or_space_feed.TabIndex = 14;
            this.pn_lecture_or_space_feed.Visible = false;
            this.pn_lecture_or_space_feed.Resize += new System.EventHandler(this.pn_wall_Resize);
            // 
            // pn_disciplina
            // 
            this.pn_disciplina.AutoSize = true;
            this.pn_disciplina.BackColor = System.Drawing.Color.White;
            this.pn_disciplina.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_disciplina.Location = new System.Drawing.Point(3, 3);
            this.pn_disciplina.MinimumSize = new System.Drawing.Size(610, 560);
            this.pn_disciplina.Name = "pn_disciplina";
            this.pn_disciplina.Size = new System.Drawing.Size(610, 560);
            this.pn_disciplina.TabIndex = 13;
            this.pn_disciplina.Visible = false;
            // 
            // pn_avas
            // 
            this.pn_avas.AutoSize = true;
            this.pn_avas.BackColor = System.Drawing.Color.White;
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
            this.pn_main_wall.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.pn_main_wall.Location = new System.Drawing.Point(3, 3);
            this.pn_main_wall.MinimumSize = new System.Drawing.Size(610, 560);
            this.pn_main_wall.Name = "pn_main_wall";
            this.pn_main_wall.Size = new System.Drawing.Size(610, 560);
            this.pn_main_wall.TabIndex = 11;
            this.pn_main_wall.Resize += new System.EventHandler(this.pn_wall_Resize);
            // 
            // bw_post_user
            // 
            this.bw_post_user.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_post_user_DoWork);
            this.bw_post_user.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_post_user_RunWorkerCompleted);
            // 
            // bw_reply_status
            // 
            this.bw_reply_status.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_reply_status_DoWork);
            this.bw_reply_status.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_reply_status_RunWorkerCompleted);
            // 
            // pic_big_load
            // 
            this.pic_big_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_big_load.Image = global::ReduOffline.images.loading_blue;
            this.pic_big_load.InitialImage = global::ReduOffline.images.loading_blue;
            this.pic_big_load.Location = new System.Drawing.Point(448, 300);
            this.pic_big_load.Name = "pic_big_load";
            this.pic_big_load.Size = new System.Drawing.Size(128, 128);
            this.pic_big_load.TabIndex = 0;
            this.pic_big_load.TabStop = false;
            // 
            // pn_notification
            // 
            this.pn_notification.AutoScroll = true;
            this.pn_notification.BackColor = System.Drawing.Color.Transparent;
            this.pn_notification.BackgroundImage = global::ReduOffline.images.notification;
            this.pn_notification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_notification.Controls.Add(this.pn_click_hide_notf);
            this.pn_notification.Controls.Add(this.panel1);
            this.pn_notification.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pn_notification.Location = new System.Drawing.Point(6, 591);
            this.pn_notification.Name = "pn_notification";
            this.pn_notification.Size = new System.Drawing.Size(255, 100);
            this.pn_notification.TabIndex = 14;
            this.pn_notification.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pn_update);
            this.panel1.Controls.Add(this.lbl_notif);
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.MaximumSize = new System.Drawing.Size(249, 60);
            this.panel1.MinimumSize = new System.Drawing.Size(249, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 60);
            this.panel1.TabIndex = 16;
            // 
            // pn_update
            // 
            this.pn_update.BackColor = System.Drawing.Color.Transparent;
            this.pn_update.BackgroundImage = global::ReduOffline.images.update;
            this.pn_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_update.Location = new System.Drawing.Point(222, 43);
            this.pn_update.Name = "pn_update";
            this.pn_update.Size = new System.Drawing.Size(18, 18);
            this.pn_update.TabIndex = 16;
            // 
            // lbl_notif
            // 
            this.lbl_notif.AutoSize = true;
            this.lbl_notif.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notif.ForeColor = System.Drawing.Color.Black;
            this.lbl_notif.Location = new System.Drawing.Point(0, 0);
            this.lbl_notif.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_notif.MaximumSize = new System.Drawing.Size(252, 0);
            this.lbl_notif.Name = "lbl_notif";
            this.lbl_notif.Size = new System.Drawing.Size(247, 30);
            this.lbl_notif.TabIndex = 0;
            this.lbl_notif.Text = "Há uma conexão com a internet disponível, deseja atualizar os dados?";
            // 
            // pn_menu_geral
            // 
            this.pn_menu_geral.BackColor = System.Drawing.Color.Transparent;
            this.pn_menu_geral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_menu_geral.BackgroundImage")));
            this.pn_menu_geral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_menu_geral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_menu_geral.Location = new System.Drawing.Point(93, 238);
            this.pn_menu_geral.Name = "pn_menu_geral";
            this.pn_menu_geral.Size = new System.Drawing.Size(174, 36);
            this.pn_menu_geral.TabIndex = 12;
            this.pn_menu_geral.Click += new System.EventHandler(this.pn_menu_mural_Click);
            // 
            // pn_menu_avas
            // 
            this.pn_menu_avas.BackColor = System.Drawing.Color.Transparent;
            this.pn_menu_avas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_menu_avas.BackgroundImage")));
            this.pn_menu_avas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_menu_avas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_menu_avas.Location = new System.Drawing.Point(92, 290);
            this.pn_menu_avas.Name = "pn_menu_avas";
            this.pn_menu_avas.Size = new System.Drawing.Size(175, 38);
            this.pn_menu_avas.TabIndex = 13;
            this.pn_menu_avas.Click += new System.EventHandler(this.pn_menu_avas_Click);
            // 
            // pn_post_status
            // 
            this.pn_post_status.BackColor = System.Drawing.Color.Transparent;
            this.pn_post_status.BackgroundImage = global::ReduOffline.images.comment;
            this.pn_post_status.Controls.Add(this.pic_small_load);
            this.pn_post_status.Controls.Add(this.btn_post_status);
            this.pn_post_status.Controls.Add(this.txt_post_status);
            this.pn_post_status.Location = new System.Drawing.Point(277, 9);
            this.pn_post_status.Name = "pn_post_status";
            this.pn_post_status.Size = new System.Drawing.Size(590, 100);
            this.pn_post_status.TabIndex = 9;
            // 
            // pic_small_load
            // 
            this.pic_small_load.Image = global::ReduOffline.images.loading_blue_24;
            this.pic_small_load.InitialImage = global::ReduOffline.images.loading_blue_24;
            this.pic_small_load.Location = new System.Drawing.Point(466, 70);
            this.pic_small_load.Name = "pic_small_load";
            this.pic_small_load.Size = new System.Drawing.Size(24, 24);
            this.pic_small_load.TabIndex = 2;
            this.pic_small_load.TabStop = false;
            this.pic_small_load.Visible = false;
            // 
            // btn_post_status
            // 
            this.btn_post_status.Location = new System.Drawing.Point(496, 71);
            this.btn_post_status.Name = "btn_post_status";
            this.btn_post_status.Size = new System.Drawing.Size(75, 23);
            this.btn_post_status.TabIndex = 1;
            this.btn_post_status.Text = "Publicar";
            this.btn_post_status.UseVisualStyleBackColor = true;
            this.btn_post_status.Click += new System.EventHandler(this.btn_post_status_Click);
            // 
            // txt_post_status
            // 
            this.txt_post_status.Location = new System.Drawing.Point(19, 13);
            this.txt_post_status.MaxLength = 800;
            this.txt_post_status.Multiline = true;
            this.txt_post_status.Name = "txt_post_status";
            this.txt_post_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_post_status.Size = new System.Drawing.Size(552, 52);
            this.txt_post_status.TabIndex = 0;
            this.txt_post_status.Text = "Compatilhe conosco seus pensamentos";
            // 
            // pic_user
            // 
            this.pic_user.Location = new System.Drawing.Point(8, 3);
            this.pic_user.Name = "pic_user";
            this.pic_user.Size = new System.Drawing.Size(160, 160);
            this.pic_user.TabIndex = 0;
            this.pic_user.TabStop = false;
            this.pic_user.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pn_menu_mural
            // 
            this.pn_menu_mural.BackColor = System.Drawing.Color.Transparent;
            this.pn_menu_mural.BackgroundImage = global::ReduOffline.images.mural;
            this.pn_menu_mural.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_menu_mural.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_menu_mural.Location = new System.Drawing.Point(93, 342);
            this.pn_menu_mural.Name = "pn_menu_mural";
            this.pn_menu_mural.Size = new System.Drawing.Size(175, 38);
            this.pn_menu_mural.TabIndex = 15;
            this.pn_menu_mural.Visible = false;
            this.pn_menu_mural.Click += new System.EventHandler(this.pn_menu_mural_Click_1);
            // 
            // pn_more_status
            // 
            this.pn_more_status.BackgroundImage = global::ReduOffline.images.mais;
            this.pn_more_status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_more_status.Location = new System.Drawing.Point(614, 527);
            this.pn_more_status.Name = "pn_more_status";
            this.pn_more_status.Size = new System.Drawing.Size(34, 38);
            this.pn_more_status.TabIndex = 15;
            // 
            // pn_notif_hidden
            // 
            this.pn_notif_hidden.BackColor = System.Drawing.Color.Transparent;
            this.pn_notif_hidden.BackgroundImage = global::ReduOffline.images.notification_hidden;
            this.pn_notif_hidden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pn_notif_hidden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_notif_hidden.Location = new System.Drawing.Point(6, 669);
            this.pn_notif_hidden.Name = "pn_notif_hidden";
            this.pn_notif_hidden.Size = new System.Drawing.Size(255, 22);
            this.pn_notif_hidden.TabIndex = 16;
            this.pn_notif_hidden.Click += new System.EventHandler(this.pn_notif_hidden_Click);
            // 
            // pn_click_hide_notf
            // 
            this.pn_click_hide_notf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pn_click_hide_notf.Location = new System.Drawing.Point(3, 3);
            this.pn_click_hide_notf.Name = "pn_click_hide_notf";
            this.pn_click_hide_notf.Size = new System.Drawing.Size(104, 19);
            this.pn_click_hide_notf.TabIndex = 17;
            this.pn_click_hide_notf.Click += new System.EventHandler(this.pn_click_hide_notf_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 690);
            this.Controls.Add(this.pn_load);
            this.Controls.Add(this.pn_notif_hidden);
            this.Controls.Add(this.pn_notification);
            this.Controls.Add(this.pn_menu_geral);
            this.Controls.Add(this.pn_menu_avas);
            this.Controls.Add(this.pn_post_status);
            this.Controls.Add(this.pn_user_picture);
            this.Controls.Add(this.pn_menu_mural);
            this.Controls.Add(this.pn_wall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 728);
            this.MinimumSize = new System.Drawing.Size(1024, 728);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redu OFFLine";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pn_pin.ResumeLayout(false);
            this.pn_pin.PerformLayout();
            this.pn_login.ResumeLayout(false);
            this.pn_login.PerformLayout();
            this.pn_user_picture.ResumeLayout(false);
            this.pn_user_picture.PerformLayout();
            this.pn_load.ResumeLayout(false);
            this.pn_wall.ResumeLayout(false);
            this.pn_wall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_big_load)).EndInit();
            this.pn_notification.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pn_post_status.ResumeLayout(false);
            this.pn_post_status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_small_load)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox loginTxt;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Panel pn_pin;
        private System.Windows.Forms.Button btn_pin;
        private System.Windows.Forms.TextBox pinTxt;
        private System.Windows.Forms.Panel pn_login;
        private System.Windows.Forms.Panel pn_user_picture;
        private System.Windows.Forms.PictureBox pic_user;
        private System.ComponentModel.BackgroundWorker bw_load;
        private System.Windows.Forms.Panel pn_post_status;
        private System.Windows.Forms.Button btn_post_status;
        private System.Windows.Forms.TextBox txt_post_status;
        private System.Windows.Forms.Panel pn_load;
        private System.Windows.Forms.PictureBox pic_big_load;
        private System.Windows.Forms.Label lbl_pin;
        private System.Windows.Forms.Panel pn_wall;
        private System.Windows.Forms.FlowLayoutPanel pn_main_wall;
        private System.Windows.Forms.Label lbl_login;
        private System.ComponentModel.BackgroundWorker bw_post_user;
        private System.Windows.Forms.PictureBox pic_small_load;
        private System.Windows.Forms.Label lbl_nome_user;
        private System.Windows.Forms.Panel pn_menu_geral;
        private System.Windows.Forms.Panel pn_menu_avas;
        private System.Windows.Forms.FlowLayoutPanel pn_avas;
        private System.Windows.Forms.FlowLayoutPanel pn_disciplina;
        private System.ComponentModel.BackgroundWorker bw_reply_status;
        private System.Windows.Forms.FlowLayoutPanel pn_notification;
        private System.Windows.Forms.FlowLayoutPanel pn_lecture_or_space_feed;
        private System.Windows.Forms.Panel pn_menu_mural;
        private System.Windows.Forms.Panel pn_more_status;
        private System.Windows.Forms.Label lbl_notif;
        private System.Windows.Forms.Panel pn_update;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pn_notif_hidden;
        private System.Windows.Forms.Panel pn_click_hide_notf;
    }
}

