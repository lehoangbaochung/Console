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
    public partial class Main : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-OUF6DI5\SQLEXPRESS;Initial Catalog=TuDien;Integrated Security=True";
        SqlConnection conn = null;
        //SqlCommand cmd;
        SqlDataAdapter daTA;
        DataTable dtTA;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string sql = "Select * from TiengAnh";
            daTA = new SqlDataAdapter(sql, conn);
            dtTA = new DataTable();
            daTA.Fill(dtTA);
            dataGridView_KhoTu.DataSource = dtTA;
        }
    }
}
