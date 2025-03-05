using ApiIntegration.Services;
using ApiIntegration.Utils;

namespace ApiIntegration
{
    // F1 2025 Bahrain Preseason Tests - API Integration
    // This is not production ready code, it's a simple console application to demonstrate how to integrate with an API.
    // In real live scenario we could use HttpClientFactory or libraries like Refit/RestSharp for defining httpClient and endpoints, Polly for resilience, Serilog for logging, etc.
    // Code should be organised properly in separate classes/services, files, folders, assemblies. Services should be used via DI container. This is just a quick demo application
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Pick testing day (1, 2, 3):");
                string? input = Console.ReadLine();
                string sessionName = input switch
                {
                    "1" => "Day 1",
                    "2" => "Day 2",
                    "3" => "Day 3",
                    _ => null
                };

                Guard.AgainstNullOrEmpty(sessionName, "Incorrect testing day.");

                using (HttpClient client = new HttpClient())
                {
                    var dataFetchingService = new DataFetchingService();
                    var sessionKey = await dataFetchingService.GetSessionKeyAsync(client, sessionName);
                    Guard.AgainstInvalidSessionKey(sessionKey);

                    Console.WriteLine("Insert driver's number:");
                    string? driverInput = Console.ReadLine();
                    var driverNumber = Guard.AgainstIncorrectDriverNumber(driverInput);
                    Console.WriteLine();

                    var laps = await dataFetchingService.GetDriverLapsAsync(client, sessionKey, driverNumber);
                    Guard.AgainstNullOrEmptyLaps(laps);

                    var dataProcessingService = new DataProcessingService();
                    var pushLaps = dataProcessingService.GetPushLaps(laps);
                    Guard.AgainstNullOrEmptyLaps(pushLaps);

                    var printingService = new PrintingService();
                    var avarageLapTime = dataProcessingService.GetAvarageLapTime(pushLaps);
                    printingService.PrintAvarageLapTime(avarageLapTime, pushLaps.Count);

                    printingService.PrintLapTimes(pushLaps);

                    var groupedLaps = dataProcessingService.GetGroupLapsByDuration(pushLaps);
                    printingService.PrintGroupedLaps(groupedLaps);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
