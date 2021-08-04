using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab4_2_2_ObjPrac
{
    public class MenuItem
    {
        private int ID;
        private string Name;
        private string Description;
        private double Price;

        /*public MenuItem()                               //for testing ToString()
          {
              ID = 0;
              Name = "TEST";
              Description = "This is a tester";
              Price = 0;

          }*/

        public MenuItem(int ID, string Name, string Description, double Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
        }

        public MenuItem(int ID, string Name, double Price)
        {
            this.ID = ID;
            this.Name = Name;
            Description = "EMPTY";
            this.Price = Price;
        }

        public int GetID() => ID;

        public string GetName() => Name;

        public string GetDescription() => Description;

        public double GetPrice() => Price;


        public void SetID(int ID) => this.ID = ID;

        public void SetName(string Name)
        {
            if (String.IsNullOrWhiteSpace(Name)) this.Name = "EMPTY";
            else this.Name = Name;
        }

        public void SetDescription(string Description)
        {
            if (String.IsNullOrWhiteSpace(Description)) this.Description = "EMPTY";
            else this.Description = Description;
        }

        public void SetPrice(double Price)
        {
            if (Price < 0.50) this.Price = 0.50;
            else if (Price > 10) this.Price = 10;
            else this.Price = Price;
        }




        public override string ToString()
        {
            return String.Format(" {0} (#{1})\n \"{2}\"\n - {3:C}", Name, ID, Description, Price);
        }



    }

    class Program
    {
        static void Main(string[] args)
        {

            int[] IDs = { 1250, 3506, 7707, 3456, 7890, 4567, 9080 };
            string[] Names = { "Item A", "Item B", "item c", "item d", "ITEM E", "ITEM F", "item G" };
            string[] Descriptions = { "does things", "does stuff", "does more things", "does more stuff", "does even MORE stuff", "doesn't do much", "does things and stuff" };
            double[] Prices = { 12.50, 3.50, 2.25, 189.99, 7, 99.99, 1325.79 };

            int testObj = 7;

            /*MenuItem item1 = new MenuItem();

              Console.WriteLine(item1);*/


            Random r = new Random();
            List<MenuItem> menuItems = new List<MenuItem>();

            Console.WriteLine("Generating test objects..");

            for (int i = 0; i < testObj; i++)
            {

                menuItems.Add(new MenuItem(IDs[r.Next(testObj)], Names[r.Next(testObj)], Descriptions[r.Next(testObj)], Prices[r.Next(testObj)]));

            }

            Thread.Sleep(2500);

            Console.WriteLine("Objects generated!\n");
            Thread.Sleep(1000);
            Console.WriteLine("Listing objects..\n");
            Thread.Sleep(1000);


            foreach (MenuItem m in menuItems)
            {
                Console.WriteLine($"{m}\n");
                Thread.Sleep(550);

            }

            Console.WriteLine("Testing Setters..\n");
            Thread.Sleep(1000);

            foreach (MenuItem m in menuItems)
            {
                if (menuItems.IndexOf(m) % 2 == 0)
                {
                    m.SetPrice(0.10);
                    m.SetName(null);
                    m.SetName(null);
                }
                else
                {
                    m.SetPrice(20);
                    m.SetName("");
                    m.SetName("");
                }

                m.SetID(r.Next(1001));

                Console.WriteLine($"{m}\n");

                Thread.Sleep(550);

            }

            Console.WriteLine("Testing Getters..\n");
            Thread.Sleep(1000);

            foreach (MenuItem m in menuItems)
            {

                Console.Write(" {0}", m.GetName());                
                Console.WriteLine(" ({0})", m.GetID());
                Thread.Sleep(250);
                Console.WriteLine(" \"{0}\"", m.GetDescription());
                Thread.Sleep(250);
                Console.WriteLine(" -{0:C}\n", m.GetPrice());


                Thread.Sleep(350);

            }

            Console.WriteLine("\nTest completed!");
            Console.ReadLine();






















        }
    }
}
