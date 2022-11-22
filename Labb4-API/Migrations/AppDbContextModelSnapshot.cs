﻿// <auto-generated />
using System;
using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb4_API.Models.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestID"));

                    b.Property<string>("InterestDescript")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("InterestID");

                    b.HasIndex("PersonID");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestID = 1,
                            InterestDescript = "I Love Horses",
                            InterestTitle = "Horses",
                            PersonID = 1
                        },
                        new
                        {
                            InterestID = 2,
                            InterestDescript = "Computers are awesome",
                            InterestTitle = "Computers",
                            PersonID = 2
                        },
                        new
                        {
                            InterestID = 3,
                            InterestDescript = "I Mine all day...",
                            InterestTitle = "Minecraft",
                            PersonID = 3
                        });
                });

            modelBuilder.Entity("Labb4_API.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("people");

                    b.HasData(
                        new
                        {
                            PersonID = 1,
                            FirstName = "Jack",
                            LastName = "Niklasson",
                            Phone = "0722211144"
                        },
                        new
                        {
                            PersonID = 2,
                            FirstName = "Emma",
                            LastName = "Whiteside",
                            Phone = "0700021212"
                        },
                        new
                        {
                            PersonID = 3,
                            FirstName = "Timothy",
                            LastName = "Borgäng",
                            Phone = "0731312224"
                        });
                });

            modelBuilder.Entity("Labb4_API.Models.Website", b =>
                {
                    b.Property<int>("WebsiteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WebsiteID"));

                    b.Property<int?>("InterestID")
                        .HasColumnType("int");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("WebpageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WebsiteID");

                    b.HasIndex("InterestID");

                    b.HasIndex("PersonID")
                        .IsUnique()
                        .HasFilter("[PersonID] IS NOT NULL");

                    b.ToTable("Websites");

                    b.HasData(
                        new
                        {
                            WebsiteID = 1,
                            InterestID = 1,
                            PersonID = 1,
                            WebpageLink = "www.Horse.com"
                        },
                        new
                        {
                            WebsiteID = 3,
                            InterestID = 3,
                            PersonID = 2,
                            WebpageLink = "www.Minecraft.net/mine/all/day"
                        },
                        new
                        {
                            WebsiteID = 4,
                            InterestID = 1,
                            PersonID = 3,
                            WebpageLink = "www.MoreHorses.pl"
                        });
                });

            modelBuilder.Entity("Labb4_API.Models.Interest", b =>
                {
                    b.HasOne("Labb4_API.Models.Person", "Person")
                        .WithMany("Interests")
                        .HasForeignKey("PersonID");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Labb4_API.Models.Website", b =>
                {
                    b.HasOne("Labb4_API.Models.Interest", "Interests")
                        .WithMany("Websites")
                        .HasForeignKey("InterestID");

                    b.HasOne("Labb4_API.Models.Person", "Persons")
                        .WithOne("Website")
                        .HasForeignKey("Labb4_API.Models.Website", "PersonID");

                    b.Navigation("Interests");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Labb4_API.Models.Interest", b =>
                {
                    b.Navigation("Websites");
                });

            modelBuilder.Entity("Labb4_API.Models.Person", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Website")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}