using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHangP2.DataBaseWebBH
{
    [Table("vhCategory")]
    public class vhCategoryEntity
    {
        [Key]
        public int idCategory { get; set; }
        public string nameCategory { get; set; }

        public string imgCategory { get; set; }
    }
}
