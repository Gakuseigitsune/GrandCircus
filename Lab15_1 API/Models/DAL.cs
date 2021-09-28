using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

namespace Lab15_1_API.Models
{
    public class DAL
    {

        public static Deck Session_Deck;
        public static List<Card> Session_Discard = new List<Card>();
        bool recharge = (Session_Discard.Count == 52);
        public static Hand Session_Hand = new Hand();

        public static string Domain = "https://deckofcardsapi.com";
        public static HttpClient Client = new HttpClient();


        public static string API_GET_DECK  = "/api/deck/new/shuffle/?deck_count=1";
        public static string API_DRAW_CARD = "/api/deck/{0}/draw/?count={0}";

    }
}
