using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BurnBuilder.Models;
using BurnBuilder.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace BurnBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _configuration = config;
            _logger = logger;
        }

        public IActionResult Index(User User)
        {
            return View("Index");
        }
        public IActionResult HomePage(User user)
        {
            DALUser dp = new DALUser(_configuration);
            User personModel = dp.IsValidUser(user);

            if (personModel == null)
            {
                ViewBag.LoginMessage = "Login Failed";
            }
            else
            {
                HttpContext.Session.SetInt32("uID", personModel.UserId);
                ViewBag.LoginMessage = "Login Successful";
            }
            return View("HomePage");
        }

        public IActionResult Admin()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Account()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult ViewCard()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult ViewDeck()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult BrowseCards()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult BrowseDecks()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
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
