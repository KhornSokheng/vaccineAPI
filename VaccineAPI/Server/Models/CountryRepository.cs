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

        public Task<IEnumerable<Country>> Search(string countryName)
        {
            throw new NotImplementedException();
        }

        public Task<Country> AddCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<Country> UpdateCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCountry(int countryID)
        {
            throw new NotImplementedException();
        }
    }
}
