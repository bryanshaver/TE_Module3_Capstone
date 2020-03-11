﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyResultDAO surveyResultDAO;

        public SurveyController(ISurveyResultDAO surveyResultDAO)
        {
            this.surveyResultDAO = surveyResultDAO;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SurveyResult survey) // may just use surveyID make sure to test
        {
            if (!ModelState.IsValid)
            {
                return View(survey);
            }

            surveyResultDAO.SaveSurvey(survey);
            return RedirectToAction("Results");
            
        }

        public IActionResult Results(IList<SurveyResult> surveys)
        {
            return View(surveys); // display data from ALL of the survey results
        }

    }
}