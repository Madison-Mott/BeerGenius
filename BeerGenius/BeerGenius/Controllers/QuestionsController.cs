using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerGenius.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerGenius.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ISession session;

        public QuestionsController(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Question1()
        {
            return View();
        }

        public IActionResult Question2()
        {
            return View();
        }

        public IActionResult CheapStuff()
        {
            return View();
        }

        public IActionResult Outside()
        {
            return View();
        }

        public IActionResult HotWeather()
        {
            return View();
        }

        public IActionResult FunFunky()
        {
            return View();
        }

        public IActionResult EasyRefreshing()
        {
            return View();
        }

        public IActionResult ComfortableWeather()
        {
            return View();
        }

        public IActionResult Exercise()
        {
            return View();
        }

        public IActionResult NoExercise()
        {
            return View();
        }

        public IActionResult YesChallenges()
        {
            return View();
        }

        public IActionResult NoChallenges()
        {
            return View();
        }

        public IActionResult HeavyMeal()
        {
            return View();
        }

        public IActionResult LightMeal()
        {
            return View();
        }

        public IActionResult Dessert()
        {
            return View();
        }

        public IActionResult Inside()
        {
            return View();
        }

        public IActionResult AboutCraftBeer()
        {
            return View();
        }
    }
}