using System;
using System.Threading;
using System.Collections.Generic;

namespace Lab3_2_2_Menu
{
    class Program
    {

        /*   static bool checkKey(Dictionary<string,double> menu, string possibleKey)                          //case-insensitive key checker
           {
               foreach (var keypair in menu)
               {
                   if (keypair.Key.ToLower() == possibleKey.ToLower()) return true;

               }
               return false;

           } */



        static void printList(Dictionary<string, double> menu)
        {
            Console.Write("\n");

            foreach (var keypair in menu)
            {
                Console.Write(string.Format("{0,-20}\t{1,-10:C}\n", keypair.Key, keypair.Value));
                Thread.Sleep(750);

            }
            Console.WriteLine("\n(end of menu)\n");
        }


        static void printList(Dictionary<char, string> list)                                                    //overload for other list type
        {
            Console.Write("\n");

            foreach (var keypair in list)
            {
                Console.Write(string.Format("{0, -20}\t{1,-10:C}\n", keypair.Key, keypair.Value));
                Thread.Sleep(250);
            }

        }

        static bool valInp(Dictionary<char, string> list, string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.ToUpper() == "L") return false;                                              //empty input or 'L' causes a loop without printing message 
            foreach (var keypair in list)
            {
                if (input.Length == 1 && list.ContainsKey(Char.ToUpper(input[0]))) return true;
            }

            Console.WriteLine("\ninvalid input!");
            return false;
        }



        static void modList(ref Dictionary<string, double> menu, char function)
        {
            string usrInp1, usrInp2;
            bool invalidInp = false;
            double usrInp3 = 0;
            char f = char.ToUpper(function);


            Console.Write("\n");

            switch (f)
            {

                case 'A':
                    {
                        Console.WriteLine("Please enter the name of the item you wish to add and its price\n(Type 'CANCEL' or '\\c' to return to main menu)");
                        do
                        {

                            Console.Write("\nNAME >\t");
                            usrInp1 = Console.ReadLine();

                            if (usrInp1.ToUpper() == "CANCEL" || usrInp1.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp1)) invalidInp = true;
                            else if (menu.ContainsKey(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem already exists!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        do
                        {
                            Console.Write("$>\t");
                            usrInp2 = Console.ReadLine();

                            if (usrInp2.ToUpper() == "CANCEL" || usrInp2.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp2) || !double.TryParse(usrInp2, out double price))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nprice is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp3 = price;
                            }
                        }
                        while (invalidInp);

                        menu.Add(usrInp1, usrInp3);
                        Console.WriteLine("\nnew item added successfully!");
                        Console.WriteLine(string.Format("\n{0} - {1:C}", usrInp1, usrInp3));

                        break;
                    }

                case 'C':
                    {
                        Console.WriteLine("Please enter the name of the item you wish to modify and its new price\n(Type 'CANCEL' or '\\c' to return to main menu)");
                        do
                        {

                            Console.Write("\nITEM >\t");
                            usrInp1 = Console.ReadLine();

                            if (usrInp1.ToUpper() == "CANCEL" || usrInp1.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp1)) invalidInp = true;
                            else if (!menu.ContainsKey(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem does not exist!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        do
                        {
                            Console.Write("$>\t");
                            usrInp2 = Console.ReadLine();

                            if (usrInp2.ToUpper() == "CANCEL" || usrInp2.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp2) || !double.TryParse(usrInp2, out double price))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nprice is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp3 = price;
                            }
                        }
                        while (invalidInp);

                        menu[usrInp1] = usrInp3;

                        Console.WriteLine($"\nprice updated successfully!");
                        Console.WriteLine(string.Format("{0} -> {1:C}", usrInp1, usrInp3));

                        break;





                    }
                case 'R':
                    {

                        Console.WriteLine("Please enter the name of the item you wish to remove\n(Type 'CANCEL' or '\\c' to return to main menu)");

                        do
                        {
                            Console.Write("\nITEM >\t");
                            usrInp1 = Console.ReadLine();

                            if (usrInp1.ToUpper() == "CANCEL" || usrInp1.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp1)) invalidInp = true;
                            else if (!menu.ContainsKey(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem not found!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        menu.Remove(usrInp1);
                        Console.WriteLine($"\nitem {usrInp1} removed successfully");

                        break;





                    }


            }

            return;

        }






        static void Main(string[] args)
        {
            Dictionary<char, string> functionList = new Dictionary<char, string>();

            functionList.Add('A', "ADD ITEM");
            functionList.Add('R', "REMOVE ITEM");
            functionList.Add('C', "CHANGE ITEM");



            Dictionary<string, double> Menu = new Dictionary<string, double>();

            Menu.Add("Turkey Sammich (Rye)", 7.00);
            Menu.Add("Ham Sammich (White)", 6.00);
            Menu.Add("Chicken Shwarma", 9.00);
            Menu.Add("Fries", 2.50);
            Menu.Add("Fries (sweet potato)", 3.00);
            Menu.Add("Reuben Sammich", 8.00);

            string version = "0.07"; // 0.05 removed unneded menu validation function, implemented full functionality
                                     // 0.07 removed typos in output formatting, removed case sensitivity for functions 



            string usrInp;



            Console.WriteLine($"////////////////////////////////////////////////// EasyMenu ver {version} ////////////////////////////////////////////////// ");


            while (true) //home menu
            {

                printList(Menu);

                do
                {
                    Console.Write("\nPlease select a function to continue ('L' to list all fuctions or 'Q' to quit) >\t");

                    usrInp = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(usrInp) && usrInp.Trim().ToUpper() == "Q") return;
                    else if (!String.IsNullOrWhiteSpace(usrInp) && usrInp.Trim().ToUpper() == "L") printList(functionList);

                }
                while (!valInp(functionList, usrInp));

                modList(ref Menu, usrInp[0]);



            }





        }
    }
}
