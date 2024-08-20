using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace APIVerve
{
public class loc
{
    [JsonProperty("type")]
    public string type { get; set; }

    [JsonProperty("coordinates")]
    public double[] coordinates { get; set; }

}

public class foundCities
{
    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("altName")]
    public string altName { get; set; }

    [JsonProperty("country")]
    public string country { get; set; }

    [JsonProperty("featureCode")]
    public string featureCode { get; set; }

    [JsonProperty("population")]
    public int population { get; set; }

    [JsonProperty("loc")]
    public loc loc { get; set; }

}

public class data
{
    [JsonProperty("search")]
    public string search { get; set; }

    [JsonProperty("foundCities")]
    public foundCities[] foundCities { get; set; }

}

public class ResponseObj
{
    [JsonProperty("status")]
    public string status { get; set; }

    [JsonProperty("error")]
    public object error { get; set; }

    [JsonProperty("data")]
    public data data { get; set; }

    [JsonProperty("code")]
    public int code { get; set; }

}

}
