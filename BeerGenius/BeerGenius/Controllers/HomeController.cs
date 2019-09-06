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
            var userId = (int)session.GetInt32("UserId");
            var user = beerGeniusDbContext.BeerGeniusUsers.Find(userId);

            newFlavorProfile.UserId = userId;
            newFlavorProfile.BeerGeniusUser = user;

            beerGeniusDbContext.UserFlavorProfiles.Add(newFlavorProfile);
            beerGeniusDbContext.SaveChanges();

            //var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Last();
            //session.SetInt32("UserFlavorProfileId", buildFlavorProfile.UserFlavorProfileId);

            session.SetInt32("CurrentQuestion", 1);

            return RedirectToAction("Question1", "Questions", newFlavorProfile);
        }

        public IActionResult AddValue(FlavorProfile addToFlavorProfile)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            buildFlavorProfile.ABV += addToFlavorProfile.ABV;
            buildFlavorProfile.Color += addToFlavorProfile.Color;
            buildFlavorProfile.Crisp += addToFlavorProfile.Crisp;
            buildFlavorProfile.Hop += addToFlavorProfile.Hop;
            buildFlavorProfile.Malt += addToFlavorProfile.Malt;
            buildFlavorProfile.Fruity += addToFlavorProfile.Fruity;
            buildFlavorProfile.Sour += addToFlavorProfile.Sour;
            buildFlavorProfile.Roasty += addToFlavorProfile.Roasty;
            buildFlavorProfile.Sweetness += addToFlavorProfile.Sweetness;

            beerGeniusDbContext.SaveChanges();
            beerGeniusDbContext.Update(buildFlavorProfile);

            
            var nextQuestion = session.GetInt32("CurrentQuestion");
            nextQuestion += 1;
            session.SetInt32("CurrentQuestion", (int)nextQuestion);

            if (session.GetInt32("CurrentQuestion") == 10)
            {
                return RedirectToAction("GetResults", buildFlavorProfile);
            }
            else
            {
                return RedirectToAction($"Question{nextQuestion}", "Questions", buildFlavorProfile);
            }
        }

        public IActionResult GetResults(FlavorProfile finalFlavorProfile)
        {
            int finalStyleInt = 0;
            var stylesToCheck = beerGeniusDbContext.FlavorProfiles;
            foreach (var style in stylesToCheck)
            {
                if (style.Hop == finalFlavorProfile.Hop)
                {
                    finalStyleInt = style.Id;
                }
            }
            return RedirectToAction("DisplayFinalResults", new { id = finalStyleInt });
        }

        public async Task<IActionResult> DisplayFinalResults(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox-api.brewerydb.com/v2/");

            var response = await client.GetAsync($"style/{id}?key=7ff275d01954f19419c312477a03e672");
            var content = await response.Content.ReadAsAsync<IndividualStyle>();
            return View(content);
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
