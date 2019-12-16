using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PBJProject.Domain.Models;

namespace PBJProject.Storing
{
  public class PbjDbContext : DbContext
  {
    public DbSet<Account> Account { get; set; }
    public DbSet<Character> Character { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
    {
      dbContext.UseNpgsql("server=db;database=pbjproject;user id=postgres;password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Account>(o => o.HasKey(k => k.AccountId));
      builder.Entity<Account>().Property(p => p.AccountId)
                     .ValueGeneratedOnAdd()
                     .UseSerialColumn();

      builder.Entity<Account>().HasData(new List<Account>()
      {
        new Account(){ AccountId = 1,
                       UserName = "jguillo",
                       FirstName = "Joshua",
                       LastName = "Guillory",
                       Password = "revature7",
                       Email = "joshua@familiar.com" },
        new Account(){ AccountId = 2,
                       UserName = "phillip",
                       FirstName = "Phillip",
                       LastName = "Krawetz",
                       Password = "revature8",
                       Email = "phillip@familiar.com" },
        new Account(){ AccountId = 3,
                       UserName = "sven",
                       FirstName = "Benjamin",
                       LastName = "Clegg",
                       Password = "revature9",
                       Email = "benjamin@familiar.com" },
        new Account(){ AccountId = 4,
                       UserName = "lisa",
                       FirstName = "Phillip",
                       LastName = "Krawetz",
                       Password = "revature8",
                       Email = "phillip@familiar.com" }
      });

      builder.Entity<Character>(o => o.HasKey(k => k.CharacterId));
      builder.Entity<Character>().Property(p => p.CharacterId)
                           .ValueGeneratedOnAdd()
                           .UseSerialColumn();

      builder.Entity<Character>().HasData(new List<Character>()
      {
         new Character(){ CharacterId = 1,
                          AccountId = 3,
                          Level = 1,
                          Name = "Dummy",
                          Race = "Human",
                          CharacterClass = "Fighter",
                          Strength = 18,
                          Intelligence = 8,
                          Dexterity = 12,
                          Wisdom = 10,
                          Charisma = 10,
                          Constitution = 16
                         },
         new Character(){ CharacterId = 2,
                           AccountId = 2,
                           Level = 1,
                           Name = "Silly",
                           Race = "Human",
                           CharacterClass = "Rogue",
                           Strength = 10,
                           Intelligence = 10,
                           Dexterity = 10,
                           Wisdom = 10,
                           Charisma = 10,
                           Constitution = 10
                        },
         new Character(){ CharacterId = 3,
                          AccountId = 2,
                          Level = 1,
                          Name = "Testing",
                          Race = "Human",
                          CharacterClass = "Bard",
                          Strength = 10,
                          Intelligence = 10,
                          Dexterity = 10,
                          Wisdom = 10,
                          Charisma = 10,
                          Constitution = 10
                        },
         });
      }
    }
}