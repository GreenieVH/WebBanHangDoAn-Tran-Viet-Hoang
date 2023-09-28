using Microsoft.EntityFrameworkCore;

namespace WebBanHangP2.DataBaseWebBH
{
    public class NewDbContext:DbContext
    {
        public NewDbContext(DbContextOptions<NewDbContext>options):base(options) {}
        public DbSet<vhUserEntity> UserEntities { get; set; }
        public DbSet<vhCategoryEntity> CategoryEntities { get; set; }
        public DbSet<vhSystemEntity> SystemEntities { get; set; }
        public DbSet<vhProductEntity> ProductEntities { get; set; }  
        public DbSet<vhAddCartEntity> AddCartEntities { get; set; }
        public DbSet<vhContactEntity> ContactEntities { get; set; }

    }
}

