namespace WebBanHangP2.Models
{
    public class ModleAllClass
    {
        public List<Users>Users { get; set; }
        public List<SystemProduct> System { get; set; }
        public List<Product> Product { get; set; }
        public List<Product> ProductRandom { get; set; }
        public List<Category> Category { get; set; }
        public List<ContactUser> ContactUserS { get; set; }
        public List<AddCart> AddCart { get; set; }
        public int ToolCont { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }

    }
}
