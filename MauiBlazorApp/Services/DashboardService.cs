using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using irunsaapp.Models;

namespace irunsaapp.Services
{
    public class DashboardService : IDashboardType
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AthleteEntity> AddathleteEntity(AthleteEntity athleteEntity)
        {
            try
            {
                var athleteAsJson = JsonSerializer.Serialize(athleteEntity);
                var content = new StringContent(athleteAsJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/AthleteEntity/AddAthleteEntity", content);

                if (!response.IsSuccessStatusCode)
                {
                    return null; // Or handle the error as needed
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<AthleteEntity>(responseContent);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to add athlete entity.", ex);
            }
        }

        public async Task<List<Country>> GetallCountries()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("api/Country/GetAll");
                return JsonSerializer.Deserialize<List<Country>>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to get countries list.", ex);
}}
        
        public async Task<List<EntityType>> GetAllDashboardlist()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("api/EntityType/GetAll");
                return JsonSerializer.Deserialize<List<EntityType>>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to get dashboard list.", ex);
            }
        }
    }
}
