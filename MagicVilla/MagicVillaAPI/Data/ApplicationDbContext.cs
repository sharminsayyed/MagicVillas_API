using MagicVillaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}
        public DbSet<Villa> Villas { get; set; } // table name in the database

    }
}
