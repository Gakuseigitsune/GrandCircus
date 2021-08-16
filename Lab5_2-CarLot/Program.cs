using System;
using System.Threading;
using System.Collections.Generic;


namespace Lab5_2_CarLot
{

    enum CarMake
    {
        Ford,
        Chevrolet,
        Chrystler,
        Honda,
        Dodge,
        Toyota,
        VW

    }




    class Car
    {
        public static int CarMakes = 7;

        protected CarMake Make;
        protected string Model;
        protected int Year;
        protected double Price;


        public Car() { }
        public Car(CarMake make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;

        }

        public CarMake GetMake() => Make;
        public string GetModel() => Model;
        public int GetYear() => Year;
        public double GetPrice() => Price;


        public override string ToString()
        {
            return string.Format(" MAKE: {0}\n MODEL: {1}\n YEAR: {2}\n PRICE:{3:C}\n", Make, Model, Year, Price);
        }

    }

    class NewCar : Car
    {
        private bool ExtendedWarranty;

        public NewCar(CarMake make, string model, int year, double price, bool ext_Warranty)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            ExtendedWarranty = ext_Warranty;

        }

        public override string ToString()
        {
            string warranty;

            if (ExtendedWarranty) warranty = "Yes";
            else warranty = "No";

            return base.ToString() + "W/ EXTD. WARRANTY: " + warranty + "\n";
        }

    }


    class UsedCar : Car
    {
        private int NumberOfOwners;
        private int Mileage;


        public UsedCar(CarMake make, string model, int year, double price, int numOwners, int Miles)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            NumberOfOwners = numOwners;
            Mileage = Miles;


        }


        public override string ToString()
        {
            string usedInfo = string.Format("PREVIOUS OWNERS: {0}\n MILEAGE: {1}\n", NumberOfOwners, Mileage);
            return base.ToString() + usedInfo;
        }

    }



    class Program
    {

        static bool check_Y_N(string usrInp, out char usrChoice)                                                      // check for a y or n 
        {
           

            if (String.IsNullOrWhiteSpace(usrInp) || usrInp.Length > 1 || (usrInp.ToLower().Trim() != "n" && usrInp.ToLower() != "y"))
            {
                usrChoice = '\0';
                return false;

            }

            usrChoice = usrInp[0];
            return true;

        }



        static bool check_Y_N(string usrInp, char c_y)                                            // overload check for specific char c_y
        {
            c_y = Char.ToLower(c_y);

            if (String.IsNullOrWhiteSpace(usrInp) || usrInp.Length > 1 || usrInp.ToLower().Trim() != c_y.ToString()) return false;

            return true;

        }

        static void ListInv(List<Car> inv)
        {
            foreach (Car c in inv)
            {
                Console.Write("{0}:{1}\n",inv.IndexOf(c)+1, c);
                Thread.Sleep(350);

            }

            Console.Write("\t--------------------------------------------\n");
        }

        static List<Car> GenerateStock(int numCars, Random R)
        {
            List<Car> Stock = new List<Car>();
            


            for(int i = 0; i < numCars; i++)
            {

                if(R.Next(1,11) < 4)
                {
                    UsedCar u_c = new UsedCar((CarMake)R.Next(Car.CarMakes), "MODEL " + R.Next(51), R.Next(1965, 2022), Math.Floor(R.NextDouble() * R.Next(28000, 75000)), R.Next(1, 3), R.Next(12000, 80000));
                    Stock.Add(u_c);
                    continue;
                }
                NewCar n_c = new NewCar((CarMake)R.Next(Car.CarMakes), "MODEL " + R.Next(51), R.Next(2020, 2022), Math.Floor(R.NextDouble() * R.Next(40000, 90000)), R.Next(1, 10) > 7);
                Stock.Add(n_c);

                
            }




            return Stock;
            

           
        }

        static void PurchaseInv(List<Car> Stock, int usrInt)
        {
            string usrInp;
            bool invalidInp = true;
            char usrCh;

            Console.WriteLine("\nPurchase car # {0} ({1} {2}) for {3:C} ? (y/n)", usrInt, Stock[usrInt].GetMake(), Stock[usrInt].GetModel(), Stock[usrInt].GetPrice());
            do
            {
                Console.Write("\n>\t");
                usrInp = Console.ReadLine();


                if (check_Y_N(usrInp, out usrCh)) invalidInp = false;


            }
            while (invalidInp);

            if (Char.ToLower(usrCh) == 'n')
            {
                Console.WriteLine("Purchase cancelled!\n");
                return;
            }
            Stock.Remove(Stock[usrInt]);
            Console.WriteLine("Vehilce Purchase Initiated! Please Standby\n");
            Thread.Sleep(1350);


        }


        static void AddInv(List<Car> inv) // NOTE No input validation yet implemented 
        {
            CarMake make;
            string usrInp, model;
            int miles, numOwners, year;
            double price;
            bool isUsed, hasExWrnty;

            Console.WriteLine("Please enter the details for the new inventory\n");

            Console.Write("CONDITION: (new/used) >\t");
            usrInp = Console.ReadLine();
            if (usrInp.ToLower() == "new") isUsed = false;
            else isUsed = true;


            for (int i = 0; i < Car.CarMakes; i++) Console.WriteLine("\n" + i + ": " + (CarMake)i + "\n");
            Console.Write("\nMAKE: >\t");
            make = (CarMake)int.Parse(Console.ReadLine());


            Console.Write("MODEL: >\t");
            model = Console.ReadLine();

            Console.Write("YEAR: >\t");
            year = int.Parse(Console.ReadLine());

            Console.Write("PRICE: >\t");
            price = double.Parse(Console.ReadLine());

            if (isUsed)
            {
                Console.Write("# PREVIOUS OWNERS: >\t");
                numOwners = int.Parse(Console.ReadLine());

                Console.Write("MILEAGE: >\t");
                miles = int.Parse( Console.ReadLine());

                UsedCar u_c = new UsedCar(make, model, year, price, numOwners, miles);
                inv.Add(u_c);


            }
            else
            {
                Console.Write("EXTENDED WARRANTY (y/n): >\t");
                usrInp = Console.ReadLine();

                if (check_Y_N(usrInp, out char usrChoice) && usrChoice == 'y') hasExWrnty = true;
                else hasExWrnty = false;

                NewCar n_c = new NewCar(make, model, year, price, hasExWrnty);
                inv.Add(n_c);

            }


            Console.WriteLine("\nNew Inventory added successfully!\n");





        }

        static void Main(string[] args)
        {
            Random R = new Random();
            List<Car> Stock = GenerateStock(20, R);


            bool quit = false;
            bool invalidInp = true;
            int usrInt;

            Dictionary<char, string> options = new Dictionary<char, string>();
            options.Add('A', "ADD INVENTORY");
            options.Add('Q', "QUIT");


            string usrInp;

            string ver = "0.09";

            //0.09 all functionality per specs, but missing input validation on AddInv

           

            Console.WriteLine($"----------------------------------\t CarShop {ver}\t ----------------------------------\n");
            while (true)
            {

                ListInv(Stock);

                Console.WriteLine("\nPlease select a car for purcahse or select one of the following options\n");
                foreach (var pair  in options)
                {
                    Console.Write("{0}: {1}\n", pair.Key, pair.Value);
                }



                do
                {
                    Console.Write("\n>\t");
                    usrInp = Console.ReadLine();

                    if (int.TryParse(usrInp, out usrInt) || (usrInt > 0 && usrInt <= Stock.Count) || options.ContainsKey(char.ToUpper(usrInp[0]))) invalidInp = false;                  
                    else if (check_Y_N(usrInp, 'q'))
                    {
                        quit = true;
                        break;
                    }


                }
                while (invalidInp);

                if (quit) break;
                else if (check_Y_N(usrInp, 'a')) AddInv(Stock);
                else PurchaseInv(Stock, usrInt-1);



            }

            Console.WriteLine("\nThank you for using CarShop! Goodbye.");




        }
    }
}
