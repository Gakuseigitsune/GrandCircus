using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15_1_API.Models
{
    public class Deck
    {
        public bool success { get; set; }
        public List<Card> cards { get; set; }
        public string deck_id { get; set; }
        public int remaining { get; set; }

        




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

        List<Card> userHand = new List<Card>(Hand.MAX_CT);



        public void AddCard(Card c) => userHand.Add(c);
        public void DisCard(int index) => userHand.RemoveAt(index);
        public void DisCard(Card c) => userHand.Remove(c);


        public static void DrawHand(Hand h)
        {


        }



    }
}
