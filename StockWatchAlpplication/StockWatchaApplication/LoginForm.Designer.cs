namespace StockWatchApplication
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.UserNameBox = new MetroFramework.Controls.MetroTextBox();
            this.PasswordBox = new MetroFramework.Controls.MetroTextBox();
            this.UsernameLabel = new MetroFramework.Controls.MetroLabel();
            this.BackgroundPanel = new MetroFramework.Controls.MetroPanel();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.PasswordLabel = new MetroFramework.Controls.MetroLabel();
            this.LoginButton = new MetroFramework.Controls.MetroButton();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.BackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameBox
            // 
            this.UserNameBox.BackColor = System.Drawing.Color.Aqua;
            // 
            // 
            // 
            this.UserNameBox.CustomButton.Image = null;
            this.UserNameBox.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.UserNameBox.CustomButton.Name = "";
            this.UserNameBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.UserNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UserNameBox.CustomButton.TabIndex = 1;
            this.UserNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UserNameBox.CustomButton.UseSelectable = true;
            this.UserNameBox.CustomButton.Visible = false;
            this.UserNameBox.DisplayIcon = true;
            this.UserNameBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserNameBox.Icon = ((System.Drawing.Image)(resources.GetObject("UserNameBox.Icon")));
            this.UserNameBox.Lines = new string[0];
            this.UserNameBox.Location = new System.Drawing.Point(238, 41);
            this.UserNameBox.MaxLength = 32767;
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.PasswordChar = '\0';
            this.UserNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UserNameBox.SelectedText = "";
            this.UserNameBox.SelectionLength = 0;
            this.UserNameBox.SelectionStart = 0;
            this.UserNameBox.ShortcutsEnabled = true;
            this.UserNameBox.Size = new System.Drawing.Size(190, 25);
            this.UserNameBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.UserNameBox.TabIndex = 0;
            this.UserNameBox.UseSelectable = true;
            this.UserNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UserNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.Color.Aqua;
            // 
            // 
            // 
            this.PasswordBox.CustomButton.Image = null;
            this.PasswordBox.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.PasswordBox.CustomButton.Name = "";
            this.PasswordBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.PasswordBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PasswordBox.CustomButton.TabIndex = 1;
            this.PasswordBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PasswordBox.CustomButton.UseSelectable = true;
            this.PasswordBox.CustomButton.Visible = false;
            this.PasswordBox.DisplayIcon = true;
            this.PasswordBox.Icon = ((System.Drawing.Image)(resources.GetObject("PasswordBox.Icon")));
            this.PasswordBox.Lines = new string[0];
            this.PasswordBox.Location = new System.Drawing.Point(238, 72);
            this.PasswordBox.MaxLength = 32767;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '\0';
            this.PasswordBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.SelectionLength = 0;
            this.PasswordBox.SelectionStart = 0;
            this.PasswordBox.ShortcutsEnabled = true;
            this.PasswordBox.Size = new System.Drawing.Size(190, 25);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.UseSelectable = true;
            this.PasswordBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PasswordBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.UsernameLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.UsernameLabel.Location = new System.Drawing.Point(152, 42);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(80, 19);
            this.UsernameLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "Username:";
            this.UsernameLabel.UseCustomBackColor = true;
            this.UsernameLabel.UseCustomForeColor = true;
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.BackgroundPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundPanel.Controls.Add(this.UserPictureBox);
            this.BackgroundPanel.Controls.Add(this.PasswordLabel);
            this.BackgroundPanel.Controls.Add(this.PasswordBox);
            this.BackgroundPanel.Controls.Add(this.UsernameLabel);
            this.BackgroundPanel.Controls.Add(this.UserNameBox);
            this.BackgroundPanel.HorizontalScrollbarBarColor = true;
            this.BackgroundPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.BackgroundPanel.HorizontalScrollbarSize = 10;
            this.BackgroundPanel.Location = new System.Drawing.Point(-1, 61);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(451, 133);
            this.BackgroundPanel.TabIndex = 4;
            this.BackgroundPanel.UseCustomBackColor = true;
            this.BackgroundPanel.VerticalScrollbarBarColor = true;
            this.BackgroundPanel.VerticalScrollbarHighlightOnWheel = false;
            this.BackgroundPanel.VerticalScrollbarSize = 10;
            // 
            // UserPictureBox
            // 
            this.UserPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("UserPictureBox.Image")));
            this.UserPictureBox.Location = new System.Drawing.Point(24, 12);
            this.UserPictureBox.Name = "UserPictureBox";
            this.UserPictureBox.Size = new System.Drawing.Size(122, 112);
            this.UserPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserPictureBox.TabIndex = 5;
            this.UserPictureBox.TabStop = false;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.PasswordLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.PasswordLabel.Location = new System.Drawing.Point(152, 75);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(77, 19);
            this.PasswordLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            this.PasswordLabel.UseCustomBackColor = true;
            this.PasswordLabel.UseCustomForeColor = true;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoginButton.Location = new System.Drawing.Point(342, 202);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(99, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "LogIn";
            this.LoginButton.UseCustomBackColor = true;
            this.LoginButton.UseCustomForeColor = true;
            this.LoginButton.UseSelectable = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LogoBox
            // 
            this.LogoBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoBox.Image")));
            this.LogoBox.Location = new System.Drawing.Point(10, 19);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(38, 34);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 6;
            this.LogoBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(450, 232);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.BackgroundPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.Text = "    LOGIN";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.BackgroundPanel.ResumeLayout(false);
            this.BackgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private MetroFramework.Controls.MetroTextBox PasswordBox;
        private MetroFramework.Controls.MetroTextBox UserNameBox;
        private MetroFramework.Controls.MetroLabel UsernameLabel;
        private MetroFramework.Controls.MetroPanel BackgroundPanel;
        private MetroFramework.Controls.MetroLabel PasswordLabel;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private MetroFramework.Controls.MetroButton LoginButton;
        private System.Windows.Forms.PictureBox LogoBox;
    }
}