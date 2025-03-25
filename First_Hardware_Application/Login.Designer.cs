namespace First_Hardware_Application
{
    partial class Login
    {
        /// <summary>
        /// ������������ ���������� ������������.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ���������� ��� ������������ �������.
        /// </summary>
        /// <param name="disposing">�������, ���� ����������� ������ ������ ���� ������; ����� �����.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region ���, ������������� ��������� ������������� ���� Windows

        /// <summary>
        /// ��������� ����� ��� ��������� ������������ � �� ��������� 
        /// ���������� ����� ������ � ������� ��������� ����.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.label_reset = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_pass_vis = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox_username
            // 
            this.textbox_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_username.Location = new System.Drawing.Point(209, 307);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(188, 27);
            this.textbox_username.TabIndex = 2;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.BackColor = System.Drawing.Color.DarkGray;
            this.label_username.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_username.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.ForeColor = System.Drawing.Color.White;
            this.label_username.Location = new System.Drawing.Point(207, 283);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(138, 21);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Ім\'я користувача";
            
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.BackColor = System.Drawing.Color.DarkGray;
            this.label_password.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_password.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.ForeColor = System.Drawing.Color.White;
            this.label_password.Location = new System.Drawing.Point(207, 345);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(68, 21);
            this.label_password.TabIndex = 5;
            this.label_password.Text = "Пароль";
            
            // 
            // textbox_password
            // 
            this.textbox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_password.Location = new System.Drawing.Point(211, 369);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(188, 27);
            this.textbox_password.TabIndex = 4;
            this.textbox_password.TextChanged += new System.EventHandler(this.textbox_password_TextChanged);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.White;
            this.button_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(135)))), ((int)(((byte)(204)))));
            this.button_login.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(135)))), ((int)(((byte)(204)))));
            this.button_login.Location = new System.Drawing.Point(234, 416);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(140, 39);
            this.button_login.TabIndex = 8;
            this.button_login.Text = "Увійти";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            this.button_login.MouseLeave += new System.EventHandler(this.button_login_MouseLeave);
            this.button_login.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_login_MouseMove);
            // 
            // label_reset
            // 
            this.label_reset.AutoSize = true;
            this.label_reset.BackColor = System.Drawing.Color.DarkGray;
            this.label_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_reset.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Underline);
            this.label_reset.ForeColor = System.Drawing.Color.White;
            this.label_reset.Location = new System.Drawing.Point(426, 459);
            this.label_reset.Name = "label_reset";
            this.label_reset.Size = new System.Drawing.Size(66, 20);
            this.label_reset.TabIndex = 10;
            this.label_reset.Text = "Скинути";
            this.label_reset.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Firebrick;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(570, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button_pass_vis
            // 
            this.button_pass_vis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_pass_vis.BackgroundImage")));
            this.button_pass_vis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_pass_vis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_pass_vis.Image = ((System.Drawing.Image)(resources.GetObject("button_pass_vis.Image")));
            this.button_pass_vis.Location = new System.Drawing.Point(405, 369);
            this.button_pass_vis.Name = "button_pass_vis";
            this.button_pass_vis.Size = new System.Drawing.Size(25, 25);
            this.button_pass_vis.TabIndex = 12;
            this.button_pass_vis.UseVisualStyleBackColor = true;
            this.button_pass_vis.Visible = false;
            this.button_pass_vis.Click += new System.EventHandler(this.button_pass_vis_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(136, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 117);
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(95, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(416, 468);
            this.pictureBox2.TabIndex = 63;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox2_LoadCompleted);
            
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_pass_vis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_reset);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textbox_username);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_reset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_pass_vis;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

