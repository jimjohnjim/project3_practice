using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PBJProject.Domain.Models;

namespace PBJProject.Domain
{
  public class PbjDbContext : DbContext
  {
    public DbSet<Account> Account { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
    {
      dbContext.UseNpgsql("server=localhost;database=postgres;user id=postgres;password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Account>(o => o.HasKey(k => k.Id));
      builder.Entity<Account>().Property(p => p.Id).UseSerialColumn();

      builder.Entity<Account>().HasData(new List<Account>()
      {
        new Account(){ UserName = "jguillo",
                       FirstName = "Joshua",
                       LastName = "Guillory",
                       Password = "revature7",
                       Email = "joshua@familiar.com" },
        new Account(){ UserName = "phillip",
                       FirstName = "Phillip",
                       LastName = "Krawetz",
                       Password = "revature8",
                       Email = "phillip@familiar.com" },
        new Account(){ UserName = "sven",
                       FirstName = "Benjamin",
                       LastName = "Clegg",
                       Password = "revature9",
                       Email = "benjamin@familiar.com" },
        new Account(){ UserName = "lisa",
                       FirstName = "Phillip",
                       LastName = "Krawetz",
                       Password = "revature8",
                       Email = "phillip@familiar.com" }
      });
    }
  }
}
