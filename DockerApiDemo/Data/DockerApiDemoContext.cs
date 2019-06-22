using DockerApiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerApiDemo.Data
{
    public class DockerApiDemoContext : DbContext
    {
        public DockerApiDemoContext(DbContextOptions<DockerApiDemoContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new
                {
                    Id = 1,
                    FirstName = "Max",
                    LastName = "Verstappen",
                    Email = "m.verstappen@redbull.com",
                    Password = "No1R4cer"
                },
                new
                {
                    Id = 2,
                    FirstName = "Daniel",
                    LastName = "Ricciardo",
                    Email = "d.ricciardo@renault.com",
                    Password = "b1gSM1L35"
                },
                new
                {
                    Id = 3,
                    FirstName = "Kimi",
                    LastName = "Raikkonen",
                    Email = "k.raikkonen@alfaromeo.com",
                    Password = "1W4SHaving4!*&$"
                });
        }
    }
}
