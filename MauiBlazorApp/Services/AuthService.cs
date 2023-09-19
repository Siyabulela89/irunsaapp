using Blazored.LocalStorage;
using irunsaapp.Helper;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using irunsaapp.Models;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace irunsaapp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
   
        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }
        public class ErrorResponse
        {
            public string title { get; set; }
            public Dictionary<string, List<string>> errors { get; set; }
        }
        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/accounts", registerModel);

            if (!result.IsSuccessStatusCode)
            {
                var errorResponseContent = await result.Content.ReadAsStringAsync();

                try
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorResponseContent);

                    if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.title))
                    {
                        // Check if it's a known error response structure
                        if (errorResponse.title == "One or more validation errors occurred.")
                        {
                            // Handle validation errors
                            var errors = errorResponse.errors.SelectMany(kv => kv.Value).ToList();
                            return new RegisterResult { Successful = false, Errors = errors };
                        }
                        else
                        {
                            // Handle other error responses with a title
                            return new RegisterResult { Successful = false, Errors = new List<string> { errorResponse.title } };
                        }
                    }
                }
                catch (JsonException)
                {
                    // Handle JSON parsing errors if the response is not in the expected format
                    var responseContent = await result.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseContent);

                    // Extract the "errors" array and join its contents into a single string
                    var errorsArray = jsonObject["errors"] as JArray;
                    var errors = errorsArray?.Select(error => error.ToString()).ToList() ?? new List<string>();
                    return new RegisterResult { Successful = false, Errors = errors };
                }

                // Handle other error cases if the response couldn't be parsed
                return new RegisterResult { Successful = false, Errors = new List<string> { "Error occurred" } };
            }

            return new RegisterResult { Successful = true, Errors = null };
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            try
            {
                var loginAsJson = JsonSerializer.Serialize(loginModel);
                var response = await _httpClient.PostAsync("api/Login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

                var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (!response.IsSuccessStatusCode)
                {
                    return loginResult!;
                }

               

                // Call the private method to parse claims from the JWT token
                var claims = ParseClaimsFromJwt(loginResult.Token);

                // Retrieve UserId from claims
                var userIdClaim = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Actor);
                if (userIdClaim != null)
                {
                    string userId = userIdClaim.Value;
                    loginResult.HasRoles = await CheckUserRoles(userId);
                
                }
                await _localStorage.SetItemAsync("authToken", loginResult!.Token);
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email!, claims);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

                return loginResult;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Login failed.", ex);
            }
        }


        public async Task<bool> CheckUserRoles(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Accounts/CheckUserRoles/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var roles = JsonSerializer.Deserialize<List<string>>(responseContent);

                    // Check if the user has any roles
                    return roles != null && roles.Any();
                }

                return false;  // Or handle the error as needed
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                throw new ApplicationException("Failed to check user roles.", ex);
            }
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
