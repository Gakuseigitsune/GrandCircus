using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15_1_API.Models
{
    public class Deck
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public Card[] cards { get; set; }
        public int remaining { get; set; }

        public override string ToString()
        {
            return String.Format("DECK {0} CARDS LEFT: {1}", deck_id, remaining);
        }

    }

    public class Card
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }


    public class Hand
    {
        public static int MAX_CT = 5;

        public List<Card> _cards = new List<Card>();

        public void AddCard(Card c) => _cards.Add(c);
        public void DisCard(int index) => _cards.RemoveAt(index);
        public void DisCard(Card c) => _cards.Remove(c);

        public int Cards
        {
            get { return _cards.Count; }
        }
    }
}
