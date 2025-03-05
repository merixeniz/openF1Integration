using ApiIntegration.DTOs;

namespace ApiIntegration.Services
{
    public class PrintingService
    {
        public void PrintAvarageLapTime(double? avarageLapTime, int lapsCount)
        {
            Console.WriteLine($"Avarage Lap Time: {Math.Round((decimal)avarageLapTime.GetValueOrDefault(), 3)} s, Laps Count: {lapsCount}");
            Console.WriteLine();
        }
        public void PrintLapTimes(IReadOnlyList<Lap> laps)
        {
            foreach (var lap in laps)
            {
                Console.WriteLine($"Lap {lap.LapNumber} - Duration: {lap.LapDuration}, Sector Times: {lap.DurationSector1}/{lap.DurationSector2}/{lap.DurationSector3}");
            }
            Console.WriteLine();
        }
        public void PrintGroupedLaps(IDictionary<string, int> groupedLaps)
        {
            foreach (var group in groupedLaps)
            {
                Console.WriteLine($"Lap duration range {group.Key}: laps count: {group.Value}");
            }
            Console.WriteLine();
        }
    }
}
