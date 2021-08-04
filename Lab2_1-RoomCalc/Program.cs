using System;

namespace Lab2_1_RoomCalc
{
 
    class Program
    {
        static void Main(string[] args)
        {

            string[] paramChoices = { "LENGTH", "WIDTH", "HEIGHT" };
            string[] usrInpt = new string[paramChoices.Length];
            double[] usrDub = new double[paramChoices.Length];

            string roomType, usrChoice;
            double length, width, height, area, perimeter, volume;

            while (true)
            {

                /* original basic for loop - assumes HEIGHT stored at index 2 of arrays
                 
                for (int i = 0; i < 3; i++)      //loop 3 times for the individual values 
                {


                    do
                    {
                        Console.WriteLine($"Please enter a valid input for the {paramChoices[i]} of the room");
                        usrInpt[i] = Console.ReadLine();

                        if (i == 2)
                        {
                            break;
                        }

                    } while (String.IsNullOrWhiteSpace(usrInpt[i]) || !Double.TryParse(usrInpt[i], out usrDub[i]));  //cont. prompt for valid input for at least l & w

                }
                */

                                                                  
                foreach (string param in paramChoices)      //loop for each of the parameters in the parameter array
                {
                    int i = Array.IndexOf(paramChoices, param);
                    
                    do
                    {
                        Console.WriteLine($"Please enter a valid input for the {paramChoices[i]} of the room");
                        usrInpt[i] = Console.ReadLine();

                        if (string.Equals(param,"HEIGHT"))                                                           
                        {                                                                                                                                                           
                            break;                                                                                                                                                  
                        }                                                                                                                                                           
                                                                                                                                                                                   
                    } while (String.IsNullOrWhiteSpace(usrInpt[i]) || !Double.TryParse(usrInpt[i], out usrDub[i]));  //checks and prompts for valid input for at least l & w, ignores h

                }


                length = usrDub[Array.IndexOf(paramChoices, "LENGTH")];
                width = usrDub[Array.IndexOf(paramChoices, "WIDTH")];

                perimeter = length * 2 + width * 2;
                area = length * width;



                if (area <= 250)                              
                {
                    roomType = "small";
                }
                else if (area < 650 && area > 250)
                {
                    roomType = "medium";
                }
                else
                {
                    roomType = "large";
                }

                Console.WriteLine($"This is a {roomType} room with an area of {area} sq ft and perimeter of {perimeter} ft");

                

                if (double.TryParse(usrInpt[Array.IndexOf(paramChoices, "HEIGHT")], out height))        //check for user input for volume, calculate and print if valid
                {
                    volume = length * width * height;
                    Console.WriteLine($"..and a volume of {volume} cu ft");
                }



                Console.WriteLine("(please enter 'q' to quit or press enter to continue)");
                usrChoice = Console.ReadLine();

                if ( !string.IsNullOrEmpty(usrChoice) && usrChoice[0].Equals('q'))
                {
                    break;
                }





            }
            







        }
    }
}

