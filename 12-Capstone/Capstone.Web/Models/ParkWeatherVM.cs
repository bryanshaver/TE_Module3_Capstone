using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkWeatherVM
    {
        public string ParkCode { get; set; }
        public Park Park { get; set; }

        public Weather Day { get; set; }
        public ParkWeatherVM(Park park, IList<Weather> weather)
        {
            Park = park;
            Weather = weather;
        }


        public IList<Weather> Weather = new List<Weather>();

        public Dictionary<string, string> WeatherAdvice = new Dictionary<string, string>();
        public Dictionary<int, string> TempWarnings = new Dictionary<int, string>();

        public string DisplayWeatherIcon (IList<Weather> weather)
        {
            Weather = weather;
            foreach (Weather day in weather)
            {
                if (day.Forecast == "sunny")
                {
                    WeatherAdvice["weather"] = "Make sure to wear sunblock!";
                    return "sunny";
                }
                else if(day.Forecast == "partly cloudy")
                {
                    return "partlyCloudy";
                }
                else if (day.Forecast == "cloudy")
                {
                    return "cloudy";
                }
                else if (day.Forecast == "rain")
                {
                    WeatherAdvice["weather"] = "Make sure to pack your rain gear and wear waterproof shoes!";
                    return "rain";
                }
                else if (day.Forecast == "thunderstorms")
                {
                    WeatherAdvice["weather"] = "Seek shelter immediately and avoid hiking on exposed ridges!";
                    return "thunderstorms";
                }
                else if (day.Forecast == "snow")
                {
                    WeatherAdvice["weather"] = "Make sure to pack your snowshoes!";
                    return "snow";
                }
            }
            return null;

        }

        
    }
}
