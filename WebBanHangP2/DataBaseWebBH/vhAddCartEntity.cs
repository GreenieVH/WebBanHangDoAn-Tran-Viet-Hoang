using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHangP2.DataBaseWebBH
{
    [Table("vhAddCart")]
    public class vhAddCartEntity
    {
        [Key]
        public int idAddCart { get; set; }
        public string nameProductAddCart { get; set; }
        public Decimal priceProductAddCart { get; set; }
        public Decimal priceTotal { get; set; }
        public string imgProductAddCart { get; set; }
        public int quantity { get; set; }
        public int idUser { get; set; }
        public int idProduct { get; set; }
    }
}
