using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PBJProject.Domain.Models;

namespace PBJProject.Domain
{
  public class PbjDbContext : DbContext
  {
    public DbSet<Account> Account { get; set; }
    public DbSet<Character> Character { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
    {
      dbContext.UseNpgsql("server=localhost;database=pbjproject;user id=postgres;password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Account>(o => o.HasKey(k => k.ID));
      builder.Entity<Account>().Property(p => p.ID)
                     .UseSerialColumn();

      builder.Entity<Account>().HasData(new List<Account>()
      {
        new Account(){ ID = 1,
                       UserName = "jguillo",
                       FirstName = "Joshua",
                       LastName = "Guillory",
                       Password = "revature7",
                       Email = "joshua@familiar.com" },
        new Account(){ ID = 2,
                       UserName = "phillip",
                       FirstName = "Phillip",
                       LastName = "Krawetz",
                       Password = "revature8",
                       Email = "phillip@familiar.com" },
        new Account(){ ID = 3,
                       UserName = "sven",
                       FirstName = "Benjamin",
                       LastName = "Clegg",
                       Password = "revature9",
                       Email = "benjamin@familiar.com" },
        new Account(){ ID = 4,
                       UserName = "lisa",
                       FirstName = "Phillip",
                       LastName = "Krawetz",
                       Password = "revature8",
                       Email = "phillip@familiar.com" }
      });

      builder.Entity<Character>(o => o.HasKey(k => k.ID));
      builder.Entity<Character>().Property(p => p.ID).UseSerialColumn();

      builder.Entity<Character>().HasData(new List<Character>()
      {
         new Character(){ ID = 1,
                          Level = 1,
                          Name = "Dummy",
                          Race = "Human",
                          Strength = 18,
                          Intelligence = 8,
                          Dexterity = 12,
                          Wisdom = 10,
                          Charisma = 10,
                          Constitution = 16,
                          CharacterClass = "Fighter" }
         });
      }
    }
}