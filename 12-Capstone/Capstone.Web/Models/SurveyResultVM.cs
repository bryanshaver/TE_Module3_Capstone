using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResultVM
    {
        public int NumOfFaves { get; set; }

        public string ParkCode { get; set; }

        public SelectList Parks { get; set; }

        public SurveyResult Survey { get; set; }
    }
}
