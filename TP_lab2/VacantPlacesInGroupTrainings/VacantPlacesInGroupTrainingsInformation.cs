using Newtonsoft.Json;

namespace TP_lab2
{
    internal class VacantPlacesInGroupTrainingsInformation
    {
        public GroupTrainingsData VacantPlacesInGroupTrainings { get; set; }

        internal class GroupTrainingsData
        {
            [JsonProperty("аэробные")]
            public Dictionary<string, int[]> Aerobics { get; set; }

            [JsonProperty("низкоинтенсивные")]
            public Dictionary<string, int[]> LowIntensity { get; set; }

            [JsonProperty("силовые")]
            public Dictionary<string, int[]> Strength { get; set; }

            [JsonProperty("смешанные")]
            public Dictionary<string, int[]> Mixed { get; set; }

            [JsonProperty("танцевальные")]
            public Dictionary<string, int[]> Dance { get; set; }
        }
    }
}
