using FruitStoreManager.Models;
using FruitStoreManager.Events;
using FruitStoreManager.Functions;
using System;
using System.Windows.Forms;

namespace FruitStoreManager.Forms
{
    public partial class MainForm : Form
    {
        private static MainElement main;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            main = new MainElement()
            {
                Form = this,
                TabControl = tabCtrl,
                DataGridView = dgvTable,
                RichTextBox = rtbxDetail,
                ComboBox = cbxFilter,
                TextBox = tbxSearch,
                NumericUpDown = nudCount,
                ButtonAdd = btnAdd,
                ButtonEdit = btnEdit,
                ButtonDelete = btnDelete,
                ButtonMore = btnMore,
                ButtonSearch = btnSearch,
                ButtonLogout = btnLogOut
            };

            Get.Data(Check.AccountInfo);
            Display.Form(Check.AccountInfo, main);
            Display.Product(Check.AccountInfo, main);
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.ResetText();
            cbxFilter.ResetText();
            cbxFilter.Items.Clear();

            switch (tabCtrl.SelectedTab.Text)
            {
                case "Account":
                    Display.Account(main);
                    break;
                case "Bill":
                    Display.Bill(main);
                    break;
                case "Customer":
                    Display.Customer(main);
                    break;
                case "Employee":
                    Display.Employee(main);
                    break;
                case "Product":
                    Display.Product(Check.AccountInfo, main);
                    break;
                case "Request":
                    Display.Request(Check.AccountInfo, main);
                    break;
                case "Statistic":
                    Display.Statistic(main);
                    break;
            }

            dgvTable.ReadOnly = true;
            dgvTable.AllowUserToAddRows = false;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";
            btnDelete.Text = "Delete";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabCtrl.SelectedTab.Text == "Product" && Check.AccountInfo.Permission.ToString() == "Nhân viên")
            {
                Add.Cart(main.DataGridView, main.NumericUpDown);
                Display.Cart(main);
                nudCount.ResetText();

                if (List.Cart.Count == 0)
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            } 
            else
            {
                if (btnAdd.Text == "Add")
                {
                    btnAdd.Text = "Save";
                    dgvTable.ReadOnly = false;
                    dgvTable.AllowUserToAddRows = true;
                    ///
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnMore.Enabled = false;
                    btnSearch.Enabled = false;
                }  
                else if (btnAdd.Text == "Save")
                {
                    if (!Question.Add()) return;
                    ///
                    btnAdd.Text = "Add";
                    dgvTable.ReadOnly = true;
                    dgvTable.AllowUserToAddRows = false;
                    ///
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnMore.Enabled = true;
                    btnSearch.Enabled = true;
                    ///
                    Execute.Insert(main);
                }    
            }    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tabCtrl.SelectedTab.Text == "Product" && Check.AccountInfo.Permission.ToString() == "Nhân viên")
            {
                Edit.Cart(main.DataGridView, main.NumericUpDown);
                Display.Cart(main);
            }
            else
            {
                if (btnEdit.Text == "Edit")
                {
                    btnEdit.Text = "Save";
                    dgvTable.ReadOnly = false;
                    ///
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    btnMore.Enabled = false;
                    btnSearch.Enabled = false;
                }
                else if (btnEdit.Text == "Save")
                {
                    var result = MessageBox.Show("Are you sure to edit?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No) return;
                    ///
                    btnEdit.Text = "Edit";
                    dgvTable.ReadOnly = true;
                    ///
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSearch.Enabled = true;
                    btnMore.Enabled = true;
                    ///
                    Execute.Update(main);
                    Information.Success();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Question.Delete()) return;

            if (tabCtrl.SelectedTab.Text == "Product" && Check.AccountInfo.Permission.ToString() == "Nhân viên")
            {
                Remove.Item(main.DataGridView);
                Display.Cart(main);

                if (List.Cart.Count == 0)
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                Execute.Delete(main);
                Information.Success();
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            if (btnMore.Text == "Detail")
            {
                if (main.TabControl.SelectedTab.Text == "Bill") Display.BillDetail(main);

                if (main.TabControl.SelectedTab.Text == "Request") Display.RequestDetail(main);

                if (main.TabControl.SelectedTab.Text == "Statistic") Display.Sale(main);
            }    
                
            else if (btnMore.Text == "Cart")
                Display.Cart(main);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (main.TabControl.SelectedTab.Text)
            {
                case "Account":
                    Search.Account(main);
                    break;
                case "Bill":
                    Search.Bill(main);
                    break;
                case "Customer":
                    Search.Customer(main);
                    break;
                case "Employee":
                    Search.Employee(main);
                    break;
                case "Product":
                    Search.Product(main);
                    break;
                case "Request":
                    Search.Request(main);
                    break;
                case "Statistic":
                    Search.Statistic(main);
                    break;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (!Question.Logout()) return;

            new LoginForm().Show();
            Close();
        } 
    }
}
