using System;
using System.Windows.Forms;

namespace StockWatchApplication
{
    static class StartApp
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm formLogin = new LoginForm();
            formLogin.ShowDialog();
            if (formLogin.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainForm(formLogin.Username));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
