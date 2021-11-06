using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public interface IContinentRepository
    {
        Task<IEnumerable<Continent>> GetContinents();
        Task<Continent> GetContinent(int continentID);
        //Task<Continent> UpdateContinent(Continent continent);
    }
}
