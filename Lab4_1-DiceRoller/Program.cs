using System;
using System.Threading;
using System.Collections.Generic;

namespace Lab4_1_DiceRoller
{

    public class Dice
    {


        private int value;
        private int sides;

        public Dice(int sides) => this.sides = sides;


        public void Roll(Random r)
        {
            int new_value = r.Next(1, sides + 1);
            value = new_value;
        }

        public int GetValue() => value;
 
    }



    public class DiceRoll
    {

        private int diceCount = 2;
        private int value;
        private bool hasCombo;
        private List<string> combo = new List<string>();



        private Dice d_1;
        private Dice d_2;

        public DiceRoll(Random rando, int diceSides)
        {

            d_1 = new Dice(diceSides);
            d_2 = new Dice(diceSides);

            d_1.Roll(rando);
            d_2.Roll(rando);

            value = d_1.GetValue() + d_2.GetValue();

            if (diceSides == 6)
            {
                if (d_1.GetValue() == 1 && d_2.GetValue() == 1)
                {
                    combo.Add("Snake Eyes");
                    hasCombo = true;
                }
                else if ((d_1.GetValue() == 1 && d_2.GetValue() == 2) || (d_1.GetValue() == 2 && d_2.GetValue() == 1))
                {
                    combo.Add("Ace Duce");
                    hasCombo = true;
                }
                else if (d_1.GetValue() == 6 && d_2.GetValue() == 6)
                {
                    combo.Add("Box Cars");
                    hasCombo = true;
                }

                if (value == 7 || value == 11)
                {
                    combo.Add("WIN!");
                    hasCombo = true;
                }
                else if (value == 2 || value == 3 || value == 12)
                {
                    combo.Add("Craps!");
                    hasCombo = true;

                }


            }
            else hasCombo = false;



        }

        public int GetValue() => value;
        public int[] GetDiceValue() => new int[2] { d_1.GetValue(), d_2.GetValue() };
        public int GetDiceCount() => diceCount;

        public void PrintCombo()
        {
            if(hasCombo)
            {
                foreach(string s in combo)
                {
                    Console.WriteLine("\n{0}", s);

                }

            }

        }





    }
    class Program
    {


        static void RollDice(Random rando, int diceSides)
        {
            Console.WriteLine("Rolling Dice!\n");
            DiceRoll roll = new DiceRoll(rando, diceSides);

            for (int i = 0; i < 3; i++)
            {
                Console.Write(". ");
                Thread.Sleep(250);
                Console.Write(". ");
                Thread.Sleep(350);
                Console.Write(". \n");
                Thread.Sleep(450);


            }

            Thread.Sleep(750);

            Console.WriteLine("\nYou rolled {0} {1} sided dice and got a {2} and {3}",roll.GetDiceCount(), diceSides, roll.GetDiceValue()[0], roll.GetDiceValue()[1]);
            roll.PrintCombo();






        }


        static void Main(string[] args)
        {
            string usrInp;
            string ver = "0.07";
            


            Console.WriteLine($"|||||||||||||||||||||||||||||||||||||||||||||\tDiceRoller ver {ver}\t|||||||||||||||||||||||||||||||||||||||||||||\n");


            Random rando = new Random();

            Console.Write("Welcome! ");

            while (true)
            {

                Console.WriteLine("What sided dice would you like to use?");
                do
                {
                    Console.Write("\n( please enter a number between 4 and 20 ) \t");
                    usrInp = Console.ReadLine();

                }
                while (!int.TryParse(usrInp, out int i) || i < 4 || i > 20);

                RollDice(rando, int.Parse(usrInp));



                do
                {
                    Console.Write("\nWould you like to play again? (y/n)\t");
                    usrInp = Console.ReadLine();


                }
                while (!usrInp.ToLower().Equals("n") && !usrInp.ToLower().Equals("y") || usrInp.Length > 1);

                if (usrInp == "n") return;

            }








        }
    }
}
