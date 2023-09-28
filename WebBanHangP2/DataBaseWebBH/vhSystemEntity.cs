using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHangP2.DataBaseWebBH
{
    [Table("vhSystem")]
    public class vhSystemEntity
    {
        [Key]
        public int idSystem { get; set; }
        public string nameSystemn { get; set; }
    }
}
