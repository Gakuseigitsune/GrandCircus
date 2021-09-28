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



        public async Task<IActionResult> GetDeck()
        {
            if (DAL.Session_Deck != null) return Redirect("Index");

            DAL.Client.BaseAddress = new Uri(DAL.Domain);

            var connection = await DAL.Client.GetAsync(DAL.API_GET_DECK);
            DAL.Session_Deck = await connection.Content.ReadAsAsync<Deck>();

            //return Redirect("GetHand");
            return Content("new deck!");
        }

        public async Task<IActionResult> GetHand()
        {
            DAL.Client.BaseAddress = new Uri(DAL.Domain);
            var connection = await DAL.Client.GetAsync(String.Format(DAL.API_DRAW_CARD, DAL. Session_Deck.deck_id, Hand.MAX_CT - DAL.Session_Hand.cards.Count));

            foreach (Card c in DAL.Session_Deck.cards) DAL.Session_Hand.AddCard(c);

            //return Redirect("Index");
            return Content($"{DAL.Session_Deck.cards.Count} card hand drawn!");
        }

        public async Task<IActionResult> DrawHand()
        {
            DAL.Client.BaseAddress = new Uri(DAL.Domain);

            var connection = await DAL.Client.GetAsync(string.Format(DAL.API_DRAW_CARD,DAL.Session_Deck.deck_id));
            DAL.Session_Deck = await connection.Content.ReadAsAsync<Deck>();

            //return Redirect("Index");
            return Content($"{DAL.Session_Deck.cards.Count} card hand drawn!");
        }


        public IActionResult Index()
        {
            if (DAL.Session_Deck == null || !DAL.Session_Deck.success) return Redirect("GetDeck");

            return View(DAL.Session_Deck);
        }



    }
}
