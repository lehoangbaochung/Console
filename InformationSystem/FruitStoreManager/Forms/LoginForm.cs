using FruitStoreManager.Events;
using FruitStoreManager.Functions;
using System;
using System.Windows.Forms;

namespace FruitStoreManager.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Execute.CreateFiles();
            Get.Account();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button == btnLogin)
            {
                if (Check.Login(tbxUsername.Text, tbxPassword.Text))
                {
                    Hide();
                }
                else
                    Error.Login();
            }

            if (button == btnQuit)
            {
                if (!Question.Quit()) return;

                Application.Exit();
            }

            tbxUsername.ResetText();
            tbxPassword.ResetText();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
