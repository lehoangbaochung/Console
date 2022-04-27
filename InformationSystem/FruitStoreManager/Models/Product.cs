namespace FruitStoreManager.Models
{
    class Product
    {
        public object ID { get; set; }
        public object Name { get; set; }
        public object Origin { get; set; }
        public object Quantity { get; set; }
        public object Price { get; set; }
        public object ImportDate { get; set; }
        public object Expiration { get; set; }
        public object Description { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var product = (Product)obj;
            return ID == product.ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
