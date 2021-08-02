using System;
using System.Threading;


namespace Lab2_4_Factorial
{
    class Program
    {
        static int calcMax()
        {
            int index = 1;
            ulong result = 1;

            for (int i = 1; ; i++)
            {
                if (result * (ulong)i > ulong.MaxValue || result * (ulong)i <= 0) break;

                result *= (ulong)i;
                index = i;
            }

            return index;

        }



        static bool IsValidInput(string userInput, int maxVal, out bool cont)
        {
            cont = true;

            if (Int32.TryParse(userInput, out int num))                                  // if it's a number test for valid conditions and return false otherwise
            {
                if (num <= 0 || num > maxVal) return false;
                return true;
            }
            else if (!String.IsNullOrWhiteSpace(userInput) && userInput[0].Equals('q'))   //set flag for quit if and only if user inputs 'q'
            {
                cont = false;
                return true;
            }
            return false;
        }



        static void Main(string[] args)
        {


            string version = "0.1";
            int maxInput = calcMax();                          //previosuly calculated to be the largest # that you can input before overflow occurs; should be 65

            int usrNum;
            long result;
            string userInput;


            Console.WriteLine($"============================================= Factorial Calculator {version} =============================================\n");
            while (true)
            {


                do
                {
                    Console.Write("Please input a valid integer between 1 and 65 (or enter 'q' to quit) > \t");
                    userInput = Console.ReadLine();

                }
                while (!IsValidInput(userInput, maxInput, out bool cont) && cont);



                if (userInput[0].Equals('q')) return;

                result = 1;
                usrNum = int.Parse(userInput);

                for (int i = 1; i <= usrNum; i++)
                {
                    result *= i;

                    if (usrNum >= 10)             //skip output if the input is greater than 10 and the index is between 3 and 1 less than the input
                    {
                        if (i == 3) Console.Write("...x ");
                        if (i > 2 && i < usrNum - 1) continue;
                    }


                    Console.Write($"{i}");
                    if (i < usrNum) Console.Write(" x ");



                }

                Console.WriteLine($"\n=\t{result}");





            }

























        }
    }
}
