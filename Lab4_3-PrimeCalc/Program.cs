using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab4_3_PrimeCalc
{
    public class PrimeNumber
    {
        public static int GetPrime(int n)
        {

            int result = 2;                                    // initialized to lowest prime

            if (n == 1) return result;

            for (int i = 1; i < n; i++)
            {
                result++;


                if (result % 2 == 0) result++;                // additional increment if even

                int current_res = result;

                for (int j = 3; j < current_res; j++)
                {
                    

                    if (result % j == 0)     //check though every number up to the previous result for factors (starts at 3)
                    {
                        result++;            //increment if found and reset counter to 3 
                        j = 3;
                    }

                }
            }

            return result;
        }



    }


    public class Program
    {




        

        static void Main(string[] args)
        {

            bool invInp = true;
            string usrInp;
            int usrInt;

            string ver = "0.07";

            Console.Write($">>>>>>>>>>>>>>>>>>>>>\tPrimeCalc ver {ver}\t<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n\n");

            Console.Write("Please enter a valid integer\n");

            do
            {
                Console.Write("  \n>\t");
                usrInp = Console.ReadLine();
                if (int.TryParse(usrInp, out usrInt)) invInp = false;

            }
            while (invInp);



            Console.WriteLine("\nThe prime number corresponding to position {0} is {1}", usrInt, PrimeNumber.GetPrime(usrInt));
        }
    }
}
