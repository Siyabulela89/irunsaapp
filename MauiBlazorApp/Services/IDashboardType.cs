using irunsaapp.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irunsaapp.Services
{
    public interface IDashboardType
    {
        Task<List<EntityType>> GetAllDashboardlist();
        Task<List<Country>> GetallCountries();
        Task<AthleteEntity> AddathleteEntity(AthleteEntity AthleteEntity);
    }
}
