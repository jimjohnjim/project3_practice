﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PBJProject.Domain;

namespace PBJProject.Storing.Migrations
{
    [DbContext(typeof(PbjDbContext))]
    partial class PbjDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PBJProject.Domain.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "joshua@familiar.com",
                            FirstName = "Joshua",
                            LastName = "Guillory",
                            Password = "revature7",
                            UserName = "jguillo"
                        },
                        new
                        {
                            ID = 2,
                            Email = "phillip@familiar.com",
                            FirstName = "Phillip",
                            LastName = "Krawetz",
                            Password = "revature8",
                            UserName = "phillip"
                        },
                        new
                        {
                            ID = 3,
                            Email = "benjamin@familiar.com",
                            FirstName = "Benjamin",
                            LastName = "Clegg",
                            Password = "revature9",
                            UserName = "sven"
                        },
                        new
                        {
                            ID = 4,
                            Email = "phillip@familiar.com",
                            FirstName = "Phillip",
                            LastName = "Krawetz",
                            Password = "revature8",
                            UserName = "lisa"
                        });
                });

            modelBuilder.Entity("PBJProject.Domain.Models.Character", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("integer");

                    b.Property<string>("CharacterClass")
                        .HasColumnType("text");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Race")
                        .HasColumnType("text");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CharacterClass = "Fighter",
                            Charisma = 10,
                            Constitution = 16,
                            Dexterity = 12,
                            Intelligence = 8,
                            Level = 1,
                            Name = "Dummy",
                            Race = "Human",
                            Strength = 18,
                            Wisdom = 10
                        });
                });

            modelBuilder.Entity("PBJProject.Domain.Models.Character", b =>
                {
                    b.HasOne("PBJProject.Domain.Models.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("AccountID");
                });
#pragma warning restore 612, 618
        }
    }
}
