﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccineAPI.Server.Models;

namespace VaccineAPI.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VaccineAPI.Shared.Continent", b =>
                {
                    b.Property<int>("ContinentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContinentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContinentID");

                    b.ToTable("Continents");

                    b.HasData(
                        new
                        {
                            ContinentID = 1,
                            ContinentName = "Asia"
                        },
                        new
                        {
                            ContinentID = 2,
                            ContinentName = "Europe"
                        },
                        new
                        {
                            ContinentID = 3,
                            ContinentName = "Africa"
                        },
                        new
                        {
                            ContinentID = 4,
                            ContinentName = "North America"
                        },
                        new
                        {
                            ContinentID = 5,
                            ContinentName = "South America"
                        },
                        new
                        {
                            ContinentID = 6,
                            ContinentName = "Australia"
                        },
                        new
                        {
                            ContinentID = 7,
                            ContinentName = "Antarctica"
                        });
                });

            modelBuilder.Entity("VaccineAPI.Shared.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContinentID")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("CountryID");

                    b.HasIndex("ContinentID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryID = 1,
                            ContinentID = 1,
                            CountryName = "Brunei",
                            Population = 500000
                        },
                        new
                        {
                            CountryID = 2,
                            ContinentID = 1,
                            CountryName = "Cambodia",
                            Population = 15000000
                        },
                        new
                        {
                            CountryID = 3,
                            ContinentID = 1,
                            CountryName = "Laos",
                            Population = 7000000
                        },
                        new
                        {
                            CountryID = 4,
                            ContinentID = 1,
                            CountryName = "Thailand",
                            Population = 65000000
                        },
                        new
                        {
                            CountryID = 5,
                            ContinentID = 2,
                            CountryName = "England",
                            Population = 55000000
                        },
                        new
                        {
                            CountryID = 6,
                            ContinentID = 4,
                            CountryName = "United State",
                            Population = 355000000
                        },
                        new
                        {
                            CountryID = 7,
                            ContinentID = 6,
                            CountryName = "Australia",
                            Population = 25000000
                        });
                });

            modelBuilder.Entity("VaccineAPI.Shared.Vaccination", b =>
                {
                    b.Property<int>("VaccinationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<int>("FirstDose")
                        .HasColumnType("int");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<int>("SecondDose")
                        .HasColumnType("int");

                    b.Property<int>("VaccineID")
                        .HasColumnType("int");

                    b.HasKey("VaccinationID");

                    b.HasIndex("CountryID");

                    b.HasIndex("VaccineID");

                    b.ToTable("Vaccinations");

                    b.HasData(
                        new
                        {
                            VaccinationID = 1,
                            CountryID = 1,
                            FirstDose = 200000,
                            Percentage = 0.29999999999999999,
                            SecondDose = 100000,
                            VaccineID = 1
                        },
                        new
                        {
                            VaccinationID = 2,
                            CountryID = 1,
                            FirstDose = 200000,
                            Percentage = 0.40000000000000002,
                            SecondDose = 200000,
                            VaccineID = 2
                        },
                        new
                        {
                            VaccinationID = 3,
                            CountryID = 1,
                            FirstDose = 50000,
                            Percentage = 0.10000000000000001,
                            SecondDose = 50000,
                            VaccineID = 3
                        },
                        new
                        {
                            VaccinationID = 4,
                            CountryID = 2,
                            FirstDose = 1000000,
                            Percentage = 0.059999999999999998,
                            SecondDose = 1000000,
                            VaccineID = 1
                        },
                        new
                        {
                            VaccinationID = 5,
                            CountryID = 2,
                            FirstDose = 9000000,
                            Percentage = 0.59999999999999998,
                            SecondDose = 9000000,
                            VaccineID = 3
                        },
                        new
                        {
                            VaccinationID = 6,
                            CountryID = 2,
                            FirstDose = 3500000,
                            Percentage = 0.23000000000000001,
                            SecondDose = 3500000,
                            VaccineID = 4
                        });
                });

            modelBuilder.Entity("VaccineAPI.Shared.Vaccine", b =>
                {
                    b.Property<int>("VaccineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OriginCountryCountryID")
                        .HasColumnType("int");

                    b.Property<string>("VaccineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccineID");

                    b.HasIndex("OriginCountryCountryID");

                    b.ToTable("Vaccines");

                    b.HasData(
                        new
                        {
                            VaccineID = 1,
                            Description = "Viral Vector",
                            VaccineName = "AstraZeneca"
                        },
                        new
                        {
                            VaccineID = 2,
                            Description = "mRNA",
                            VaccineName = "Pfizer"
                        },
                        new
                        {
                            VaccineID = 3,
                            Description = "Inactivated Virus",
                            VaccineName = "Sinovac"
                        },
                        new
                        {
                            VaccineID = 4,
                            Description = "Inactivated Virus",
                            VaccineName = "Sinopharm"
                        },
                        new
                        {
                            VaccineID = 5,
                            Description = "mRNA",
                            VaccineName = "Moderna"
                        });
                });

            modelBuilder.Entity("VaccineAPI.Shared.Country", b =>
                {
                    b.HasOne("VaccineAPI.Shared.Continent", "Continent")
                        .WithMany()
                        .HasForeignKey("ContinentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("VaccineAPI.Shared.Vaccination", b =>
                {
                    b.HasOne("VaccineAPI.Shared.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccineAPI.Shared.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("VaccineAPI.Shared.Vaccine", b =>
                {
                    b.HasOne("VaccineAPI.Shared.Country", "OriginCountry")
                        .WithMany()
                        .HasForeignKey("OriginCountryCountryID");

                    b.Navigation("OriginCountry");
                });
#pragma warning restore 612, 618
        }
    }
}
