using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHangP2.DataBaseWebBH
{
    [Table("vhUser")]
    public class vhUserEntity
    {
        [Key]
        public int idUser { get; set; }
        public string nameUser { get; set; }
        public string accountUser { get; set; }
        public string passwordUser { get; set; }
        public bool isBan { get; set; }
        public bool isAdmin { get; set; }
        public string emailUser { get; set; }
        public string addressUser { get; set; }
        public string phoneUser { get; set; }
        public string storyUser { get; set; }
        public string imgUser { get; set; }
    }
}
