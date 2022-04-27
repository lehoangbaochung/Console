using FruitStoreManager.Models;

namespace FruitStoreManager.Functions
{
    internal class Get
    {
        public static void Data(Account account)
        {
            Product();
            Bill(account);
            Request(account);

            if (account.Permission.ToString() == "Quản lý")
            {
                Employee();
                Statistic();
            }    

            if (account.Permission.ToString() == "Nhân viên")
            {
                Customer();
                BillDetail();
            }     
        }

        public static void Account()
        {
            BindingList.Account.Clear();

            foreach (var item in Execute.Read("account")["account"])
            {
                var account = new Account()
                {
                    ID = item["ID"],
                    Username = item["Username"],
                    Password = item["Password"],
                    Permission = item["Permission"]
                };

                List.Account.Add(account);

                if (item["Username"] != null) BindingList.Account.Add(account);
            }
        }

        private static void Bill(Account account)
        {
            List.Bill.Clear();
            BindingList.Bill.Clear();

            foreach (var item in Execute.Read("bill")["bill"])
            {
                var bill = new Bill()
                {
                    ID = item["ID"],
                    CustomerName = item["CustomerName"],
                    EmployeeID = item["EmployeeID"],
                    Time = item["Time"],
                    Total = item["Total"],
                    PaymentMethod = item["PaymentMethod"]
                };

                List.Bill.Add(bill);

                if (bill.EmployeeID.Equals(account.Username)) BindingList.Bill.Add(bill);
            }
        }

        private static void BillDetail()
        {
            List.BillDetail.Clear();

            foreach (var item in Execute.Read("billdetail")["billdetail"])
            {
                var detail = new BillDetail()
                {
                    BillID = item["BillID"],
                    ProductID = item["ProductID"],
                    ProductName = item["ProductName"],
                    Count = item["Count"],
                    Price = item["Price"],
                    Sum = item["Sum"]
                };

                List.BillDetail.Add(detail);
            }
        }

        private static void Customer()
        {
            BindingList.Customer.Clear();

            foreach (var item in Execute.Read("customer")["customer"])
            {
                var customer = new Customer()
                {
                    ID = item["ID"],
                    Name = item["Name"],
                    Address = item["Address"],
                    PhoneNumber = item["PhoneNumber"],
                    Email = item["Email"]
                };

                if (item["ID"] != null) BindingList.Customer.Add(customer);
            }
        }

        private static void Employee()
        {
            List.Employee.Clear();
            BindingList.Employee.Clear();

            foreach (var item in Execute.Read("employee")["employee"])
            {
                var employee = new Employee()
                {
                    ID = item["ID"],
                    EmployeeID = item["EmployeeID"],
                    Name = item["Name"],
                    Age = item["Age"],
                    Address = item["Address"],
                    PhoneNumber = item["PhoneNumber"],
                    Salary = item["Salary"],
                    Worktime = item["Worktime"]
                };

                List.Employee.Add(employee);

                if (item["ID"] != null) BindingList.Employee.Add(employee);
            }
        }

        private static void Product()
        {
            List.Product.Clear();
            BindingList.Product.Clear();

            foreach (var item in Execute.Read("product")["product"])
            {
                var product = new Product()
                {
                    ID = item["ID"],
                    Name = item["Name"],
                    Origin = item["Origin"],
                    Quantity = item["Quantity"],
                    Price = item["Price"],
                    ImportDate = item["ImportDate"],
                    Expiration= item["Expiration"],
                    Description = item["Description"]
                };

                List.Product.Add(product);

                // not bind expired items
                var date = System.Convert.ToDateTime(item["ImportDate"]);
                date = date.AddDays((double)item["Expiration"] / 7);

                if (System.DateTime.Compare(date, System.DateTime.Now) < 0 && item["ID"] != null) BindingList.Product.Add(product);
            }
        }

        private static void Request(Account account)
        {
            BindingList.Request.Clear();

            foreach (var item in Execute.Read("request")["request"])
            {
                var request = new Request()
                {
                    EmployeeID = item["EmployeeID"],
                    Title = item["Title"],
                    Content = item["Content"],
                    Time = item["Time"],
                    Reply = item["Reply"]
                };

                if (account.Permission.ToString() == "Quản lý")
                {
                    BindingList.Request.Add(request);
                }    
                
                if (account.Permission.ToString() == "Nhân viên")
                {
                    if (account.Username.ToString() == request.EmployeeID.ToString())
                    {
                        BindingList.Request.Add(request);
                    }    
                }    
            }
        }

        private static void Statistic()
        {
            BindingList.Statistic.Clear();

            var sum = 0;

            foreach (var item in List.Bill)
            {
                sum += System.Convert.ToInt32(item.Total);
            }   
            
            var statistic = new Statistic() 
            { 
                Time = "Total",
                Employee = BindingList.Employee.Count,
                Product = BindingList.Product.Count,
                Sale = sum
            };

            BindingList.Statistic.Add(statistic);
        }
    }
}