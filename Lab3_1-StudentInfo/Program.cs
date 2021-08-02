using System;

namespace Lab3_1_StudentInfo
{

    class Program
    {

        static void listAllStudents(string[] students)
        {
            foreach (string student in students)
            {
                Console.WriteLine(string.Format("{0,10}{1,15}", Array.IndexOf(students, student) + 1, student));
            }

            Console.Write(">\t");
        }


        static void listAllCategories(string[] categories)
        {
            foreach (string category in categories)
            {
                Console.WriteLine(category);
            }

            Console.Write(">\t");
        }


        static bool isValidSelection(string userInput, string[] choices, out int indexMatch)                      //checks for query matches and outputs the index of the matched term
        {
            indexMatch = -1;

            if (string.IsNullOrWhiteSpace(userInput)) return false;                                                //whitespace or empty input is ignored, user not told input is invalid 

            foreach (string choice in choices)
            {
                if (string.Equals(userInput.ToLower(), choice) || choice.Contains(userInput.ToLower()))
                {
                    indexMatch = Array.IndexOf(choices, choice);
                    return true;

                }
            }
            Console.WriteLine("Invalid selection");
            return false;
        }



        static bool isValidInput(string userInput, bool checkQuit, int arrayLen, out bool quit)                 //checks for valid number input to prevent OOB exceptions; additionally checks if user has requested to quit
        {
            quit = false;

            if (string.IsNullOrWhiteSpace(userInput)) return false;

            if (Int32.TryParse(userInput, out int num))
            {
                if (num - 1 < arrayLen && num - 1 >= 0) return true;


            }
            else if (checkQuit && (userInput.Trim()[0].Equals('y') || userInput.Trim()[0].Equals('n')))
            {
                quit = true;
                return false;

            }


            Console.WriteLine("Invalid input");
            return false;
        }

        static void Main(string[] args)
        {
            string[] categories = { "previous title", "favorite food" };
            string[] students = { "Doe, John", "Doe, James", "Doe, Jane" };
            string[] title = { "n/a", "n/a", "??" };
            string[] favoriteFood = { "Pasta", "sushi", "steak" };


            string userInp;
            string version = "0.10";                                                       // 0.10 added Trim() for checking single char input






            Console.WriteLine($" --------------------------------------- Student lookup ver {version} --------------------------------------- ");
            while (true)
            {


                do
                {
                    Console.Write($"\nPlease enter the ID number of the student you wish to look up (has to be a valid number between 1 and {students.Length})\n");
                    Console.Write("(press 'a' to list all students)\t");
                    userInp = Console.ReadLine();


                    if (!string.IsNullOrWhiteSpace(userInp) && userInp.Trim().Equals("a"))
                    {
                        listAllStudents(students);
                        userInp = Console.ReadLine();
                    }


                }
                while (!isValidInput(userInp, false, students.Length, out bool quit));

                int userIndex = int.Parse(userInp) - 1;                                       // adjust user input for zero-index

                while (true)
                {
                    bool quit = false;

                    Console.WriteLine($"You have selected {students[userIndex].ToUpper()} ");


                    do
                    {
                        Console.Write("Please enter a query term\n(press 'a' to list all available categories or 'q' to quit)\t");
                        userInp = Console.ReadLine();


                        if (!string.IsNullOrWhiteSpace(userInp) && userInp.Trim().Equals("a"))
                        {
                            listAllCategories(categories);

                            userInp = Console.ReadLine();
                        }
                        else if (!string.IsNullOrWhiteSpace(userInp) && userInp.Trim().Equals("q"))
                        {
                            quit = true;
                            break;
                        }

                    }
                    while (!isValidSelection(userInp, categories, out int indexMatch));

                    if (quit) break;

                    if (isValidSelection(userInp, categories, out int match))
                    {

                        switch (match)                                                              // cases correspond to index of catergories array
                        {

                            case 0:
                                Console.WriteLine($"\nThis student's previous title is \"{title[userIndex]}\"");
                                break;

                            case 1:
                                Console.WriteLine($"\nThis student's favorite food is \"{favoriteFood[userIndex]}\"");
                                break;

                        }

                    }

                }




                do
                {
                    Console.Write("\nWould you like to look up another student? (y/n)\t");
                    userInp = Console.ReadLine();
                }
                while (isValidInput(userInp, true, 2, out bool quit) || !quit);

                if (userInp.Trim()[0] == 'n') return;

            }










        }
    }
}

