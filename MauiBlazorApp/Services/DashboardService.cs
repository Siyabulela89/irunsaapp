using irunsaapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irunsaapp.Services
{
    public class DashboardService : IDashboardType
    {
        private string _baseUrl = "https://irunsa.co.za";

        public async Task<List<DashboardResponseModel>> GetAllDashboardlist()
        {
            var returnResponse = new List<DashboardResponseModel>();
            using (var client = new HttpClient())
            {
                string url = $"{_baseUrl}/api/Dashboard/GetAll";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await apiResponse.Content.ReadAsStringAsync();

                    // Check if the response starts with '[' (indicating an array)
                    if (response.StartsWith("["))
                    {
                        returnResponse = JsonConvert.DeserializeObject<List<DashboardResponseModel>>(response);
                    }
                    else if (response.StartsWith("{"))
                    {
                        // Deserialize into MainResponseModel if it's an object
                        var deserializeResponse = JsonConvert.DeserializeObject<MainResponseModel>(response);

                        if (deserializeResponse.Isuccess)
                        {
                            returnResponse = JsonConvert.DeserializeObject<List<DashboardResponseModel>>(deserializeResponse.Content.ToString());
                        }
                    }
                }
            }
            return returnResponse;
        }
    }
}
