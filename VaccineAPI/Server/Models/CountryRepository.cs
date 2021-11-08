using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace VaccineAPI.Server.Models
{
    public class CountryRepository: ICountryRepository
    {
        private readonly AppDbContext appDbContext;
        public CountryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Country> GetCountry(int countryID)
        {
            return await appDbContext.Countries
            .FirstOrDefaultAsync(d => d.CountryID == countryID);
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await appDbContext.Countries.ToListAsync();
        }

        public async Task<IEnumerable<Country>> Search(string countryName)
        {
            IQueryable<Country> query = appDbContext.Countries;
            if (!string.IsNullOrEmpty(countryName))
            {
                query = query.Where(d => d.CountryName.Contains(countryName));
            }
            return await query.ToListAsync();
        }

        public async Task<Country> AddCountry(Country country)
        {
            var result = await appDbContext.Countries.AddAsync(country);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            var result = await appDbContext.Countries
              .FirstOrDefaultAsync(d => d.CountryID == country.CountryID);
            if (result != null)
            {
                result.CountryName = country.CountryName;
                result.Population = country.Population;
                result.ContinentID = country.ContinentID;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task DeleteCountry(int countryID)
        {
            var result = await appDbContext.Countries
             .FirstOrDefaultAsync(d => d.CountryID == countryID);
            if (result != null)
            {
                appDbContext.Countries.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Country> GetCountryByName(string countryName)
        {
            return await appDbContext.Countries
            .FirstOrDefaultAsync(d => d.CountryName == countryName);
        }
    }
}
