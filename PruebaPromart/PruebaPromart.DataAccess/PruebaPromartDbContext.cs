using Microsoft.EntityFrameworkCore;
using PruebaPromart.Entities;
using System.Reflection;

namespace PruebaPromart.DataAccess
{
    public class PruebaPromartDbContext : DbContext
    {
        public PruebaPromartDbContext()
        {

        }
        public PruebaPromartDbContext(DbContextOptions<PruebaPromartDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
        }
    }
}
