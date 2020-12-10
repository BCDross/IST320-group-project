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

        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// This registers a new user and sends a userID to the database.
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public IActionResult Register(User User)
        {
            DALUser dALPerson = new DALUser(_configuration);
            int UserID = dALPerson.InsertUser(User);

            User.UserId = UserID;

            return View(User);
        }
        
        /// <summary>
        /// Checks to see if UserID matches what is in database. 
        /// It returns login in successful if it matches and login in failed it it does not find a userID that matches it. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult checkValidUser(User user)
        {
            DALUser dp = new DALUser(_configuration);
            User personModel = dp.IsValidUser(user);

            if (personModel == null)
            {
                ViewBag.LoginMessage = "Login Failed";
            }
            else
            {
                HttpContext.Session.SetString("uID", Convert.ToString(user.UserId));
                ViewBag.LoginMessage = "Login Successful";
            }
            return View("HomePage");

        }
        
        /// <summary>
        /// Displays Home page with user name if login was successful or Index page if login failed. 
        /// </summary>
        /// <returns></returns>
        public IActionResult HomePage()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View("HomePage");
            }
        }


        /*public IActionResult Admin()
        public IActionResult Admin(User user)

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
        }*/

        /// <summary>
        /// Displays user account if logged in or index page.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult Account(int userId)
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                DALUser dUser = new DALUser(_configuration);
                User u = dUser.GetUserById(userId);
                return View(u);
            }
        }

        /// <summary>
        /// Displays a Create Deck form page.
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public IActionResult CreateDeck(Deck deck)
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                if (deck == null)
                {
                    return View("CreateDeck");
                }
                else
                {
                    deck.Created = DateTime.Now;
                    deck.CreatorUserId = Convert.ToInt32(struID);
                    DALDeck dalDeck = new DALDeck(_configuration);
                    dalDeck.InsertDeck(deck);

                    return View("BrowseCards");
                }
            }
        }

        /// <summary>
        /// Displays ViewDeck page after login or index page.
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public IActionResult ViewCard(int cardId)
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                DALCard dalCard = new DALCard(_configuration);
                Card c = dalCard.GetCardById(cardId);

                return View(c);
            }
        }
        
        /// <summary>
        /// Dsplays ViewDeck page after login or index page.
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public IActionResult ViewDeck(int deckId)
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                if (deckId == null || deckId == 0)
                {
                    return View("BrowseDecks");
                }
                else
                {
                    DALDeck dalDeck = new DALDeck(_configuration);
                    dalDeck.GetDeckByID(deckId);

                    return View(dalDeck);
                }
            }
        }
        
        /// <summary>
        /// Dsplays BrowseCards page after login or index page.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public IActionResult BrowseCards()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                DALCard dalCard = new DALCard(_configuration);
                LinkedList<Card> cardList = new LinkedList<Card>();
                cardList = dalCard.GetAllCards();

                return View(cardList);
            }
        }
        
        /// <summary>
        ///Dsplays BrowseDecks page after login or index page. 
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public IActionResult BrowseDecks()
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                DALDeck dalDeck = new DALDeck(_configuration);
                LinkedList<Deck> deckList = new LinkedList<Deck>();
                deckList = dalDeck.GetAllDecks();

                return View(deckList);
            }
        }
        /*public IActionResult Privacy()
        {
            return View();
        }*/
        
        /// <summary>
        /// Traces reason for error and returns an error message. 
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
