﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerGenius.Data;
using BeerGenius.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerGenius.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly BeerGeniusDbContext beerGeniusDbContext;
        private readonly ISession session;

        public QuestionsController(BeerGeniusDbContext _beerGeniusDbContext, IHttpContextAccessor httpContextAccessor)
        {
            beerGeniusDbContext = _beerGeniusDbContext;
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult SetSession(BeerGeniusUser foundUser)
        {
            session.SetInt32("UserId", foundUser.UserId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveSession()
        {
            session.Remove("User");
            session.Remove("UserId");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Hop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Hop(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "Crisp");
            session.SetString("Property", "Hop");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult Crisp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crisp(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "Malt");
            session.SetString("Property", "Crisp");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult Malt()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Malt(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "Fruity");
            session.SetString("Property", "Malt");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult Fruity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Fruity(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "Sour");
            session.SetString("Property", "Fruity");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult Sour()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sour(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "ABV");
            session.SetString("Property", "Sour");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult ABV()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ABV(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();
                       
            session.SetString("Redirect", "Roasty");
            session.SetString("Property", "ABV");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult Roasty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Roasty(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "Sweetness");
            session.SetString("Property", "Roasty");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult Sweetness()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sweetness(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "Color");
            session.SetString("Property", "Sweetness");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }

        public IActionResult Color()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Color(int questionResult)
        {
            var buildFlavorProfile = beerGeniusDbContext.UserFlavorProfiles.Where(x => x.UserId == (int)session.GetInt32("UserId")).Last();

            session.SetString("Redirect", "GetResults");
            session.SetString("Property", "Color");

            return RedirectToAction("AddValue", "Home", new { passQuestionResult = questionResult });
        }
    }
}