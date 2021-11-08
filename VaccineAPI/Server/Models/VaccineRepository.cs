using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Models
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly AppDbContext appDbContext;
        public VaccineRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Vaccine> AddVaccine(Vaccine vaccine)
        {
            var result = await appDbContext.Vaccines.AddAsync(vaccine);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteVaccine(int vaccineID)
        {
            var result = await appDbContext.Vaccines
                .FirstOrDefaultAsync(e => e.VaccineID == vaccineID);
            if (result != null)
            {
                appDbContext.Vaccines.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Vaccine> GetVaccine(int vaccineID)
        {
            return await appDbContext.Vaccines
            .FirstOrDefaultAsync(d => d.VaccineID == vaccineID);
        }

        public async Task<Vaccine> GetVaccineByName(string vaccineName)
        {
            return await appDbContext.Vaccines
            .FirstOrDefaultAsync(d => d.VaccineName == vaccineName);
        }

        public async Task<IEnumerable<Vaccine>> GetVaccines()
        {
            return await appDbContext.Vaccines.ToListAsync();
        }

        public async Task<IEnumerable<Vaccine>> Search(string vaccineName)
        {
            IQueryable<Vaccine> query = appDbContext.Vaccines;
            if (!string.IsNullOrEmpty(vaccineName))
            {
                query = query.Where(e => e.VaccineName.Contains(vaccineName));
            }
            return await query.ToListAsync();
        }

        public async Task<Vaccine> UpdateVaccine(Vaccine vaccine)
        {
            var result = await appDbContext.Vaccines
                .FirstOrDefaultAsync(e => e.VaccineID == vaccine.VaccineID);
            if (result != null)
            {
                result.VaccineName = vaccine.VaccineName;
                result.Description = vaccine.Description;
                

                if (vaccine.OriginCountry != null)
                {
                    result.OriginCountry = vaccine.OriginCountry;
                }else if (vaccine.Country != null)
                {
                    
                    result.OriginCountry = vaccine.Country.CountryName;
                }

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

            
        }
    }
}
