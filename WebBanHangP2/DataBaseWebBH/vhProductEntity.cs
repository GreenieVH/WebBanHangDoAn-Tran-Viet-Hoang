using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHangP2.DataBaseWebBH
{
    [Table("vhProduct")]
    public class vhProductEntity
    {
        [Key]
        public int idProduct { get; set; }
        public string nameProduct { get; set; }
        public Decimal priceProduct { get; set; }
        public Decimal priceSaleProduct { get; set; }
        public int idCategory { get; set;}
        public int idSystem { get; set; }
        public string imgProduct { get; set; }
        public bool newProduct { get; set; }
    }
}
