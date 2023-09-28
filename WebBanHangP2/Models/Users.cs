namespace WebBanHangP2.Models
{
    public class Users
    {
        public int idUser { get; set; }
        public string nameUser { get; set; }
        public string accountUser { get; set; }
        public string passwordUser { get; set; }
        public string passwordUserCheck { get; set; }
        public bool isBan { get; set; }
        public bool isAdmin { get; set; }
        public string isAdminString { get; set; }
        public string isBanString { get; set; }
        public string emailUser { get; set; }
        public string addressUser { get; set; }
        public string phoneUser { get; set; }
        public string storyUser { get; set; }
        public string imgUser { get; set; }
    }
}
