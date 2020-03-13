using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherAPI
    {

        static HttpClient client = new HttpClient();

        //string response = client.GetStringAsync("https://api.weather.gov/points/41.2808,-81.5678");

        static async Task<Uri> CreateWeatherAsync(Weather weather)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                $"api.weather.gov/points/{weather.Latitude},{weather.Longitude}", weather);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }


        static async Task<Weather> UpdateWeatherAsync(Weather weather)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api.weather.gov/points/{weather.Latitude},{weather.Longitude}", weather);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            weather = await response.Content.ReadAsAsync<Weather>();
            return weather;
        }


        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://api.weather.gov/point/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new weather
                Weather weather = new Weather
                {
                    ParkCode = null,
                    FiveDayForecastValue = 1,
                    Low = 0,
                    High = 0,
                    Forecast = null
                };

                var url = await CreateWeatherAsync(weather);

                // Get the product
                weather = await GetWeatherAsync(url.PathAndQuery);

                // Update the product
                await UpdateWeatherAsync(weather);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static async Task<Weather> GetWeatherAsync(string path)
        {
            Weather weather = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                weather = await response.Content.ReadAsAsync<Weather>();
            }
            return weather;
        }

        //List<MediaTypeFormatter> formatters = new List<MediaTypeFormatter>()
        //{
        //    new JsonMediaTypeFormatter(),
        //    new XmlMediaTypeFormatter()
        //};

        //resp.Content.ReadAsAsync<IEnumerable<Weather>>(formatters);

    }
}
