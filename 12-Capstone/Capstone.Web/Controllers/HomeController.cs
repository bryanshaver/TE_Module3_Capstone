using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;

        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }


        public IActionResult Detail(string parkCode, ParkWeatherVM vm)
        {
            // Get the details of the specific park and pass it into the view model.
            vm.Park = parkDAO.GetParkByCode(parkCode);

            //Get the weather for that particular park and pass it into the view model.
            IList<Weather> weather = weatherDAO.GetWeather(parkCode);

            //Seperate today's forecast from the rest of the days and then order the rest of the list.
            weather = vm.GetTodaysForecast(weather);
            vm.Weather = weather.OrderBy(w => w.FiveDayForecastValue).ToList();
            

            return View(vm);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
