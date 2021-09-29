using Lab15_1_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

namespace Lab15_1_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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


        public IActionResult GetDeckTest()
        {
            return Content(DAL.Client().BaseAddress.ToString());
        }

        
        public async Task<IActionResult> GetDeck()
        {
            if (DAL.Session_Deck != null) return Redirect("Index");

            var connection = await DAL.Client().GetAsync(DAL.API_GET_DECK);
            DAL.Session_Deck = await connection.Content.ReadAsAsync<Deck>();

             connection = await DAL.Client().GetAsync(String.Format(DAL.API_DRAW_CARD, DAL.Session_Deck.deck_id, Hand.MAX_CT));
            //connection = await DAL.Client().GetAsync($"https://deckofcardsapi.com/api/deck/{DAL.Session_Deck.deck_id}/draw/?count=2");
            string test = await connection.Content.ReadAsStringAsync();

            //foreach (Card c in DAL.Session_Deck.cards) DAL.Session_Hand.AddCard(c);

            //return Content($"new deck! {DAL.Session_Hand.Cards} card hand drawn!\n{test}");
            return Redirect("GetHand"); 

        } 

        public async Task<IActionResult> GetHand()
        {
           
            var connection = await DAL.Client().GetAsync(String.Format( DAL.API_DRAW_CARD, DAL.Session_Deck.deck_id, Hand.MAX_CT - DAL.Session_Hand.Cards));
            DAL.Session_Deck = await connection.Content.ReadAsAsync<Deck>();

            foreach (Card c in DAL.Session_Deck.cards) DAL.Session_Hand.AddCard(c);

            //return Content($"{DAL.Session_Hand.Cards} card hand drawn!");
            return Redirect("Index");


        }


        public IActionResult Index()
        {
            if (DAL.Session_Deck == null || !DAL.Session_Deck.success) return Redirect("GetDeck");

            return View(DAL.Session_Deck);
        }

        public IActionResult DisCards(string[] discarded)
        {

            foreach (string code in discarded)
            {
                DAL.DisCard(code);
            }


            return Redirect("Index");
        }


    }
}
