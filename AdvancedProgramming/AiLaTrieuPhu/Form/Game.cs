using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TuDien
{
    public partial class Game : Form
    {
        // chuỗi kết nối CSDL
        string chuoiketnoi = @"Data Source=DESKTOP-OUF6DI5\SQLEXPRESS;Initial Catalog=TuDien;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da_Score, da_User;
        DataTable dt_Score, dt_User;
        // khai báo biến
        private System.Windows.Forms.Timer Time;
        private int counter = 90;
        private int score = 0;
        string UserName = "";
        LoginForm lg = new LoginForm();
        public Game()
        {
            InitializeComponent();
        }
        // khai báo biến name sử dụng cho LoginForm
        public Game(string name)
        {
            InitializeComponent();
            UserName = name;
        }
        // đồng hồ đếm ngược
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter >= 0)
                progressBar_Time.Value = progressBar_Time.Minimum + counter;
            if (counter < 0) // giới hạn
            {
                MessageBox.Show("Times up! Your score: " + label_Score.Text, "Game over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Time.Stop();
                this.Close();
                UpdateData();
                lg.Show();
            }
            // thêm số 0 trước đồng hồ
            if (counter > 9)
                label_Time.Text = counter.ToString();
            else
                label_Time.Text = "0" + counter.ToString();
        }
        // hàm lưu data của người dùng trong game
        public void UpdateData()
        {
            // lưu trạng thái các nút trợ giúp
            string HelpOption = "";
            if (pictureBox_Help1.Enabled == false)
                HelpOption = "23";
            if (pictureBox_Help2.Enabled == false)
                HelpOption = "13";
            if (pictureBox_Help3.Enabled == false)
                HelpOption = "12";
            if (pictureBox_Help1.Enabled == false && pictureBox_Help2.Enabled == false)
                HelpOption = "3";
            if (pictureBox_Help1.Enabled == false && pictureBox_Help3.Enabled == false)
                HelpOption = "2";
            if (pictureBox_Help2.Enabled == false && pictureBox_Help3.Enabled == false)
                HelpOption = "1";
            if (pictureBox_Help1.Enabled == false && pictureBox_Help2.Enabled == false
                && pictureBox_Help3.Enabled == false)
                HelpOption = "0";
            if (pictureBox_Help1.Enabled == true && pictureBox_Help2.Enabled == true
                && pictureBox_Help3.Enabled == true)
                HelpOption = "123";
            // khác
            if (label_Time.Text == "00" || label_Time.Text == "")
                label_Time.Text = "90";
            if (label_QuesionNumber.Text == "8" || label_QuesionNumber.Text == "")
                label_QuesionNumber.Text = "1";
            if (label_Score.Text == "")
                label_Score.Text = "0";
            // lưu data người dùng
            SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
            DataTable dt_LoadData = new DataTable();
            da_LoadData.Fill(dt_LoadData);
            // lấy điểm cũ ra từ CSDL để so sánh với điểm đang chơi
            //int old_score = Convert.ToInt32(dt_LoadData.Rows[0]["Score"].ToString());
            //int new_score = Convert.ToInt32(label_Score.Text);
            //if (old_score < new_score) // nếu điểm cũ nhỏ hơn điểm đang chơi thì lưu lại
            da_User = new SqlDataAdapter("Update UserInfo set Score = '" + label_Score.Text
                + "', QuestionID = '" + label_QuesionNumber.Text + "', Time = '" + label_Time.Text
                + "', HelpOptions = '" + HelpOption + "' where UserName = '" + UserName + "'", conn);
            //else
            //da_User = new SqlDataAdapter("Update UserInfo set QuestionID = '" + label_QuesionNumber.Text + "', Time = '"
            // + label_Time.Text + "', HelpOptions = '" + HelpOption + "' where UserName = '" + UserName + "'", conn);
            dt_User = new DataTable();
            da_User.Fill(dt_User);
            this.Close();
            lg.Show();
        }
        // load trò chơi đang chơi dở
        private void Game_Load(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Welcome " + UserName + "!\nAre you ready?", "Notification",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                // mở kết nối CSDL
                conn = new SqlConnection(chuoiketnoi);
                conn.Open();
                // khai báo
                SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
                DataTable dt_LoadData = new DataTable();
                da_LoadData.Fill(dt_LoadData);
                // hiển thị thời gian
                if (dt_LoadData.Rows[0]["Time"].ToString() != null || dt_LoadData.Rows[0]["Time"].ToString() != "00")
                {
                    Time = new System.Windows.Forms.Timer();
                    Time.Tick += new EventHandler(Timer_Tick);
                    Time.Interval = 1000; // 1 second
                    Time.Start();
                    counter = Convert.ToInt32(dt_LoadData.Rows[0]["Time"].ToString());
                    label_Time.Text = counter.ToString();
                    progressBar_Time.Value = counter; //Gán giá trị cho ProgressBar                    
                }
                else if (dt_LoadData.Rows[0]["Time"].ToString() == "00")
                    Time.Stop();
                else
                {
                    Time = new System.Windows.Forms.Timer();
                    Time.Tick += new EventHandler(Timer_Tick);
                    Time.Interval = 1000; // 1 second
                    Time.Start();
                    label_Time.Text = counter.ToString();
                    progressBar_Time.Value = counter; //Gán giá trị cho ProgressBar
                }
                // hiển thị câu hỏi
                SqlDataAdapter da_Question = new SqlDataAdapter("Select * from QuestionBank", conn);
                DataTable dt_Question = new DataTable();
                da_Question.Fill(dt_Question);
                if (dt_LoadData.Rows[0]["Score"].ToString() == null || dt_LoadData.Rows[0]["Score"].ToString() == "0")
                {
                    label_QuesionNumber.Text = Convert.ToString(1);
                    button_Question.Text = dt_Question.Rows[0]["Question"].ToString();
                    button_A.Text = dt_Question.Rows[0]["RightAnswer"].ToString();
                    button_B.Text = dt_Question.Rows[0]["WrongAnswer1"].ToString();
                    button_C.Text = dt_Question.Rows[0]["WrongAnswer2"].ToString();
                    button_D.Text = dt_Question.Rows[0]["WrongAnswer3"].ToString();
                    label_Score.Text = dt_LoadData.Rows[0]["Score"].ToString();
                }
                else
                {
                    int n = Convert.ToInt32(dt_LoadData.Rows[0]["QuestionID"].ToString());
                    label_QuesionNumber.Text = dt_LoadData.Rows[0]["QuestionID"].ToString();
                    button_Question.Text = dt_Question.Rows[n]["Question"].ToString();
                    button_A.Text = dt_Question.Rows[n]["RightAnswer"].ToString();
                    button_B.Text = dt_Question.Rows[n]["WrongAnswer1"].ToString();
                    button_C.Text = dt_Question.Rows[n]["WrongAnswer2"].ToString();
                    button_D.Text = dt_Question.Rows[n]["WrongAnswer3"].ToString();
                    label_Score.Text = dt_LoadData.Rows[0]["Score"].ToString();
                }
                // khác
                groupBox_Game.Text = "Player: " + UserName;
                Reward();
                HelpOptionsAndScoreboard();
            }
            else
            {
                this.Close();
                lg.Show();
            }
        }
        // load trò chơi mới
        private void Game_Load2(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Welcome " + UserName + "!\nAre you ready?", "Notification",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                // mở kết nối CSDL
                conn = new SqlConnection(chuoiketnoi);
                conn.Open();
                // khai báo
                SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
                DataTable dt_LoadData = new DataTable();
                da_LoadData.Fill(dt_LoadData);
                // hiển thị thời gian
                Time = new System.Windows.Forms.Timer();
                Time.Tick += new EventHandler(Timer_Tick);
                Time.Interval = 1000; // 1 second
                Time.Start();
                counter = Convert.ToInt32(dt_LoadData.Rows[0]["Time"].ToString());
                label_Time.Text = counter.ToString();
                progressBar_Time.Value = counter; //Gán giá trị cho ProgressBar                    
                // hiển thị câu hỏi
                SqlDataAdapter da_Question = new SqlDataAdapter("Select * from QuestionBank", conn);
                DataTable dt_Question = new DataTable();
                da_Question.Fill(dt_Question);
                label_Score.Text = dt_LoadData.Rows[0]["Score"].ToString();
                label_QuesionNumber.Text = dt_LoadData.Rows[0]["QuestionID"].ToString();
                int n = Convert.ToInt32(dt_LoadData.Rows[0]["QuestionID"].ToString());
                button_Question.Text = dt_Question.Rows[n]["Question"].ToString();
                button_A.Text = dt_Question.Rows[n]["RightAnswer"].ToString();
                button_B.Text = dt_Question.Rows[n]["WrongAnswer1"].ToString();
                button_C.Text = dt_Question.Rows[n]["WrongAnswer2"].ToString();
                button_D.Text = dt_Question.Rows[n]["WrongAnswer3"].ToString();
                // hiển thị các sự trợ giúp và bảng điểm
                HelpOptionsAndScoreboard();
            }
            else
            {
                this.Close();
                lg.Show();
            }
        }
        // đáp án A
        private void button_A_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_Question = new SqlDataAdapter("Select * from QuestionBank", conn);
            DataTable dt_Question = new DataTable();
            da_Question.Fill(dt_Question);
            int count = Convert.ToInt32(label_QuesionNumber.Text);
            if (button_A.Text == dt_Question.Rows[count - 1]["RightAnswer"].ToString())
            {
                MessageBox.Show("Đáp án chính xác! Chúc mừng bạn đã giành được 500 điểm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_A.Enabled = true;
                button_B.Enabled = true;
                button_C.Enabled = true;
                button_D.Enabled = true;
                label_QuesionNumber.Text = Convert.ToString(count + 1);
                button_Question.Text = dt_Question.Rows[count]["Question"].ToString();
                button_B.Text = dt_Question.Rows[count]["RightAnswer"].ToString();
                button_C.Text = dt_Question.Rows[count]["WrongAnswer1"].ToString();
                button_D.Text = dt_Question.Rows[count]["WrongAnswer2"].ToString();
                button_A.Text = dt_Question.Rows[count]["WrongAnswer3"].ToString();
                count++;
                score += 500;
                label_Score.Text = Convert.ToString(score);
                Reward();
            }
            else
            {
                MessageBox.Show("Oh no! Your answer is wrong!\nYour score: " + label_Score.Text, "Game over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //UpdateData();
                SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
                DataTable dt_LoadData = new DataTable();
                da_LoadData.Fill(dt_LoadData);
                da_User = new SqlDataAdapter("Update UserInfo set Score = '0', QuestionID = '1', Time = '90' where UserName = '"
                    + UserName + "'", conn);
                this.Close();
                lg.Show();
            }
        }
        // đáp án B
        private void button_B_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_Question = new SqlDataAdapter("Select * from QuestionBank", conn);
            DataTable dt_Question = new DataTable();
            da_Question.Fill(dt_Question);
            int count = Convert.ToInt32(label_QuesionNumber.Text);
            if (button_B.Text == dt_Question.Rows[count - 1]["RightAnswer"].ToString())
            {
                MessageBox.Show("Đáp án chính xác! Chúc mừng bạn đã giành được 500 điểm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_A.Enabled = true;
                button_B.Enabled = true;
                button_C.Enabled = true;
                button_D.Enabled = true;
                label_QuesionNumber.Text = Convert.ToString(count + 1);
                button_Question.Text = dt_Question.Rows[count]["Question"].ToString();
                button_C.Text = dt_Question.Rows[count]["RightAnswer"].ToString();
                button_D.Text = dt_Question.Rows[count]["WrongAnswer1"].ToString();
                button_A.Text = dt_Question.Rows[count]["WrongAnswer2"].ToString();
                button_B.Text = dt_Question.Rows[count]["WrongAnswer3"].ToString();
                count++;
                score += 500;
                label_Score.Text = Convert.ToString(score);
                Reward();
            }
            else
            {
                MessageBox.Show("Oh no! Your answer is wrong!\nYour score: " + label_Score.Text, "Game over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // UpdateData();
                SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
                DataTable dt_LoadData = new DataTable();
                da_LoadData.Fill(dt_LoadData);
                da_User = new SqlDataAdapter("Update UserInfo set Score = '0', QuestionID = '1', Time = '90' where UserName = '"
                    + UserName + "'", conn);
                this.Close();
                lg.Show();
            }
        }
        // đáp án C
        private void button_C_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_Question = new SqlDataAdapter("Select * from QuestionBank", conn);
            DataTable dt_Question = new DataTable();
            da_Question.Fill(dt_Question);
            int count = Convert.ToInt32(label_QuesionNumber.Text);
            if (button_C.Text == dt_Question.Rows[count - 1]["RightAnswer"].ToString())
            {
                MessageBox.Show("Đáp án chính xác! Chúc mừng bạn đã giành được 500 điểm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_A.Enabled = true;
                button_B.Enabled = true;
                button_C.Enabled = true;
                button_D.Enabled = true;
                label_QuesionNumber.Text = Convert.ToString(count + 1);
                button_Question.Text = dt_Question.Rows[count]["Question"].ToString();
                button_D.Text = dt_Question.Rows[count]["RightAnswer"].ToString();
                button_A.Text = dt_Question.Rows[count]["WrongAnswer1"].ToString();
                button_B.Text = dt_Question.Rows[count]["WrongAnswer2"].ToString();
                button_C.Text = dt_Question.Rows[count]["WrongAnswer3"].ToString();
                count++;
                score += 500;
                label_Score.Text = Convert.ToString(score);
                Reward();
            }
            else
            {
                MessageBox.Show("Oh no! Your answer is wrong!\nYour score: " + label_Score.Text, "Game over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // UpdateData();
                SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
                DataTable dt_LoadData = new DataTable();
                da_LoadData.Fill(dt_LoadData);
                da_User = new SqlDataAdapter("Update UserInfo set Score = '0', QuestionID = '1', Time = '90' where UserName = '"
                    + UserName + "'", conn);
                this.Close();
                lg.Show();
            }
        }
        // đáp án D
        private void button_D_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_Question = new SqlDataAdapter("Select * from QuestionBank", conn);
            DataTable dt_Question = new DataTable();
            da_Question.Fill(dt_Question);
            int count = Convert.ToInt32(label_QuesionNumber.Text);
            if (button_D.Text == dt_Question.Rows[count - 1]["RightAnswer"].ToString())
            {
                string sum = Convert.ToString(dt_Question.Rows.Count);
                if (label_QuesionNumber.Text == sum)
                {
                    score += 500;
                    MessageBox.Show("Bạn đã xuất sắc hoàn thành tất cả các câu hỏi!"
                        + "\nChúc mừng bạn đã giành được trọn vẹn 4000 điểm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    lg.Show();
                }
                else
                {
                    MessageBox.Show("Đáp án chính xác! Chúc mừng bạn đã giành được 500 điểm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_A.Enabled = true;
                    button_B.Enabled = true;
                    button_C.Enabled = true;
                    button_D.Enabled = true;
                    label_QuesionNumber.Text = Convert.ToString(count + 1);
                    button_Question.Text = dt_Question.Rows[count]["Question"].ToString();
                    button_A.Text = dt_Question.Rows[count]["RightAnswer"].ToString();
                    button_B.Text = dt_Question.Rows[count]["WrongAnswer1"].ToString();
                    button_C.Text = dt_Question.Rows[count]["WrongAnswer2"].ToString();
                    button_D.Text = dt_Question.Rows[count]["WrongAnswer3"].ToString();
                    count++;
                    score += 500;
                    label_Score.Text = Convert.ToString(score);
                    Reward();
                }
            }
            else
            {
                MessageBox.Show("Oh no! Your answer is wrong!\nYour score: " + label_Score.Text, "Game over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //UpdateData();
                SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
                DataTable dt_LoadData = new DataTable();
                da_LoadData.Fill(dt_LoadData);
                da_User = new SqlDataAdapter("Update UserInfo set Score = '0', QuestionID = '1', Time = '90' where UserName = '"
                    + UserName + "'", conn);
                this.Close();
                lg.Show();
            }
        }
        // bảng reward
        public void Reward()
        {
            if (label_QuesionNumber.Text == "1")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Red;
            }
            else if (label_QuesionNumber.Text == "2")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Blue;
                label_Reward2.ForeColor = System.Drawing.Color.Red;
            }
            else if (label_QuesionNumber.Text == "3")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Blue;
                label_Reward2.ForeColor = System.Drawing.Color.Blue;
                label_Reward3.ForeColor = System.Drawing.Color.Red;
            }
            else if (label_QuesionNumber.Text == "4")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Blue;
                label_Reward2.ForeColor = System.Drawing.Color.Blue;
                label_Reward3.ForeColor = System.Drawing.Color.Blue;
                label_Reward4.ForeColor = System.Drawing.Color.Red;
            }
            else if (label_QuesionNumber.Text == "5")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Blue;
                label_Reward2.ForeColor = System.Drawing.Color.Blue;
                label_Reward3.ForeColor = System.Drawing.Color.Blue;
                label_Reward4.ForeColor = System.Drawing.Color.Blue;
                label_Reward5.ForeColor = System.Drawing.Color.Red;
            }
            else if (label_QuesionNumber.Text == "6")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Blue;
                label_Reward2.ForeColor = System.Drawing.Color.Blue;
                label_Reward3.ForeColor = System.Drawing.Color.Blue;
                label_Reward4.ForeColor = System.Drawing.Color.Blue;
                label_Reward5.ForeColor = System.Drawing.Color.Blue;
                label_Reward6.ForeColor = System.Drawing.Color.Red;
            }
            else if (label_QuesionNumber.Text == "7")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Blue;
                label_Reward2.ForeColor = System.Drawing.Color.Blue;
                label_Reward3.ForeColor = System.Drawing.Color.Blue;
                label_Reward4.ForeColor = System.Drawing.Color.Blue;
                label_Reward5.ForeColor = System.Drawing.Color.Blue;
                label_Reward6.ForeColor = System.Drawing.Color.Blue;
                label_Reward7.ForeColor = System.Drawing.Color.Red;
            }
            else if (label_QuesionNumber.Text == "8")
            {
                label_Reward1.ForeColor = System.Drawing.Color.Blue;
                label_Reward2.ForeColor = System.Drawing.Color.Blue;
                label_Reward3.ForeColor = System.Drawing.Color.Blue;
                label_Reward4.ForeColor = System.Drawing.Color.Blue;
                label_Reward5.ForeColor = System.Drawing.Color.Blue;
                label_Reward6.ForeColor = System.Drawing.Color.Blue;
                label_Reward7.ForeColor = System.Drawing.Color.Blue;
                label_Reward8.ForeColor = System.Drawing.Color.Red;
            }
        }
        // các nút trợ giúp và bảng score
        public void HelpOptionsAndScoreboard()
        {
            // mở kết nối CSDL
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            // khai báo
            SqlDataAdapter da_LoadData = new SqlDataAdapter("Select * from UserInfo where UserName = '" + UserName + "'", conn);
            DataTable dt_LoadData = new DataTable();
            da_LoadData.Fill(dt_LoadData);
            // hiển thị các trợ giúp
            if (dt_LoadData.Rows[0]["HelpOptions"].ToString() == "23")
            {
                pictureBox_Help1.Enabled = false;
                pictureBox_Help1.Hide();
            }
            else if (dt_LoadData.Rows[0]["HelpOptions"].ToString() == "13")
            {
                pictureBox_Help2.Enabled = false;
                pictureBox_Help2.Hide();
            }
            else if (dt_LoadData.Rows[0]["HelpOptions"].ToString() == "12")
            {
                pictureBox_Help3.Enabled = false;
                pictureBox_Help3.Hide();
            }
            else if (dt_LoadData.Rows[0]["HelpOptions"].ToString() == "1")
            {
                pictureBox_Help2.Enabled = false;
                pictureBox_Help2.Hide();
                pictureBox_Help3.Enabled = false;
                pictureBox_Help3.Hide();
            }
            else if (dt_LoadData.Rows[0]["HelpOptions"].ToString() == "2")
            {
                pictureBox_Help1.Enabled = false;
                pictureBox_Help1.Hide();
                pictureBox_Help3.Enabled = false;
                pictureBox_Help3.Hide();
            }
            else if (dt_LoadData.Rows[0]["HelpOptions"].ToString() == "3")
            {
                pictureBox_Help1.Enabled = false;
                pictureBox_Help1.Hide();
                pictureBox_Help2.Enabled = false;
                pictureBox_Help2.Hide();
            }
            else if (dt_LoadData.Rows[0]["HelpOptions"].ToString() == "0")
            {
                pictureBox_Help1.Enabled = false;
                pictureBox_Help1.Hide();
                pictureBox_Help2.Enabled = false;
                pictureBox_Help2.Hide();
                pictureBox_Help3.Enabled = false;
                pictureBox_Help3.Hide();
            }
            // hiển thị bảng scoreboard
            da_Score = new SqlDataAdapter("Select * from UserInfo order by Score DESC", conn);
            dt_Score = new DataTable();
            da_Score.Fill(dt_Score);
            label_HighScore1.Text = "1. " + dt_Score.Rows[0]["Score"].ToString() + " (" + dt_Score.Rows[0]["UserName"].ToString() + ")";
            label_HighScore2.Text = "2. " + dt_Score.Rows[1]["Score"].ToString() + " (" + dt_Score.Rows[1]["UserName"].ToString() + ")";
            label_HighScore3.Text = "3. " + dt_Score.Rows[2]["Score"].ToString() + " (" + dt_Score.Rows[2]["UserName"].ToString() + ")";
            label_HighScore4.Text = "4. " + dt_Score.Rows[3]["Score"].ToString() + " (" + dt_Score.Rows[3]["UserName"].ToString() + ")";
            label_HighScore5.Text = "5. " + dt_Score.Rows[4]["Score"].ToString() + " (" + dt_Score.Rows[4]["UserName"].ToString() + ")";
        }
        // nút trợ giúp 1
        private void pictureBox_Help1_Click(object sender, EventArgs e)
        {
            if (label_QuesionNumber.Text == "1")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_B.Enabled = false;
                    button_C.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
            else if (label_QuesionNumber.Text == "2")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_D.Enabled = false;
                    button_C.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
            else if (label_QuesionNumber.Text == "3")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_B.Enabled = false;
                    button_D.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
            else if (label_QuesionNumber.Text == "4")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_A.Enabled = false;
                    button_C.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
            else if (label_QuesionNumber.Text == "5")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_D.Enabled = false;
                    button_C.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
            else if (label_QuesionNumber.Text == "6")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_A.Enabled = false;
                    button_C.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
            else if (label_QuesionNumber.Text == "7")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_B.Enabled = false;
                    button_A.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
            else if (label_QuesionNumber.Text == "8")
            {
                DialogResult dlr = MessageBox.Show("Do you want to discard two wrong answers?", "50:50",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No)
                    this.Show();
                else
                {
                    button_B.Enabled = false;
                    button_C.Enabled = false;
                    pictureBox_Help1.Enabled = false;
                    pictureBox_Help1.Hide();
                }
            }
        }
        // nút trợ giúp 2
        private void pictureBox_Help2_Click(object sender, EventArgs e)
        {
            string num = label_QuesionNumber.Text;
            Game_HelpOption2 hp2 = new Game_HelpOption2(num);
            hp2.ShowDialog();
            pictureBox_Help2.Enabled = false;
            pictureBox_Help2.Hide();
        }
        // nút trợ giúp 3
        private void pictureBox_Help3_Click(object sender, EventArgs e)
        {
            string num = label_QuesionNumber.Text;

            pictureBox_Help3.Enabled = false;
            pictureBox_Help3.Hide();
        }
        // tạm dừng
        private void button_Pause_Click(object sender, EventArgs e)
        {
            Time.Stop();
            button_Question.Hide();
            button_A.Hide();
            button_B.Hide();
            button_C.Hide();
            button_D.Hide();
            panel3.Hide();
            DialogResult dlr = MessageBox.Show("Game is paused. Do you want to continue?", "Paused",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                Time.Start();
                button_Question.Show();
                button_A.Show();
                button_B.Show();
                button_C.Show();
                button_D.Show();
                panel3.Show();
            }
        }
        // dừng lại
        private void button_Stop_Click(object sender, EventArgs e)
        {
            Time.Stop();
            button_Question.Hide();
            button_A.Hide();
            button_B.Hide();
            button_C.Hide();
            button_D.Hide();
            panel3.Hide();
            DialogResult dlr = MessageBox.Show("Are you sure to quit game? Your data will be saved.", "Stop",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No) // trở lại màn hình game chính (tiếp tục trò chơi)
            {
                this.Show();
                Time.Start();
                button_Question.Show();
                button_A.Show();
                button_B.Show();
                button_C.Show();
                button_D.Show();
                panel3.Show();
            }
            else // lưu data người dùng đang chơi dở và thoát ra màn hình đăng nhập
            {
                UpdateData();
            }
        }
        // trò chơi mới
        private void button_NewGame_Click(object sender, EventArgs e)
        {

        }

    }
}
