using ApiIntegration.DTOs;
using System.Text.Json;

namespace ApiIntegration.Services
{
    public class DataFetchingService
    {
        public async Task<IReadOnlyList<Lap>?> GetDriverLapsAsync(HttpClient client, int sessionKey, int driverNumber)
        {
            string lapsUrl = $"https://api.openf1.org/v1/laps?session_key={sessionKey}&driver_number={driverNumber}";
            HttpResponseMessage lapsResponse = await client.GetAsync(lapsUrl);
            lapsResponse.EnsureSuccessStatusCode();

            string lapsJson = await lapsResponse.Content.ReadAsStringAsync();
            IReadOnlyList<Lap>? laps = JsonSerializer.Deserialize<List<Lap>>(lapsJson);
            return laps;
        }

        public async Task<int> GetSessionKeyAsync(HttpClient client, string sessionName)
        {
            string url = $"https://api.openf1.org/v1/sessions?session_name={Uri.EscapeDataString(sessionName)}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            JsonDocument doc = JsonDocument.Parse(json);

            if (doc.RootElement.GetArrayLength() <= 0)
            {
                Console.WriteLine("No data for selected testing day.");
                return 0;
            }

            return doc.RootElement[0].GetProperty("session_key").GetInt32();
        }
    }
}
