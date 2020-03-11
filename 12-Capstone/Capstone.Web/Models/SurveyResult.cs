using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string State { get; set; }
        public string ActivityLevel { get; set; }
    }
}
