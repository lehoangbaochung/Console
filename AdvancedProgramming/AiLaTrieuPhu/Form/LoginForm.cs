using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TuDien
{
    public partial class LoginForm : Form
    {
        // chuỗi kết nối CSDL
        string chuoiketnoi = @"Data Source=DESKTOP-OUF6DI5\SQLEXPRESS;Initial Catalog=TuDien;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        public LoginForm()
        {
            InitializeComponent();
        }

        // khai báo biến tĩnh UserID
        public static string UserID = "";
        // load form đăng nhập
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // kết nối CSDL
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            // truyền dữ liệu cho scoreboard
            SqlDataAdapter da_Scoreboard = new SqlDataAdapter("Select UserName as 'Player name', " +
               "Score as 'Score' from UserInfo order by Score DESC", conn);
            DataTable dt_Scoreboard = new DataTable();
            dt_Scoreboard.Rows.Clear();
            da_Scoreboard.Fill(dt_Scoreboard);
            dataGridView_Scoreboard.DataSource = dt_Scoreboard;
            dataGridView_Scoreboard.Hide();
            dataGridView_Scoreboard.ForeColor = Color.Black;
            // ẩn hộp nhập lại mật khẩu
            textBox_UserPass2.Hide();
            label_UserPass2.Hide();
        }
        // nút đăng ký
        private void button_SignUp_Click(object sender, EventArgs e)
        {
            if (button_SignUp.Text == "Sign up")
            {
                textBox_UserPass2.Show();
                label_UserPass2.Show();
                textBox_UserPass2.Enabled = true;
                label_UserPass2.Enabled = true;
                button_SignUp.Text = "Back";
                button_SignIn.Text = "Done";
            }
            else if (button_SignUp.Text == "Back")
            {
                LoginForm_Load(sender, e);
                button_SignIn.Text = "Sign in";
                button_SignUp.Text = "Sign up";
            }
            else if (button_SignUp.Text == "New game")
            {
                Game gf = new Game();
                gf.Show();
            }
        }
        // nút đăng nhập
        private void button_SignIn_Click(object sender, EventArgs e)
        {
            if (button_SignIn.Text == "Done")
            {
                // kiểm tra điều kiện nhập mật khẩu
                if (textBox_UserPass.Text != textBox_UserPass2.Text)
                    MessageBox.Show("Password is incorrect!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (textBox_UserName.Text != null && textBox_UserPass.Text != null && textBox_UserPass2.Text != null)
                    {
                        da = new SqlDataAdapter("Select COUNT(*) from UserInfo where UserName = '"
                            + textBox_UserName.Text + "'", conn);
                        dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                            MessageBox.Show("Account is existed!", "Notification",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            cmd = new SqlCommand("Insert into UserInfo values ('" + textBox_UserName.Text + "', '" +
                                textBox_UserPass.Text + "', '0', '1', '90', '123')", conn);
                            cmd.ExecuteNonQuery();
                            dt = new DataTable();
                            da.Fill(dt);
                            MessageBox.Show("Sign up sucessful!", "Notification",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoginForm_Load(sender, e);
                            button_SignIn.Text = "Sign in";
                            button_SignUp.Text = "Sign up";
                        }
                    }
                }
            }
            else if (button_SignIn.Text == "Sign in")
            {
                if (textBox_UserName.Text != "" && textBox_UserPass.Text != "")
                {
                    da = new SqlDataAdapter("Select COUNT(*) from UserInfo where UserName ='" + textBox_UserName.Text
                        + "' and UserPass ='" + textBox_UserPass.Text + "'", conn);
                    da.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        // kiểm tra người chơi có đang chơi dở hay không
                        da = new SqlDataAdapter("Select * from UserInfo where UserName ='" + textBox_UserName.Text
                        + "' and UserPass ='" + textBox_UserPass.Text + "'", conn);
                        da.Fill(dt);

                        {
                            this.Hide();
                            string name = textBox_UserName.Text; // lấy giá trị textBox_UserName.Text truyền sang form Game
                            Game g = new Game(name);
                            g.Show();
                        }
                    }
                    else
                        MessageBox.Show("Account does not exist or user name and password are wrong!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        // event link label
        private void linkLabel_SignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel_SignOut.Text == "Quit")
            {
                DialogResult dlr = MessageBox.Show("Are you sure to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                    Application.Exit();
            }
            else if (linkLabel_SignOut.Text == "Sign out")
            {
                label_UserName.Show();
                label_UserPass.Text = "Password";
                textBox_UserName.Enabled = true;
                textBox_UserPass.Enabled = true;
                textBox_UserName.Show();
                textBox_UserPass.Show();
                button_SignIn.Text = "Sign in";
                button_SignUp.Text = "Sign up";
                linkLabel_SignOut.Text = "Quit";
                groupBox_Login.Text = "Welcome!";
            }
        }

        private void button_Scoreboard_Click(object sender, EventArgs e)
        {
            if (dataGridView_Scoreboard.Enabled == false)
            {
                dataGridView_Scoreboard.Show();
                dataGridView_Scoreboard.Enabled = true;
            }
            else
            {
                dataGridView_Scoreboard.Hide();
                dataGridView_Scoreboard.Enabled = false;
            }
        }
    }
}
