using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // seed Continents Table
            modelBuilder.Entity<Continent>().HasData(new Continent { ContinentID = 1, ContinentName = "Asia" });
            modelBuilder.Entity<Continent>().HasData(new Continent { ContinentID = 2, ContinentName = "Europe" });
            modelBuilder.Entity<Continent>().HasData(new Continent { ContinentID = 3, ContinentName = "Africa" });
            modelBuilder.Entity<Continent>().HasData(new Continent { ContinentID = 4, ContinentName = "North America" });
            modelBuilder.Entity<Continent>().HasData(new Continent { ContinentID = 5, ContinentName = "South America" });
            modelBuilder.Entity<Continent>().HasData(new Continent { ContinentID = 6, ContinentName = "Australia" });
            modelBuilder.Entity<Continent>().HasData(new Continent { ContinentID = 7, ContinentName = "Antarctica" });

            //seed Countries table 
            modelBuilder.Entity<Country>().HasData(new Country { CountryID = 1, CountryName = "Brunei", Population = 500000, ContinentID = 1 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryID = 2, CountryName = "Cambodia", Population = 15000000, ContinentID = 1 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryID = 3, CountryName = "Laos", Population = 7000000, ContinentID = 1 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryID = 4, CountryName = "Thailand", Population = 65000000, ContinentID = 1 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryID = 5, CountryName = "England", Population = 55000000, ContinentID = 2 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryID = 6, CountryName = "United State", Population = 355000000, ContinentID = 4 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryID = 7, CountryName = "Australia", Population = 25000000, ContinentID = 6 });

            //seed Vaccines
            //modelBuilder.Entity<Vaccine>().HasData(new Vaccine { VaccineID = 1, VaccineName = "AstraZeneca", OriginCountry = new Country { CountryName="England"}, Description="Viral Vector" });
            modelBuilder.Entity<Vaccine>().HasData(new Vaccine { VaccineID = 1, VaccineName = "AstraZeneca",  Description = "Viral Vector" });
            modelBuilder.Entity<Vaccine>().HasData(new Vaccine { VaccineID = 2, VaccineName = "Pfizer",  Description = "mRNA" });
            modelBuilder.Entity<Vaccine>().HasData(new Vaccine { VaccineID = 3, VaccineName = "Sinovac",  Description = "Inactivated Virus" });
            modelBuilder.Entity<Vaccine>().HasData(new Vaccine { VaccineID = 4, VaccineName = "Sinopharm", Description = "Inactivated Virus" });
            modelBuilder.Entity<Vaccine>().HasData(new Vaccine { VaccineID = 5, VaccineName = "Moderna", Description = "mRNA" });

            //seed Vaccinations table
            modelBuilder.Entity<Vaccination>().HasData(new Vaccination { VaccinationID = 1, CountryID = 1, VaccineID = 1, FirstDose=200000,SecondDose=100000,Percentage= 0.3});
            modelBuilder.Entity<Vaccination>().HasData(new Vaccination { VaccinationID = 2, CountryID = 1, VaccineID = 2, FirstDose = 200000, SecondDose = 200000, Percentage = 0.4 });
            modelBuilder.Entity<Vaccination>().HasData(new Vaccination { VaccinationID = 3, CountryID = 1, VaccineID = 3, FirstDose = 50000, SecondDose = 50000, Percentage = 0.1 });
            modelBuilder.Entity<Vaccination>().HasData(new Vaccination { VaccinationID = 4, CountryID = 2, VaccineID = 1, FirstDose = 1000000, SecondDose = 1000000, Percentage = 0.06 });
            modelBuilder.Entity<Vaccination>().HasData(new Vaccination { VaccinationID = 5, CountryID = 2, VaccineID = 3, FirstDose = 9000000, SecondDose = 9000000, Percentage = 0.6 });
            modelBuilder.Entity<Vaccination>().HasData(new Vaccination { VaccinationID = 6, CountryID = 2, VaccineID = 4, FirstDose = 3500000, SecondDose = 3500000, Percentage = 0.23 });

        }

    }
}
