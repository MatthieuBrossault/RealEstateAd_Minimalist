namespace RealEstateAd_Minimalist
{
    using Newtonsoft.Json;

    public partial class Forecast
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        [JsonProperty("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

        [JsonProperty("utc_offset_seconds")]
        public long UtcOffsetSeconds { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        [JsonProperty("hourly")]
        public Hourly Hourly { get; set; }

        [JsonProperty("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; }

        [JsonProperty("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }

    public partial class CurrentWeather
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("weathercode")]
        public long Weathercode { get; set; }

        [JsonProperty("windspeed")]
        public double Windspeed { get; set; }

        [JsonProperty("winddirection")]
        public long Winddirection { get; set; }
    }

    public partial class Hourly
    {
        [JsonProperty("time")]
        public string[] Time { get; set; }

        [JsonProperty("temperature_2m")]
        public double[] Temperature2M { get; set; }
    }

    public partial class HourlyUnits
    {
        [JsonProperty("temperature_2m")]
        public string Temperature2M { get; set; }
    }

    public partial class ErrorMsg
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
