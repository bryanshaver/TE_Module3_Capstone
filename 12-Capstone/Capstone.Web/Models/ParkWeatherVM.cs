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

         public Dictionary<int, string> TempWarnings = new Dictionary<int, string>();
       

        public IList<Weather> Weather = new List<Weather>();


        
    }
}
