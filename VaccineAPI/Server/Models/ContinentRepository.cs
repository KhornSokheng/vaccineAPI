using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;
using Microsoft.EntityFrameworkCore;


namespace VaccineAPI.Server.Models
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly AppDbContext appDbContext;
        public ContinentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Continent> GetContinent(int continentID)
        {
            return await appDbContext.Continents
            .FirstOrDefaultAsync(d => d.ContinentID == continentID);
        }
        public async Task<IEnumerable<Continent>> GetContinents()
        {
            return await appDbContext.Continents.ToListAsync();
        }

        public Task<Continent> UpdateContinent(Continent continent)
        {
            throw new NotImplementedException();
        }
    }
}
