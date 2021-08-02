using System;
using System.Threading;

namespace Lab2_2_PowerTable
{
    class Program
    {


        static bool IsValidInput(string userInput, out bool quit)
        {
            quit = false;

            if (Int32.TryParse(userInput, out int num))                                  // if it's a number test for valid conditions and return false otherwise
            {
                double usrDub = num;
                if (Math.Pow(usrDub, 3) > Int32.MaxValue || num <= 0) return false;
                return true;
            }
            else if (!String.IsNullOrWhiteSpace(userInput) && userInput[0].Equals('q'))   //set flag for quit if and only if user inputs 'q'
            {
                quit = true;
                return true;
            }
            return false;
        }



        static void Main(string[] args)
        {


            string version = "0.07";
            string userInput;

            Console.WriteLine($"============================================= Table O Power version {version} =============================================\n");


            while (true)
            {



                do                                                                              //keep prompting for valid input until an int or quit flag is set
                {
                    Console.Write("Please enter a valid integer (or 'q' to quit):   ");
                    userInput = Console.ReadLine();

                }
                while (!IsValidInput(userInput, out bool quit) && !quit);

                if (userInput[0].Equals('q')) return;


                double usrExp = double.Parse(userInput);

                String head = string.Format("\n{0,15:G}|{1,20:G}|{2,25:G}|\n{3}", "NUMBER", "SQUARED (^2)", "CUBED (^3)", "-------------------------------------------------------------------------");
                Console.WriteLine(head);

                for (int i = 1; i <= (int)usrExp; i++)
                {
                    double j = i;
                    Console.Write(string.Format("{0,15}|{1,20}|{2,25}|\n", i, Math.Pow(i, 2), Math.Pow(i, 3)));
                    Thread.Sleep(750);
                }





            }



        }
    }
}
