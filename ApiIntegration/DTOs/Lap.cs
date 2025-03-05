using System.Text.Json.Serialization;

namespace ApiIntegration.DTOs
{
    public record Lap
    {
        [JsonPropertyName("meeting_key")]
        public int MeetingKey { get; set; }

        [JsonPropertyName("session_key")]
        public int SessionKey { get; set; }

        [JsonPropertyName("driver_number")]
        public int DriverNumber { get; set; }

        [JsonPropertyName("i1_speed")]
        public int? I1Speed { get; set; }

        [JsonPropertyName("i2_speed")]
        public int? I2Speed { get; set; }

        [JsonPropertyName("st_speed")]
        public int? StSpeed { get; set; }

        [JsonPropertyName("date_start")]
        public string DateStart { get; set; }

        [JsonPropertyName("lap_duration")]
        public double? LapDuration { get; set; }

        [JsonPropertyName("is_pit_out_lap")]
        public bool IsPitOutLap { get; set; }

        [JsonPropertyName("duration_sector_1")]
        public double? DurationSector1 { get; set; }

        [JsonPropertyName("duration_sector_2")]
        public double? DurationSector2 { get; set; }

        [JsonPropertyName("duration_sector_3")]
        public double? DurationSector3 { get; set; }

        [JsonPropertyName("segments_sector_1")]
        public List<int?> SegmentsSector1 { get; set; }

        [JsonPropertyName("segments_sector_2")]
        public List<int?> SegmentsSector2 { get; set; }

        [JsonPropertyName("segments_sector_3")]
        public List<int?> SegmentsSector3 { get; set; }

        [JsonPropertyName("lap_number")]
        public int LapNumber { get; set; }
    }
}
