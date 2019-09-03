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
        private readonly BeerGeniusDbContext _beerGeniusDbContext;

        public HomeController(BeerGeniusDbContext beerGeniusDbContext)
        {
            _beerGeniusDbContext = beerGeniusDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Question1()
        {
            var buildFlavorProfile = new FlavorProfile();
            return View(buildFlavorProfile);
        }

        public async Task<IActionResult> Question2(FlavorProfile buildFlavorProfile)
        {
            var test = buildFlavorProfile;
            return View(test);
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

        public async Task<IActionResult> AddValue(FlavorProfile addToFlavorProfile)
        {

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