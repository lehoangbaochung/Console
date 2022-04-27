namespace FruitStoreManager.Models
{
    internal class Account
    {
        public object ID { get; set; }
        public object Username { get; set; }
        public object Password { get; set; }
        public object Permission { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var account = (Account)obj;
            return ID == account.ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
