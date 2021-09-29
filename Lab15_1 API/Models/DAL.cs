using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

namespace Lab15_1_API.Models
{
    public class DAL
    {

        static string _Domain = "https://deckofcardsapi.com";
        static HttpClient _Client;

        public static string API_GET_DECK  = "/api/deck/new/shuffle/?deck_count=1";
        public static string API_DRAW_CARD = "/api/deck/{0}/draw/?count={1}";

        public static HttpClient Client()
        {
            if (_Client == null)
            {
                _Client = new HttpClient();
                _Client.BaseAddress = new Uri(_Domain);
            }

            return _Client;
        }

        public static void DisCard(string code)
        {
            List<int> indx = new List<int>();

            foreach (Card c in hand)
            {
                if ( c.code == code)
                {
                    indx.Add(hand.IndexOf(c));
                    Session_Discard.Add(c.code);
                }
            }

            foreach (int i in indx) hand.RemoveAt(i);

            
        }

        public static List<Card> hand
        {
            get { return Session_Hand._cards; }
        }

        public static List<Card> deck
        {
            get { return Session_Deck.cards.ToList(); }
        }

        public static Deck Session_Deck;
        public static List<string> Session_Discard = new List<string>();
        bool recharge = (Session_Discard.Count == 52);
        public static Hand Session_Hand = new Hand();

    }
}
