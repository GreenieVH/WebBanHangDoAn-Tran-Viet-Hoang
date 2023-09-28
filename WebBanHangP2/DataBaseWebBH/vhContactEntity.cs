using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHangP2.DataBaseWebBH
{

    [Table("vhContact")]
    public class vhContactEntity
    {
        [Key]
        public int idContact { get; set; }
        public string nameUserContact { get; set; }
        public string emailEmailContact { get; set; }
        public string subjectContact { get; set; }
        public string messageContact { get; set; }
        public int idUser { get; set; }
    }
}
