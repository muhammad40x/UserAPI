using Microsoft.EntityFrameworkCore;
using UserAPI.Entites;

namespace UserAPI.Context
{
    public class AppDbContext :DbContext
    {
        public DbSet<Foydalanuvchi> Foydalanuvchi { get; set; }
        public AppDbContext(DbContextOptions options):base(options) 
        {

        }
    }
}
