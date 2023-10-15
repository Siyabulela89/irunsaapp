using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using irunsaapp.Models;

namespace irunsaapp.Services
{
    public class EntityTypeService : IEntityType
    {
        private readonly HttpClient _httpClient;

        public EntityTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AthleteEntity> AddAthleteEntity(AthleteEntity athleteEntity)
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

        public async Task<List<Country>> GetAllCountries()
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
        
        public async Task<List<EntityType>> GetAllEntityTypelist()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("api/EntityType/GetAll");
                return JsonSerializer.Deserialize<List<EntityType>>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to get EntityType list.", ex);
            }
        }

        public async Task<List<Province>> GetAllProvinces()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("api/Province/GetAll");

                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Province>>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to get provinces list.", ex);
            }
        }

        public async Task<List<string>> GetAssociatedProvinces(int entityTypeId, int clubEntityId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"api/ProvinceEntityRelationship/GetById/{entityTypeId}/{clubEntityId}");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to get associated provinces list.", ex);
            }
        }

        public async Task<List<ContactType>> GetAllContactTypes()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("api/ContactType/GetAll");

                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ContactType>>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to get contact type list.", ex);
            }
        }

        public List<ContactDetail> GetSavedContacts(int entityTypeId, int clubEntityId)
        {
            try
            {
                var responseTask = _httpClient.GetStringAsync($"api/ContactDetail/GetById/{entityTypeId}/{clubEntityId}");
                responseTask.Wait();  // This is blocking, use cautiously

                var response = responseTask.Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ContactDetail>>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to get contact type list.", ex);
            }
        }

        public async Task<string> AddClubEntity(ClubEntityWithList clubEntity)
        {
            try
            {
                var clubAsJson = JsonSerializer.Serialize(clubEntity);
                var content = new StringContent(clubAsJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/ClubEntity/AddClubEntity", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Failed to add club entity. StatusCode: {response.StatusCode}. Content: {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to add club entity.", ex);
            }
        }

        public async Task<string> UpdateClubEntity(ClubEntityWithList clubEntity)
        {
            try
            {
                var clubAsJson = JsonSerializer.Serialize(clubEntity);
                var content = new StringContent(clubAsJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("api/ClubEntity/UpdateClubEntity", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Failed to update club entity. StatusCode: {response.StatusCode}. Content: {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to update club entity.", ex);
            }
        }

    }
}
