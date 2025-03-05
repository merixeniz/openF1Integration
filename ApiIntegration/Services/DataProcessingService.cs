using ApiIntegration.DTOs;

namespace ApiIntegration.Services
{
    public class DataProcessingService
    {
        #region Data Logging and Processing

        private const int pushLapDurationTreshold = 97;
        public void LogLapTimes(IReadOnlyList<Lap> pushLaps)
        {
            foreach (var lap in pushLaps)
            {
                Console.WriteLine($"Lap {lap.LapNumber} - Duration: {lap.LapDuration}, Sector Times: {lap.DurationSector1}/{lap.DurationSector2}/{lap.DurationSector3}");
            }
        }
        public void LogAvarageLapTime(IReadOnlyList<Lap> pushLaps)
        {
            var avarageLapTime = pushLaps.Sum(l => l.LapDuration) / pushLaps.Count;
            Console.WriteLine($"Avarage Lap Time: {Math.Round((decimal)avarageLapTime.GetValueOrDefault(), 3)} s, Push Laps Count: {pushLaps?.Count}");
        }

        public IReadOnlyList<Lap> GetPushLaps(IReadOnlyList<Lap> laps)
        {
            return laps
                .Where(l => l.LapDuration is not null && l.LapDuration < pushLapDurationTreshold)
                .ToList();
        }

        public IDictionary<string, int> LogGroupLapsByDuration(IReadOnlyList<Lap> pushLaps)
        {
            var result = pushLaps
                .Where(l => l.LapDuration is not null)
                .GroupBy(l => (int)l.LapDuration)
                .OrderBy(g => g.Key)
                .ToDictionary(g => $"{g.Key}-{g.Key + 1}s", g => g.Count());

            foreach (var group in result)
            {
                Console.WriteLine($"Lap duration range {group.Key}: laps count: {group.Value}");
            }

            return result;
        }

        #endregion
    }
}
