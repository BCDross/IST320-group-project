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
        
        public IActionResult Register(User User)
        {
            DALUser dALPerson = new DALUser(_configuration);
            int UserID = dALPerson.InsertUser(User);

            User.UserId = UserID;

            return View(User);
        }
        
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

        public IActionResult Account(User user)
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                return View("Account");
            }
        }

        public IActionResult ViewCard(Card card)
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                DALCard uCard = new DALCard(_configuration);
                int cID = Convert.ToInt32(uCard.GetCardById(card.CardId));
                card.CardId = cID;

                return View(card);
            }
        }
        public IActionResult ViewDeck(Deck deck)
        {
            string struID = HttpContext.Session.GetString("uID");
            if (struID == null)
            {
                return View("Index");
            }
            else
            {
                if (deck == null || deck.DeckId == 0)
                {
                    return View("BrowseDecks");
                }
                else
                {
                    DALDeck uDeck = new DALDeck(_configuration);
                    int dID = Convert.ToInt32(uDeck.GetDeckByID(deck.DeckId));
                    deck.DeckId = dID;

                    return View(deck);
                }
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
                DALCard dalCard = new DALCard(_configuration);
                LinkedList<Card> cardList = new LinkedList<Card>();
                cardList = dalCard.GetAllCards();
                
                return View(cardList);
            }
        }
        public IActionResult BrowseDecks(Deck deck)
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
                    return View("BrowseDecks");
                }
                else
                {
                    DALDeck dalDeck = new DALDeck(_configuration);
                    LinkedList<Deck> deckList = new LinkedList<Deck>();
                    deckList = dalDeck.GetAllDecks();

                    return View(deckList);
                }
            }
        }
        /*public IActionResult Privacy()
        {
            return View();
        }*/
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
