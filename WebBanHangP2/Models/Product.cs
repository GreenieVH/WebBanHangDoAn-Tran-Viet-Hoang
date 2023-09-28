namespace WebBanHangP2.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        public string nameProduct { get; set; }
        public Decimal priceProduct { get; set; }
        public Decimal priceSaleProduct { get; set; }
        public int idCategory { get; set; }
        public int idSystem { get; set; }
        public string nameSystem { get; set; }
        public string imgProduct { get; set; }
        public bool newProduct { get; set; }
        public  string nameCategory { get; set; }

        internal static object Count()
        {
            throw new NotImplementedException();
        }

        internal static object OrderBy(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
