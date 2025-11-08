APIVerve.API.CitiesLookup API
============

Cities Lookup is a simple tool for looking up city data. It returns the city name, population, and more.

![Build Status](https://img.shields.io/badge/build-passing-green)
![Code Climate](https://img.shields.io/badge/maintainability-B-purple)
![Prod Ready](https://img.shields.io/badge/production-ready-blue)

This is a .NET Wrapper for the [APIVerve.API.CitiesLookup API](https://apiverve.com/marketplace/citieslookup)

---

## Installation

Using the .NET CLI:
```
dotnet add package APIVerve.API.CitiesLookup
```

Using the Package Manager:
```
nuget install APIVerve.API.CitiesLookup
```

Using the Package Manager Console:
```
Install-Package APIVerve.API.CitiesLookup
```

From within Visual Studio:

1. Open the Solution Explorer
2. Right-click on a project within your solution
3. Click on Manage NuGet Packages
4. Click on the Browse tab and search for "APIVerve.API.CitiesLookup"
5. Click on the APIVerve.API.CitiesLookup package, select the appropriate version in the right-tab and click Install

---

## Configuration

Before using the citieslookup API client, you have to setup your account and obtain your API Key.
You can get it by signing up at [https://apiverve.com](https://apiverve.com)

---

## Quick Start

Here's a simple example to get you started quickly:

```csharp
using System;
using APIVerve;

class Program
{
    static async Task Main(string[] args)
    {
        // Initialize the API client
        var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");

        var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

        // Make the API call
        try
        {
            var response = await apiClient.ExecuteAsync(queryOptions);

            if (response.Error != null)
            {
                Console.WriteLine($"API Error: {response.Error}");
            }
            else
            {
                Console.WriteLine("Success!");
                // Access response data using the strongly-typed ResponseObj properties
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
```

---

## Usage

The APIVerve.API.CitiesLookup API documentation is found here: [https://docs.apiverve.com/ref/citieslookup](https://docs.apiverve.com/ref/citieslookup).
You can find parameters, example responses, and status codes documented here.

### Setup

###### Authentication
APIVerve.API.CitiesLookup API uses API Key-based authentication. When you create an instance of the API client, you can pass your API Key as a parameter.

```csharp
// Create an instance of the API client
var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");
```

---

## Usage Examples

### Basic Usage (Async/Await Pattern - Recommended)

The modern async/await pattern provides the best performance and code readability:

```csharp
using System;
using System.Threading.Tasks;
using APIVerve;

public class Example
{
    public static async Task Main(string[] args)
    {
        var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");

        var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

        var response = await apiClient.ExecuteAsync(queryOptions);

        if (response.Error != null)
        {
            Console.WriteLine($"Error: {response.Error}");
        }
        else
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
```

### Synchronous Usage

If you need to use synchronous code, you can use the `Execute` method:

```csharp
using System;
using APIVerve;

public class Example
{
    public static void Main(string[] args)
    {
        var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");

        var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

        var response = apiClient.Execute(queryOptions);

        if (response.Error != null)
        {
            Console.WriteLine($"Error: {response.Error}");
        }
        else
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
```

---

## Error Handling

The API client provides comprehensive error handling. Here are some examples:

### Handling API Errors

```csharp
using System;
using System.Threading.Tasks;
using APIVerve;

public class Example
{
    public static async Task Main(string[] args)
    {
        var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");

        var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

        try
        {
            var response = await apiClient.ExecuteAsync(queryOptions);

            // Check for API-level errors
            if (response.Error != null)
            {
                Console.WriteLine($"API Error: {response.Error}");
                Console.WriteLine($"Status: {response.Status}");
                return;
            }

            // Success - use the data
            Console.WriteLine("Request successful!");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented));
        }
        catch (ArgumentException ex)
        {
            // Invalid API key or parameters
            Console.WriteLine($"Invalid argument: {ex.Message}");
        }
        catch (System.Net.Http.HttpRequestException ex)
        {
            // Network or HTTP errors
            Console.WriteLine($"Network error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Other errors
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
```

### Comprehensive Error Handling with Retry Logic

```csharp
using System;
using System.Threading.Tasks;
using APIVerve;

public class Example
{
    public static async Task Main(string[] args)
    {
        var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");

        // Configure retry behavior (max 3 retries)
        apiClient.SetMaxRetries(3);        // Retry up to 3 times (default: 0, max: 3)
        apiClient.SetRetryDelay(2000);     // Wait 2 seconds between retries

        var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

        try
        {
            var response = await apiClient.ExecuteAsync(queryOptions);

            if (response.Error != null)
            {
                Console.WriteLine($"API Error: {response.Error}");
            }
            else
            {
                Console.WriteLine("Success!");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed after retries: {ex.Message}");
        }
    }
}
```

---

## Advanced Features

### Custom Headers

Add custom headers to your requests:

```csharp
var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");

// Add custom headers
apiClient.AddCustomHeader("X-Custom-Header", "custom-value");
apiClient.AddCustomHeader("X-Request-ID", Guid.NewGuid().ToString());

var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

var response = await apiClient.ExecuteAsync(queryOptions);

// Remove a header
apiClient.RemoveCustomHeader("X-Custom-Header");

// Clear all custom headers
apiClient.ClearCustomHeaders();
```

### Request Logging

Enable logging for debugging:

```csharp
var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]", isDebug: true);

// Or use a custom logger
apiClient.SetLogger(message =>
{
    Console.WriteLine($"[LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
});

var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

var response = await apiClient.ExecuteAsync(queryOptions);
```

### Retry Configuration

Customize retry behavior for failed requests:

```csharp
var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]");

// Set retry options
apiClient.SetMaxRetries(3);           // Retry up to 3 times (default: 0, max: 3)
apiClient.SetRetryDelay(1500);        // Wait 1.5 seconds between retries (default: 1000ms)

var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};

var response = await apiClient.ExecuteAsync(queryOptions);
```

### Dispose Pattern

The API client implements `IDisposable` for proper resource cleanup:

```csharp
using (var apiClient = new CitiesLookupAPIClient("[YOUR_API_KEY]"))
{
    var queryOptions = new CitiesLookupQueryOptions {
  city = "San Francisco"
};
    var response = await apiClient.ExecuteAsync(queryOptions);
    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented));
}
// HttpClient is automatically disposed here
```

---

## Example Response

```json
{
  "status": "ok",
  "error": null,
  "data": {
    "search": "San Francisco",
    "foundCities": [
      {
        "name": "San Francisco",
        "altName": "",
        "country": "US",
        "featureCode": "PPLA2",
        "population": 864816,
        "loc": {
          "type": "Point",
          "coordinates": [
            -122.41942,
            37.77493
          ]
        }
      },
      {
        "name": "San Francisco de Macorís",
        "altName": "",
        "country": "DO",
        "featureCode": "PPLA",
        "population": 124763,
        "loc": {
          "type": "Point",
          "coordinates": [
            -70.25259,
            19.30099
          ]
        }
      },
      {
        "name": "San Francisco del Rincón",
        "altName": "",
        "country": "MX",
        "featureCode": "PPLA2",
        "population": 71139,
        "loc": {
          "type": "Point",
          "coordinates": [
            -101.85515,
            21.01843
          ]
        }
      },
      {
        "name": "South San Francisco",
        "altName": "",
        "country": "US",
        "featureCode": "PPL",
        "population": 67271,
        "loc": {
          "type": "Point",
          "coordinates": [
            -122.40775,
            37.65466
          ]
        }
      },
      {
        "name": "San Francisco",
        "altName": "",
        "country": "AR",
        "featureCode": "PPLA2",
        "population": 59062,
        "loc": {
          "type": "Point",
          "coordinates": [
            -62.08266,
            -31.42797
          ]
        }
      },
      {
        "name": "San Francisco",
        "altName": "",
        "country": "CR",
        "featureCode": "PPL",
        "population": 55923,
        "loc": {
          "type": "Point",
          "coordinates": [
            -84.12934,
            9.99299
          ]
        }
      },
      {
        "name": "San Francisco El Alto",
        "altName": "",
        "country": "GT",
        "featureCode": "PPLA2",
        "population": 54493,
        "loc": {
          "type": "Point",
          "coordinates": [
            -91.4431,
            14.9449
          ]
        }
      },
      {
        "name": "San Francisco Acuautla",
        "altName": "",
        "country": "MX",
        "featureCode": "PPL",
        "population": 27960,
        "loc": {
          "type": "Point",
          "coordinates": [
            -98.86034,
            19.34564
          ]
        }
      },
      {
        "name": "San Francisco Cuaxusco",
        "altName": "",
        "country": "MX",
        "featureCode": "PPLX",
        "population": 24900,
        "loc": {
          "type": "Point",
          "coordinates": [
            -99.61925,
            19.26755
          ]
        }
      },
      {
        "name": "San Francisco Tlalcilalcalpan",
        "altName": "",
        "country": "MX",
        "featureCode": "PPL",
        "population": 16509,
        "loc": {
          "type": "Point",
          "coordinates": [
            -99.76771,
            19.29474
          ]
        }
      },
      {
        "name": "San Francisco",
        "altName": "",
        "country": "SV",
        "featureCode": "PPLA",
        "population": 16152,
        "loc": {
          "type": "Point",
          "coordinates": [
            -88.1,
            13.7
          ]
        }
      },
      {
        "name": "San Francisco de los Romo",
        "altName": "",
        "country": "MX",
        "featureCode": "PPLA2",
        "population": 16124,
        "loc": {
          "type": "Point",
          "coordinates": [
            -102.2714,
            22.07748
          ]
        }
      },
      {
        "name": "San Francisco Zapotitlán",
        "altName": "",
        "country": "GT",
        "featureCode": "PPLA2",
        "population": 13855,
        "loc": {
          "type": "Point",
          "coordinates": [
            -91.52144,
            14.58939
          ]
        }
      },
      {
        "name": "San Francisco Ocotlán",
        "altName": "",
        "country": "MX",
        "featureCode": "PPL",
        "population": 11636,
        "loc": {
          "type": "Point",
          "coordinates": [
            -98.28345,
            19.13411
          ]
        }
      },
      {
        "name": "San Francisco Tecoxpa",
        "altName": "",
        "country": "MX",
        "featureCode": "PPL",
        "population": 11456,
        "loc": {
          "type": "Point",
          "coordinates": [
            -99.00639,
            19.19167
          ]
        }
      },
      {
        "name": "San Francisco Telixtlahuaca",
        "altName": "",
        "country": "MX",
        "featureCode": "PPLA2",
        "population": 10618,
        "loc": {
          "type": "Point",
          "coordinates": [
            -96.90529,
            17.29684
          ]
        }
      },
      {
        "name": "San Francisco Tetlanohcan",
        "altName": "",
        "country": "MX",
        "featureCode": "PPLA2",
        "population": 9858,
        "loc": {
          "type": "Point",
          "coordinates": [
            -98.1637,
            19.2602
          ]
        }
      },
      {
        "name": "San Francisco Chimalpa",
        "altName": "",
        "country": "MX",
        "featureCode": "PPL",
        "population": 8953,
        "loc": {
          "type": "Point",
          "coordinates": [
            -99.34398,
            19.44279
          ]
        }
      },
      {
        "name": "Altos de San Francisco",
        "altName": "",
        "country": "PA",
        "featureCode": "PPL",
        "population": 8189,
        "loc": {
          "type": "Point",
          "coordinates": [
            -79.79,
            8.86167
          ]
        }
      },
      {
        "name": "San Francisco Zacacalco",
        "altName": "",
        "country": "MX",
        "featureCode": "PPL",
        "population": 7420,
        "loc": {
          "type": "Point",
          "coordinates": [
            -98.98279,
            19.92875
          ]
        }
      }
    ]
  }
}
```

---

## Customer Support

Need any assistance? [Get in touch with Customer Support](https://apiverve.com/contact).

---

## Updates
Stay up to date by following [@apiverveHQ](https://twitter.com/apiverveHQ) on Twitter.

---

## Legal

All usage of the APIVerve website, API, and services is subject to the [APIVerve Terms of Service](https://apiverve.com/terms) and all legal documents and agreements.

---

## License
Licensed under the The MIT License (MIT)

Copyright (&copy;) 2025 APIVerve, and EvlarSoft LLC

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
