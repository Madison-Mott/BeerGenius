using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeerGenius.Models;
using System.Net.Http;
using BeerGenius.Data;

namespace BeerGenius.Controllers
{
    public class HomeController : Controller
    {
        private readonly BeerGeniusDbContext beerGeniusDbContext;

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Question1()
        {
            var buildFlavorProfile = new FlavorProfile();
            return View(buildFlavorProfile);
        }
        public IActionResult CheapStuff()
        {
            return View();
        }
        public async Task<IActionResult> Question2(FlavorProfile buildFlavorProfile)
        {
            var test = buildFlavorProfile;
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

        public async Task<IActionResult> ListOfBeerStyles()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox-api.brewerydb.com/v2/");

            var response = await client.GetAsync($"styles/?key=7ff275d01954f19419c312477a03e672");
            var content = await response.Content.ReadAsAsync<StyleRequest>();
            return View(content);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
