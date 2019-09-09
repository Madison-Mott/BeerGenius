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
                RedirectToAction("SetSession", "Questions", foundUser);
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

            session.SetInt32("CurrentQuestion", 1);

            return RedirectToAction("Hop", "Questions", newFlavorProfile);
        }

        [HttpGet]
        public IActionResult AddValue(int passQuestionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();
            var redirect = session.GetString("Redirect");
            var property = session.GetString("Property");

            buildFlavorProfile.AddValues(property, passQuestionResult);

            beerGeniusDbContext.Update(buildFlavorProfile);
            beerGeniusDbContext.SaveChanges();

            if (redirect != "GetResults")
            {
                return RedirectToAction(redirect, "Questions");
            }
            else
            {
                return RedirectToAction(redirect, "Home");
            }
        }

        public IActionResult GetResults()
        {
            var finalFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();
            var stylesToCheck = beerGeniusDbContext.FlavorProfiles;
            var finalFlavorProfileList = new List<int>()
            {
                finalFlavorProfile.Hop,
                finalFlavorProfile.ABV,
                finalFlavorProfile.Color,
                finalFlavorProfile.Crisp,
                finalFlavorProfile.Fruity,
                finalFlavorProfile.Malt,
                finalFlavorProfile.Roasty,
                finalFlavorProfile.Sour,
                finalFlavorProfile.Sweetness
            };

            var matchingFlavorProfiles = new List<int>();
            int finalMatchedId = 0;
          
            for (int i = 9; i > 0; i--)
            {
                foreach (var style in stylesToCheck)
                {
                    var matchCounter = 0;
                    var stylesToCheckList = new List<int>()
                    {
                        style.Hop,
                        style.ABV,
                        style.Color,
                        style.Crisp,
                        style.Fruity,
                        style.Malt,
                        style.Roasty,
                        style.Sour,
                        style.Sweetness
                    };
                    for (int j = 0; j < stylesToCheckList.Count; j++)
                    {
                        if (stylesToCheckList[j] == finalFlavorProfileList[j])
                        {
                            matchCounter++;
                        }
                    }
                    if (matchCounter >= i)
                    {
                        matchingFlavorProfiles.Add(style.BreweryDbId);
                    }
                }
                if (matchingFlavorProfiles.Count > 0)
                {
                    var random = new Random();
                    int finalMatchedIdIndex = random.Next(matchingFlavorProfiles.Count);
                    finalMatchedId = matchingFlavorProfiles[finalMatchedIdIndex];
                    finalFlavorProfile.MatchingFlavorProfileId = finalMatchedId;
                    beerGeniusDbContext.Update(finalFlavorProfile);
                    beerGeniusDbContext.SaveChanges();
                    break;
                }
            }
            //foreach (var style in stylesToCheck)
            //{
            //    var stylesToCheckList = new List<int>()
            //    {
            //        style.Hop,
            //        style.ABV,
            //        style.Color,
            //        style.Crisp,
            //        style.Fruity,
            //        style.Malt,
            //        style.Roasty,
            //        style.Sour,
            //        style.Sweetness
            //    };

            //    if (stylesToCheckList.SequenceEqual(finalFlavorProfileList))
            //    {
            //        matchingFlavorProfiles.Add(style.Id);
            //    }
            //}

            //if (matchingFlavorProfiles.Count == 0)
            //{
            //    for (int i = 9; i > 0; i--)
            //    {
            //        foreach (var style in stylesToCheck)
            //        {
            //            var matchCounter = 0;
            //            var stylesToCheckList = new List<int>()
            //            {
            //                style.Hop,
            //                style.ABV,
            //                style.Color,
            //                style.Crisp,
            //                style.Fruity,
            //                style.Malt,
            //                style.Roasty,
            //                style.Sour,
            //                style.Sweetness
            //            };
            //            for (int j = 0; j < stylesToCheckList.Count; j++)
            //            {
            //                if (stylesToCheckList[j] == finalFlavorProfileList[j])
            //                {
            //                    matchCounter++;
            //                }
            //            }
            //            if (matchCounter >= i)
            //            {
            //                matchingFlavorProfiles.Add(style.Id);
            //            }
            //        }
            //        if (matchingFlavorProfiles.Count > 0)
            //        {
            //            break;
            //        }
            //    }
            //}

            return RedirectToAction("DisplayFinalResults", new {id = finalMatchedId });
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
