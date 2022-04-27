namespace TuDien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_Login = new System.Windows.Forms.GroupBox();
            this.linkLabel_SignOut = new System.Windows.Forms.LinkLabel();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label_UserName = new System.Windows.Forms.Label();
            this.textBox_UserPass2 = new System.Windows.Forms.TextBox();
            this.textBox_UserPass = new System.Windows.Forms.TextBox();
            this.label_UserPass2 = new System.Windows.Forms.Label();
            this.label_UserPass = new System.Windows.Forms.Label();
            this.button_SignUp = new System.Windows.Forms.Button();
            this.button_SignIn = new System.Windows.Forms.Button();
            this.dataGridView_Scoreboard = new System.Windows.Forms.DataGridView();
            this.button_Scoreboard = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Scoreboard)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox_Login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 473);
            this.panel1.TabIndex = 0;
            // 
            // groupBox_Login
            // 
            this.groupBox_Login.BackColor = System.Drawing.Color.Black;
            this.groupBox_Login.BackgroundImage = global::TuDien.Properties.Resources.p15896577_b_v8_ab;
            this.groupBox_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox_Login.Controls.Add(this.button_Scoreboard);
            this.groupBox_Login.Controls.Add(this.dataGridView_Scoreboard);
            this.groupBox_Login.Controls.Add(this.linkLabel_SignOut);
            this.groupBox_Login.Controls.Add(this.textBox_UserName);
            this.groupBox_Login.Controls.Add(this.label_UserName);
            this.groupBox_Login.Controls.Add(this.textBox_UserPass2);
            this.groupBox_Login.Controls.Add(this.textBox_UserPass);
            this.groupBox_Login.Controls.Add(this.label_UserPass2);
            this.groupBox_Login.Controls.Add(this.label_UserPass);
            this.groupBox_Login.Controls.Add(this.button_SignUp);
            this.groupBox_Login.Controls.Add(this.button_SignIn);
            this.groupBox_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Login.ForeColor = System.Drawing.Color.White;
            this.groupBox_Login.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Login.Name = "groupBox_Login";
            this.groupBox_Login.Size = new System.Drawing.Size(302, 473);
            this.groupBox_Login.TabIndex = 9;
            this.groupBox_Login.TabStop = false;
            this.groupBox_Login.Text = "Welcome!";
            this.groupBox_Login.Enter += new System.EventHandler(this.button_SignIn_Click);
            // 
            // linkLabel_SignOut
            // 
            this.linkLabel_SignOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_SignOut.AutoSize = true;
            this.linkLabel_SignOut.LinkColor = System.Drawing.Color.White;
            this.linkLabel_SignOut.Location = new System.Drawing.Point(264, 0);
            this.linkLabel_SignOut.Name = "linkLabel_SignOut";
            this.linkLabel_SignOut.Size = new System.Drawing.Size(26, 13);
            this.linkLabel_SignOut.TabIndex = 6;
            this.linkLabel_SignOut.TabStop = true;
            this.linkLabel_SignOut.Text = "Quit";
            this.linkLabel_SignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_SignOut_LinkClicked);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserName.Location = new System.Drawing.Point(154, 170);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(121, 20);
            this.textBox_UserName.TabIndex = 1;
            // 
            // label_UserName
            // 
            this.label_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_UserName.AutoSize = true;
            this.label_UserName.BackColor = System.Drawing.Color.Black;
            this.label_UserName.ForeColor = System.Drawing.Color.Yellow;
            this.label_UserName.Location = new System.Drawing.Point(85, 173);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(58, 13);
            this.label_UserName.TabIndex = 15;
            this.label_UserName.Text = "User name";
            // 
            // textBox_UserPass2
            // 
            this.textBox_UserPass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserPass2.Enabled = false;
            this.textBox_UserPass2.Location = new System.Drawing.Point(154, 239);
            this.textBox_UserPass2.Name = "textBox_UserPass2";
            this.textBox_UserPass2.PasswordChar = '*';
            this.textBox_UserPass2.Size = new System.Drawing.Size(121, 20);
            this.textBox_UserPass2.TabIndex = 3;
            // 
            // textBox_UserPass
            // 
            this.textBox_UserPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserPass.Location = new System.Drawing.Point(154, 205);
            this.textBox_UserPass.Name = "textBox_UserPass";
            this.textBox_UserPass.PasswordChar = '*';
            this.textBox_UserPass.Size = new System.Drawing.Size(121, 20);
            this.textBox_UserPass.TabIndex = 2;
            // 
            // label_UserPass2
            // 
            this.label_UserPass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_UserPass2.AutoSize = true;
            this.label_UserPass2.BackColor = System.Drawing.Color.Black;
            this.label_UserPass2.Enabled = false;
            this.label_UserPass2.ForeColor = System.Drawing.Color.Yellow;
            this.label_UserPass2.Location = new System.Drawing.Point(53, 242);
            this.label_UserPass2.Name = "label_UserPass2";
            this.label_UserPass2.Size = new System.Drawing.Size(90, 13);
            this.label_UserPass2.TabIndex = 12;
            this.label_UserPass2.Text = "Confirm password";
            // 
            // label_UserPass
            // 
            this.label_UserPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_UserPass.AutoSize = true;
            this.label_UserPass.BackColor = System.Drawing.Color.Black;
            this.label_UserPass.ForeColor = System.Drawing.Color.Yellow;
            this.label_UserPass.Location = new System.Drawing.Point(90, 208);
            this.label_UserPass.Name = "label_UserPass";
            this.label_UserPass.Size = new System.Drawing.Size(53, 13);
            this.label_UserPass.TabIndex = 11;
            this.label_UserPass.Text = "Password";
            // 
            // button_SignUp
            // 
            this.button_SignUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SignUp.BackColor = System.Drawing.Color.Black;
            this.button_SignUp.ForeColor = System.Drawing.Color.Yellow;
            this.button_SignUp.Location = new System.Drawing.Point(154, 274);
            this.button_SignUp.Name = "button_SignUp";
            this.button_SignUp.Size = new System.Drawing.Size(121, 29);
            this.button_SignUp.TabIndex = 5;
            this.button_SignUp.Text = "Sign up";
            this.button_SignUp.UseVisualStyleBackColor = false;
            this.button_SignUp.Click += new System.EventHandler(this.button_SignUp_Click);
            // 
            // button_SignIn
            // 
            this.button_SignIn.BackColor = System.Drawing.Color.Black;
            this.button_SignIn.ForeColor = System.Drawing.Color.Yellow;
            this.button_SignIn.Location = new System.Drawing.Point(27, 274);
            this.button_SignIn.Name = "button_SignIn";
            this.button_SignIn.Size = new System.Drawing.Size(121, 29);
            this.button_SignIn.TabIndex = 4;
            this.button_SignIn.Text = "Sign in";
            this.button_SignIn.UseVisualStyleBackColor = false;
            this.button_SignIn.Click += new System.EventHandler(this.button_SignIn_Click);
            // 
            // dataGridView_Scoreboard
            // 
            this.dataGridView_Scoreboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Scoreboard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_Scoreboard.Location = new System.Drawing.Point(3, 361);
            this.dataGridView_Scoreboard.Name = "dataGridView_Scoreboard";
            this.dataGridView_Scoreboard.Size = new System.Drawing.Size(296, 109);
            this.dataGridView_Scoreboard.TabIndex = 16;
            // 
            // button_Scoreboard
            // 
            this.button_Scoreboard.BackColor = System.Drawing.Color.Black;
            this.button_Scoreboard.ForeColor = System.Drawing.Color.Yellow;
            this.button_Scoreboard.Location = new System.Drawing.Point(27, 309);
            this.button_Scoreboard.Name = "button_Scoreboard";
            this.button_Scoreboard.Size = new System.Drawing.Size(248, 29);
            this.button_Scoreboard.TabIndex = 17;
            this.button_Scoreboard.Text = "Scoreboard";
            this.button_Scoreboard.UseVisualStyleBackColor = false;
            this.button_Scoreboard.Click += new System.EventHandler(this.button_Scoreboard_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.button_SignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.linkLabel_SignOut;
            this.ClientSize = new System.Drawing.Size(302, 473);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 250);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Who Want To Be A Millionare?";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox_Login.ResumeLayout(false);
            this.groupBox_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Scoreboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox_Login;
        private System.Windows.Forms.LinkLabel linkLabel_SignOut;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.TextBox textBox_UserPass2;
        private System.Windows.Forms.TextBox textBox_UserPass;
        private System.Windows.Forms.Label label_UserPass2;
        private System.Windows.Forms.Label label_UserPass;
        private System.Windows.Forms.Button button_SignUp;
        private System.Windows.Forms.Button button_SignIn;
        private System.Windows.Forms.DataGridView dataGridView_Scoreboard;
        private System.Windows.Forms.Button button_Scoreboard;
    }
}