using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StrokePredictionWinForms
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        public string Token { get; private set; } = string.Empty;
        public string CurrentUser { get; private set; } = string.Empty;

        public ApiClient(string baseUrl = "http://localhost:5263/")
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        // ── Auth ─────────────────────────────────────────────
        public async Task<bool> LoginAsync(string username, string password)
        {
            var req = new { Username = username, Password = password };
            var content = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/v1/auth/login", content);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<JsonElement>(responseString);
                Token = result.GetProperty("token").GetString() ?? "";
                CurrentUser = result.GetProperty("fullName").GetString() ?? username;

                // Đính kèm JWT vào mọi request sau này
                if (!string.IsNullOrEmpty(Token))
                    _client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                return true;
            }
            return false;
        }

        // ── Prediction ──────────────────────────────────────
        public async Task<string> PredictAsync(object data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/v1/predictions", content);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error (HTTP {(int)response.StatusCode}): {errorBody}");
            }
            
            return await response.Content.ReadAsStringAsync();
        }

        // ── Dashboard ───────────────────────────────────────
        public async Task<string> GetDashboardStatsAsync()
        {
            var response = await _client.GetAsync("api/v1/stats/dashboard");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // ── History ─────────────────────────────────────────
        public async Task<string> GetHistoryAsync(int page = 1, int pageSize = 50)
        {
            var response = await _client.GetAsync($"api/v1/predictions?page={page}&pageSize={pageSize}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // ── Generic GET ─────────────────────────────────────
        public async Task<string> GetAsync(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
