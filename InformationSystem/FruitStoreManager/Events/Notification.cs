using FruitStoreManager.Models;
using System.Windows.Forms;

namespace FruitStoreManager.Events
{
    internal class Error
    {
        public static void Login()
        {
            MessageBox.Show("Username or Password is not valid!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    internal class Warning
    {
        public static void InputFormat()
        {
            MessageBox.Show("Input format is not valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void NullValue()
        {
            MessageBox.Show("This value can't be null!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Exist()
        {
            MessageBox.Show("This value was exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void SpecialCharacter()
        {
            MessageBox.Show("This value can't contain special character(s)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Exceed()
        {
            MessageBox.Show("Input value have exceeded max value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Expired()
        {
            MessageBox.Show("This item was expired!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }    
    }

    internal class Information
    {
        public static void LoginPermission(Account account)
        {
            if (account.Permission.ToString() == "Quản lý")
                MessageBox.Show("You are logged in as an administrator!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (account.Permission.ToString() == "Nhân viên")
                MessageBox.Show("You are logged in as an employee!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Success()
        {
            MessageBox.Show("Success!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    internal class Question
    {
        public static bool Logout()
        {
            var result = MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        } 
        
        public static bool Quit()
        {
            var result = MessageBox.Show("Are you sure to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }
        
        public static bool Add()
        {
            var result = MessageBox.Show("Are you sure to add?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }

        public static bool Edit()
        {
            var result = MessageBox.Show("Are you sure to edit?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }

        public static bool Delete()
        {
            var result = MessageBox.Show("Are you sure to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }   
    }    
}