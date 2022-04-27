using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TuDien
{
    public partial class Game_HelpOption2 : Form
    {
        private string QuestionNum;

        public Game_HelpOption2()
        {
            InitializeComponent();
        }

        public Game_HelpOption2(string num)
        {
            InitializeComponent();
            QuestionNum = num;
        }
        // người trợ giúp 1
        private void button_Help2_1_Click(object sender, EventArgs e)
        {
            if (QuestionNum == "1")
                MessageBox.Show(button_Help2_1.Text+" trợ giúp cho bạn đáp án B!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "2")
                MessageBox.Show(button_Help2_1.Text+" trợ giúp cho bạn đáp án C!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "3")
                MessageBox.Show(button_Help2_1.Text + " trợ giúp cho bạn đáp án A!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "4")
                MessageBox.Show(button_Help2_1.Text + " trợ giúp cho bạn đáp án D!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "5")
                MessageBox.Show(button_Help2_1.Text + " trợ giúp cho bạn đáp án D!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "6")
                MessageBox.Show(button_Help2_1.Text + " trợ giúp cho bạn đáp án C!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "7")
                MessageBox.Show(button_Help2_1.Text + " trợ giúp cho bạn đáp án A!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "8")
                MessageBox.Show(button_Help2_1.Text + " trợ giúp cho bạn đáp án B!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        // người trợ giúp 2
        private void button_Help2_2_Click(object sender, EventArgs e)
        {
            if (QuestionNum == "1")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án A!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "2")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án B!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "3")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án C!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "4")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án D!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "5")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án C!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "6")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án D!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "7")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án B!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "8")
                MessageBox.Show(button_Help2_2.Text + " trợ giúp cho bạn đáp án A!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        // người trợ giúp 3
        private void button_Help2_3_Click(object sender, EventArgs e)
        {
            if (QuestionNum == "1")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án D!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "2")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án A!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "3")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án C!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "4")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án B!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "5")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án A!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "6")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án B!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "7")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án C!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (QuestionNum == "8")
                MessageBox.Show(button_Help2_3.Text + " trợ giúp cho bạn đáp án D!", "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Game_HelpOption2_Load(object sender, EventArgs e)
        {

        }
    }
}
