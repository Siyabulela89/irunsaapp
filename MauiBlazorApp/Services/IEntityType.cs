using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irunsaapp.Models;

namespace irunsaapp.Services
{
    public interface IEntityType
    {
        Task<AthleteEntity> AddAthleteEntity(AthleteEntity AthleteEntity);
        Task<List<Country>> GetAllCountries();
        Task<List<EntityType>> GetAllEntityTypelist();
        Task<List<Club>> SearchClubs(string debouncedText);
        Task<List<Province>> GetAllProvinces();
        Task<string> AddClubEntity(ClubEntity clubEntity);
    }
}
