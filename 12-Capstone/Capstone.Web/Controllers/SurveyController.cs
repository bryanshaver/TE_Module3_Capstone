using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyResultDAO surveyResultDAO;
        private IParkDAO parkDAO;

        public SurveyController(ISurveyResultDAO surveyResultDAO, IParkDAO parkDAO)
        {
            this.surveyResultDAO = surveyResultDAO;
            this.parkDAO = parkDAO;

        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            SurveyResultVM vm = new SurveyResultVM();
            vm.Parks = new SelectList(parks, "ParkCode", "ParkName");
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(SurveyResultVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            SurveyResult survey = vm.Survey;
            surveyResultDAO.SaveSurvey(survey);
            return RedirectToAction("Results");
            
        }

        public IActionResult Results()
        {
            IList<SurveyResultVM> surveys = surveyResultDAO.GetSurveyResultsOrdered();
            return View(surveys); 
        }

    }
}