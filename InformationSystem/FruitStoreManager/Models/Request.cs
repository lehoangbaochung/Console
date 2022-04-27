namespace FruitStoreManager.Models
{
    internal class Request
    {
        public object Time { get; set; }
        public object EmployeeID { get; set; }
        public object Title { get; set; }
        public object Content { get; set; }
        public object Reply { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var request = (Request)obj;
            return EmployeeID == request.EmployeeID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
