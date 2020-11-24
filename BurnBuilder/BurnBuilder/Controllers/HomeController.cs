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
            DALUser dp = new DALUser(_configuration);
            User personModel = dp.IsValidUser(User);

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
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult ViewCard()
        {
            return View();
        }
        public IActionResult ViewDeck()
        {
            return View();
        }
        public IActionResult BrowseCards()
        {
            return View();
        }
        public IActionResult BrowseDecks()
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
