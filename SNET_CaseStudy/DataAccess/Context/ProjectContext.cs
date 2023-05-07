using Microsoft.EntityFrameworkCore;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.DataAccess.Context
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=desktop-d7evafe;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}