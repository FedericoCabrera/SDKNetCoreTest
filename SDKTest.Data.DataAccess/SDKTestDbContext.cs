using Microsoft.EntityFrameworkCore;
using SDKTest.Data.Entities;
using System;

namespace SDKTest.Data.DataAccess
{
    public class SDKTestDbContext:DbContext
    {
        public SDKTestDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Traject> Trajects { get; set; }
    }
}
