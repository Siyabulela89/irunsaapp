using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;

namespace irunsaapp.Data
{
    internal class DataAccess
    {
        private readonly HttpClient _httpClient;

        public DataAccess(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetForecastAsync()
        {
            var url = "https://irunsa.co.za/api/EntityType/GetAll";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode(); // This ensures that the response is successful (status code 200-299).

                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException)
            {
                // Handle exceptions here (e.g., network errors).
                // You can log the exception or return an error message to the UI.
                return "Error: Unable to fetch data from the server.";
            }
        }
    }
}