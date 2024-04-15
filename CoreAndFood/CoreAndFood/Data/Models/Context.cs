using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Data.Models
{
    public class Context : DbContext 
    {       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ALIKOC\\SQLEXPRESS; database=DbCoreAndFood; integrated security=true; TrustServerCertificate=true");
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Icerik> Iceriks { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
