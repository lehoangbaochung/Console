namespace FruitStoreManager.Models
{
    class Bill
    {
        public object ID { get; set; }
        public object CustomerName { get; set; }
        public object PaymentMethod { get; set; }
        public object EmployeeID { get; set; }
        public object Time { get; set; }
        public object Total { get; set; }
    }

    class BillDetail
    {
        public object BillID { get; set; }
        public object ProductID { get; set; }
        public object ProductName { get; set; }
        public object Count { get; set; }
        public object Price { get; set; }
        public object Sum { get; set; }
    }
}
