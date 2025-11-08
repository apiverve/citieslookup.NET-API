using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace APIVerve
{
    /// <summary>
    /// Loc data
    /// </summary>
    public class Loc
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

    }
    /// <summary>
    /// FoundCities data
    /// </summary>
    public class FoundCities
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("altName")]
        public string AltName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("featureCode")]
        public string FeatureCode { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("loc")]
        public Loc Loc { get; set; }

    }
    /// <summary>
    /// Data data
    /// </summary>
    public class Data
    {
        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("foundCities")]
        public FoundCities[] FoundCities { get; set; }

    }
    /// <summary>
    /// API Response object
    /// </summary>
    public class ResponseObj
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

    }
}
