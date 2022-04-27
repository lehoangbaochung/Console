using FruitStoreManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FruitStoreManager.Events
{
    internal class Search
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Bill> bills = new List<Bill>();
        private static List<Customer> customers = new List<Customer>();
        private static List<Employee> employees = new List<Employee>();
        private static List<Product> products = new List<Product>();
        private static List<Request> requests = new List<Request>();
        private static List<Statistic> statistics = new List<Statistic>();

        public static void Account(MainElement main)
        {
            switch (main.ComboBox.SelectedItem)
            {
                case "Username":
                    accounts = BindingList.Account.ToList().FindAll(s => s.ID.ToString().ToLower().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Account>(accounts);
                    break;
                case "Permission":
                    accounts = BindingList.Account.ToList().FindAll(s => s.Permission.ToString().ToLower().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Account>(accounts);
                    break;
            }
        }

        public static void Bill(MainElement main)
        {
            switch (main.ComboBox.SelectedItem)
            {
                case "Customer name":
                    bills = BindingList.Bill.ToList().FindAll(s => s.CustomerName.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Bill>(bills);
                    break;
                case "Time":
                    bills = BindingList.Bill.ToList().FindAll(s => s.Time.ToString().ToLower().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Bill>(bills);
                    break;
                case "Total":
                    bills = BindingList.Bill.ToList().FindAll(s => s.Total.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Bill>(bills);
                    break;
                case "Payment method":
                    bills = BindingList.Bill.ToList().FindAll(s => s.PaymentMethod.ToString().ToLower().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Bill>(bills);
                    break;
            }
        }

        public static void Customer(MainElement main)
        {
            switch (main.ComboBox.SelectedItem)
            {
                case "Name":
                    customers = BindingList.Customer.ToList().FindAll(s => s.Name.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Customer>(customers);
                    break;
                case "Address":
                    customers = BindingList.Customer.ToList().FindAll(s => s.Address.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Customer>(customers);
                    break;
                case "Phone number":
                    customers = BindingList.Customer.ToList().FindAll(s => s.PhoneNumber.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Customer>(customers);
                    break;
                case "Email":
                    customers = BindingList.Customer.ToList().FindAll(s => s.Email.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Customer>(customers);
                    break;
            }
        }

        public static void Employee(MainElement main)
        {
            switch (main.ComboBox.SelectedItem)
            {
                case "Employee ID":
                    employees = BindingList.Employee.ToList().FindAll(s => s.EmployeeID.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Employee>(employees);
                    break;
                case "Name":
                    employees = BindingList.Employee.ToList().FindAll(s => s.Name.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Employee>(employees);
                    break;
                case "Address":
                    employees = BindingList.Employee.ToList().FindAll(s => s.Address.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Employee>(employees);
                    break;
                case "Phone number":
                    employees = BindingList.Employee.ToList().FindAll(s => s.PhoneNumber.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Employee>(employees);
                    break;
                case "Age":
                    employees = BindingList.Employee.ToList().FindAll(s => s.PhoneNumber.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Employee>(employees);
                    break;
                case "Salary":
                    employees = BindingList.Employee.ToList().FindAll(s => s.Salary.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Employee>(employees);
                    break;
                case "Worktime":
                    employees = BindingList.Employee.ToList().FindAll(s => s.Worktime.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Employee>(employees);
                    break;
            }
        }

        public static void Product(MainElement main)
        {
            switch (main.ComboBox.SelectedItem)
            {
                case "Name":
                    products = BindingList.Product.ToList().FindAll(s => s.Name.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Product>(products);
                    break;
                case "Origin":
                    products = BindingList.Product.ToList().FindAll(s => s.Origin.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Product>(products);
                    break;
                case "Price":
                    products = BindingList.Product.ToList().FindAll(s => s.Price.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Product>(products);
                    break;
                case "Quantity":
                    products = BindingList.Product.ToList().FindAll(s => s.Quantity.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Product>(products);
                    break;
                case "Import date":
                    products = BindingList.Product.ToList().FindAll(s => s.ImportDate.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Product>(products);
                    break;
                case "Expiration":
                    products = BindingList.Product.ToList().FindAll(s => s.Expiration.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Product>(products);
                    break;
                case "Description":
                    products = BindingList.Product.ToList().FindAll(s => s.Description.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Product>(products);
                    break;
            }
        }

        public static void Request(MainElement main)
        {
            switch (main.ComboBox.SelectedItem)
            {
                case "Employee ID":
                    requests = BindingList.Request.ToList().FindAll(s => s.EmployeeID.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Request>(requests);
                    break;
                case "Title":
                    requests = BindingList.Request.ToList().FindAll(s => s.Title.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Request>(requests);
                    break;
                case "Content":
                    requests = BindingList.Request.ToList().FindAll(s => s.Content.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Request>(requests);
                    break;
                case "Time":
                    requests = BindingList.Request.ToList().FindAll(s => s.Time.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Request>(requests);
                    break;
                case "Status":
                    requests = BindingList.Request.ToList().FindAll(s => s.Reply.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Request>(requests);
                    break;
            }
        }
        
        public static void Statistic(MainElement main)
        {
            switch (main.ComboBox.SelectedItem)
            {
                case "Day":
                    statistics = BindingList.Statistic.ToList().FindAll(s => s.Time.ToString().ToLower().Contains(main.TextBox.Text.ToLower()));
                    main.DataGridView.DataSource = new BindingList<Statistic>(statistics);
                    break;
                case "Month":
                    statistics = BindingList.Statistic.ToList().FindAll(s => s.Sale.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Statistic>(statistics);
                    break;
                case "Year":
                    statistics = BindingList.Statistic.ToList().FindAll(s => s.Product.ToString().Contains(main.TextBox.Text));
                    main.DataGridView.DataSource = new BindingList<Statistic>(statistics);
                    break;
            }
        }
    }
}
