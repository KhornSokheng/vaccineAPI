using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int countryID);
        Task<Country> GetCountryByName(string countryName);
        Task<IEnumerable<Country>> Search(string countryName);
        Task<Country> AddCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        Task DeleteCountry(int countryID);
    }
}
