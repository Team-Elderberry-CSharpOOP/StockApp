namespace StockWatchApplication
{
    using System;
    using Profile;
    using System.Windows.Forms;

    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public string Username { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            this.PasswordBox.PasswordChar = '*';
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Username = this.UserNameBox.Text.Trim();
            string password = this.PasswordBox.Text.Trim();
            if (new User().SignIn(this.Username, password))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
