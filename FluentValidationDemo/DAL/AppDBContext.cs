using FluentValidationDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationDemo.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public DbSet<MotherBoard> MotherBoards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FluentValidationDemoDB");
        }
    }
}
