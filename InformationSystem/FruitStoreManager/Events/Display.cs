using FruitStoreManager.Models;

namespace FruitStoreManager.Events
{
    internal class Display
    {
        public static void Form(Account account, MainElement main)
        {
            if (account.Permission.ToString() == "Quản lý")
            {
                main.TabControl.TabPages.Insert(1, "Employee");
                main.TabControl.TabPages.Insert(2, "Account");
                main.TabControl.TabPages.Insert(3, "Statistic");
            }

            if (account.Permission.ToString() == "Nhân viên")
            {
                main.TabControl.TabPages.Insert(1, "Bill");
                main.TabControl.TabPages.Insert(2, "Customer");
            }

            main.Form.Text = "F99 Fruit Store Manager - Permission: " + account.Permission + " - Username: " + account.Username;
            Information.LoginPermission(account);
        }

        public static void Account(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "ID", "Permission" });
            ///
            main.DataGridView.DataSource = BindingList.Account;
            main.DataGridView.Columns["ID"].Visible = false;
            ///
            main.ButtonAdd.Enabled = true;
            main.ButtonEdit.Enabled = true;
            main.ButtonDelete.Enabled = true;
            main.ButtonMore.Enabled = false;

            main.ButtonMore.Text = "More";
        }

        public static void Bill(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Customer name", "Time", "Total", "Payment method" });
            ///
            main.DataGridView.DataSource = BindingList.Bill;
            main.DataGridView.Columns["ID"].Visible = false;
            main.DataGridView.Columns["EmployeeID"].Visible = false;
            ///
            main.ButtonEdit.Enabled = false;
            main.ButtonDelete.Enabled = false;
            main.NumericUpDown.Visible = false;

            if (List.Cart.Count == 0)
                main.ButtonAdd.Enabled = false;
            else
                main.ButtonAdd.Enabled = true;

            if (BindingList.Bill.Count == 0)
                main.ButtonMore.Enabled = false;
            else
                main.ButtonMore.Enabled = true;

            main.ButtonMore.Text = "Detail";
        }

        public static void BillDetail(MainElement main)
        {
            main.RichTextBox.ResetText();

            var detailList = List.BillDetail.FindAll(s => s.BillID.Equals(main.DataGridView.CurrentRow.Cells["ID"].Value));

            foreach (var item in detailList)
            {
                main.RichTextBox.Text += $"Product ID: {item.ProductID}\nProduct name: {item.ProductName}\nCount: {item.Count}\nPrice: {item.Price}\nSum: {item.Sum}\n\n";
            }
        }

        public static void Cart(MainElement main)
        {
            main.RichTextBox.ResetText();

            foreach (var item in List.Cart)
            {
                main.RichTextBox.Text += $"Product ID: {item.ProductID}\nProduct name: {item.ProductName}\nCount: {item.Count}\nPrice: {item.Price}\nSum: {item.Sum}\n\n";
            }
        }

        public static void Customer(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Name", "Address", "Phone Number", "Email" });
            ///
            main.DataGridView.DataSource = BindingList.Customer;
            main.DataGridView.Columns["ID"].Visible = false;
            ///
            main.ButtonAdd.Enabled = true;
            main.ButtonEdit.Enabled = true;
            main.ButtonDelete.Enabled = false;
            main.ButtonMore.Enabled = false;

            main.ButtonMore.Text = "More";
        }

        public static void Employee(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Employee ID", "Name", "Age", "Address", "Phone number", "Salary", "Worktime" });
            ///
            main.DataGridView.DataSource = BindingList.Employee;
            main.DataGridView.Columns["ID"].Visible = false;
            ///
            main.ButtonAdd.Enabled = true;
            main.ButtonEdit.Enabled = true;
            main.ButtonDelete.Enabled = true;
            main.ButtonMore.Enabled = false;
            main.NumericUpDown.Visible = false;

            main.ButtonMore.Text = "More";
        }    

        public static void Product(Account account, MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Name", "Origin", "Quantity", "Price", "Import date", "Expiration", "Description" });
            ///
            main.DataGridView.DataSource = BindingList.Product;
            ///
            if (account.Permission.ToString() == "Quản lý")
            {
                main.ButtonAdd.Enabled = true;
                main.ButtonEdit.Enabled = true;
                main.ButtonDelete.Enabled = true;
                main.ButtonMore.Enabled = false;
                main.NumericUpDown.Visible = false;

                main.ButtonMore.Text = "More";
            }
            
            if (account.Permission.ToString() == "Nhân viên")
            {
                main.ButtonAdd.Enabled = true;
                main.ButtonEdit.Enabled = false;
                main.ButtonDelete.Enabled = false;
                main.NumericUpDown.Visible = true;

                if (List.Cart.Count == 0)
                    main.ButtonMore.Enabled = false;
                else
                    main.ButtonMore.Enabled = true;

                main.ButtonMore.Text = "Cart";
            }
        }

        public static void Request(Account account, MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Time", "Employee ID", "Tilte", "Content", "Status" });
            ///
            main.DataGridView.DataSource = BindingList.Request;
            ///
            main.ButtonDelete.Enabled = false;
            main.ButtonMore.Enabled = true;
            main.NumericUpDown.Visible = false;

            main.ButtonMore.Text = "Detail";

            if (account.Permission.ToString() == "Quản lý")
            {
                main.ButtonAdd.Enabled = false;
                main.ButtonEdit.Enabled = true;
            }

            if (account.Permission.ToString() == "Nhân viên")
            {
                main.ComboBox.Items.Remove("Employee ID");
                ///
                main.DataGridView.Columns["EmployeeID"].Visible = false;
                ///
                main.ButtonAdd.Enabled = true;
                main.ButtonEdit.Enabled = false;
            }
        }

        public static void RequestDetail(MainElement main)
        {
            main.RichTextBox.ResetText();
            main.RichTextBox.Text = main.DataGridView.CurrentRow.Cells[main.DataGridView.CurrentCell.OwningColumn.Name].Value?.ToString();
        }

        public static void Sale(MainElement main)
        {
            main.RichTextBox.ResetText();

            foreach (var item in List.Bill)
            {
                main.RichTextBox.Text += $"Bill ID: {item.ID}\nEmployee ID: {item.EmployeeID}\nCustomer name: {item.CustomerName}\nTime: {item.Time}" +
                    $"\nTotal: {item.Total}\nPayment method: {item.PaymentMethod}\n\n";
            }
        }   
        
        public static void Statistic(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Day", "Month", "Year" });
            ///
            main.DataGridView.DataSource = BindingList.Statistic;
            ///
            main.ButtonAdd.Enabled = false;
            main.ButtonEdit.Enabled = false;
            main.ButtonDelete.Enabled = false;
            main.ButtonMore.Enabled = true;
            main.NumericUpDown.Visible = false;

            main.ButtonMore.Text = "Detail";
        }    
    }
}
