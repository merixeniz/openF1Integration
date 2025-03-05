using ApiIntegration.DTOs;

namespace ApiIntegration.Services
{
    public class DataProcessingService
    {
        private const int pushLapDurationTreshold = 97;
        public double? GetAvarageLapTime(IReadOnlyList<Lap> pushLaps)
            => pushLaps.Sum(l => l.LapDuration) / pushLaps.Count;


        public IReadOnlyList<Lap> GetPushLaps(IReadOnlyList<Lap> laps)
            => laps
                .Where(l => l.LapDuration is not null && l.LapDuration < pushLapDurationTreshold)
                .ToList();

        public IDictionary<string, int> GroupLapsByDuration(IReadOnlyList<Lap> pushLaps)
            => pushLaps
                .Where(l => l.LapDuration is not null)
                .GroupBy(l => (int)l.LapDuration)
                .OrderBy(g => g.Key)
                .ToDictionary(g => $"{g.Key}-{g.Key + 1}s", g => g.Count());
    }
}
