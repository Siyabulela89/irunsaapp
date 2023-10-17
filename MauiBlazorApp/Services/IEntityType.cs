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
        Task<List<Province>> GetAllProvinces();
        Task<List<string>> GetAssociatedProvinces(int entityTypeId, int clubEntityId);
        Task<List<ContactType>> GetAllContactTypes();
        List<ContactDetail> GetSavedContacts(int entityTypeId, int clubEntityId);
        Task<string> AddClubEntity(ClubEntityWithList clubEntity);
        Task<string> UpdateClubEntity(ClubEntityWithList clubEntity);
        Task<string> AddUserEntityRelationship(UserEntityRelationship model);
    }
}
