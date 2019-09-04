using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeerGenius.Models;
using System.Net.Http;
using BeerGenius.Data;
using Microsoft.AspNetCore.Http;

namespace BeerGenius.Controllers
{
    public class HomeController : Controller
    {
        private readonly BeerGeniusDbContext beerGeniusDbContext;
        private readonly ISession session;

        public HomeController(BeerGeniusDbContext _beerGeniusDbContext, IHttpContextAccessor httpContextAccessor)
        {
            beerGeniusDbContext = _beerGeniusDbContext;
            session = httpContextAccessor.HttpContext.Session;
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox-api.brewerydb.com/v2/");

            var response = await client.GetAsync($"styles/?key=7ff275d01954f19419c312477a03e672");
            var content = await response.Content.ReadAsAsync<StyleRequest>();
            return View(content);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(BeerGeniusUser registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }

            beerGeniusDbContext.BeerGeniusUsers.Add(registration);
            beerGeniusDbContext.SaveChanges();

            return RedirectToAction("Index", "Home", registration);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(BeerGeniusUser login)
        {
            var userName = login.UserName;
            var password = login.Password;

            var foundUser = beerGeniusDbContext.BeerGeniusUsers.Where(u => u.UserName == userName).Where(u => u.Password == password).FirstOrDefault();

            if (foundUser != null)
            {
                session.SetString("User", foundUser.UserName);
                session.SetInt32("UserId", foundUser.UserId);
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Login. Please try again.";
                return View();
            }

            return View("Index");
        }

        public IActionResult StartSurvey()
        {
            var newFlavorProfile = new UserFlavorProfile();
            newFlavorProfile.UserId = (int)session.GetInt32("UserId");
            beerGeniusDbContext.UserFlavorProfiles.Add(newFlavorProfile);
            beerGeniusDbContext.SaveChanges();

            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Last();
            session.SetInt32("UserFlavorProfileId", buildFlavorProfile.UserFlavorProfileId);

            return RedirectToAction("Question1", "Questions", buildFlavorProfile);
        }

        public async Task<IActionResult> AddValue(FlavorProfile addToFlavorProfile)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();
            buildFlavorProfile.ABV += addToFlavorProfile.ABV;
            buildFlavorProfile.Color += addToFlavorProfile.Color;
            buildFlavorProfile.Aroma += addToFlavorProfile.Aroma;
            buildFlavorProfile.Crisp += addToFlavorProfile.Crisp;
            buildFlavorProfile.Hop += addToFlavorProfile.Hop;
            buildFlavorProfile.Malt += addToFlavorProfile.Malt;
            buildFlavorProfile.Fruity += addToFlavorProfile.Fruity;
            buildFlavorProfile.Sour += addToFlavorProfile.Sour;
            buildFlavorProfile.Roasty += addToFlavorProfile.Roasty;
            buildFlavorProfile.Sweetness += addToFlavorProfile.Sweetness;

            beerGeniusDbContext.SaveChanges();
            beerGeniusDbContext.Update(buildFlavorProfile);

            return View("Index");
        }

        public IActionResult AboutCraftBeer()
        {
            return View();
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
