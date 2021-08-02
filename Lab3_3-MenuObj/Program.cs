using System;
using System.Threading;
using System.Collections.Generic;

namespace Lab3_3_MenuObj
{
    public class Inventoryitem
    {
        private string name;
        private uint qty;
        private double price;

        //private string SKU;


        public Inventoryitem(string n, uint q, double p)
        {

            name = n;
            qty = q;
            price = p;



        }
        public Inventoryitem()
        {

        }



        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double newPrice)
        {
            price = newPrice;

        }


        public uint GetQty()
        {
            return qty;
        }

        public void SetQty(uint newQty)
        {
            qty = newQty;

        }


        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            name = newName;
        }

        /*public string getSKU()          
         {
             return SKU;
         }*/


    }

    public class MenuItem : Inventoryitem                                           //for lab 3_3 specs
    {


        public void Sell(int howMany)
        {
            uint sellQty = (uint)howMany;
            uint stockQty = GetQty();
            double profit = 0;

            if (sellQty <= stockQty)
            {

                SetQty(stockQty - sellQty);

                profit = sellQty * GetPrice();
                Console.WriteLine("\n{0} units of {1} sold for a profit of {2:C}", sellQty, GetName(), profit);
                Console.WriteLine("Remaining QTY: {0}", GetQty());

            }
            else Console.WriteLine("\nInsufficent stock ");

        }








    }








    public class Inventory
    {
        private Dictionary<string, Inventoryitem> inventory = new Dictionary<string, Inventoryitem>();





        /* public Inventory(string[,,] inv)
         {
             foreach(string s in inv)
             {



             }

         }*/



        public virtual void PrintInventory()
        {
            foreach (var keypair in inventory)
            {
                Console.Write(string.Format("{0,-25}\t{1,-23:}\t{2,-10:C}\t{3,-1}\n", keypair.Key, keypair.Value.GetName(), keypair.Value.GetPrice(), keypair.Value.GetQty()));
                Thread.Sleep(350);

            }
            Console.WriteLine("\n(end of inventory)\n");
        }

        public virtual bool CheckInventory(string testKey)
        {
            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(testKey)) return true;

            }

            return false;
        }


        public Dictionary<string, Inventoryitem> GetInventory()
        {
            return inventory;
        }


        public virtual void AddItem(string item, double price, uint qty)
        {
            Inventoryitem newItem = new Inventoryitem();
            newItem.SetName(item);
            newItem.SetPrice(price);
            newItem.SetQty(qty);

            if (inventory.ContainsKey(item))
            {

                newItem.SetPrice(inventory[item].GetPrice());
                inventory.Remove(item);
                inventory.Add(item, newItem);

            }
            else inventory.Add(newItem.GetName(), newItem);


        }

        public virtual void UpdatePrice(string item, double price)
        {

            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(item))    //could also be keypair.Key.Equals(item) 
                {
                    keypair.Value.SetPrice(price);
                    return;
                }

            }

        }





        public virtual void UpdateQty(string item, uint qty)
        {
            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(item))
                {
                    // if (qty == 0) inventory.Remove(keypair.Key);                 //remove item in case of 0 stock
                    /*else*/
                    keypair.Value.SetQty(qty);
                    return;
                }

            }

        }


        public virtual void RemoveItem(string item)
        {
            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(item))
                {
                    inventory.Remove(keypair.Key);
                }

            }

        }

        public bool SellItem(string item, uint sellQty, out double profit)
        {

            uint stockQty;
            profit = 0;

            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(item))
                {
                    if (sellQty <= keypair.Value.GetQty())
                    {
                        stockQty = keypair.Value.GetQty();
                        keypair.Value.SetQty(stockQty - sellQty);
                        profit = sellQty * keypair.Value.GetPrice();
                        Console.WriteLine("\n{0} units of {1} sold for a profit of {2:C}", sellQty, keypair.Value.GetName(), profit);
                        Console.WriteLine("Remaining QTY: {0}", keypair.Value.GetQty());
                        return true;

                    }
                    else Console.WriteLine("\nInsufficent stock ");
                    return false;
                }


            }

            Console.WriteLine("\n item not found ");

            return false;

        }




        /* public void sellItem(Dictionary<string,uint>invoice, out double profit)   //bulk sell 
         {
             double profit = 0;



         }*/



    }

    public class Menu : Inventory                                                                         //for lab 3_3
    {
        private Dictionary<string, MenuItem> inventory = new Dictionary<string, MenuItem>();



        public override void PrintInventory()
        {
            foreach (var keypair in inventory)
            {
                Console.Write(string.Format("{0,-25}\t{1,-23:}\t{2,-10:C}\t{3,-1}\n", keypair.Key, keypair.Value.GetName(), keypair.Value.GetPrice(), keypair.Value.GetQty()));
                Thread.Sleep(350);

            }
            Console.WriteLine("\n(end of inventory)\n");
        }

        public override bool CheckInventory(string testKey)
        {
            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(testKey)) return true;

            }

            return false;
        }





        public override void AddItem(string item, double price, uint qty)
        {
            MenuItem newItem = new MenuItem();
            newItem.SetName(item);
            newItem.SetPrice(price);
            newItem.SetQty(qty);

            if (inventory.ContainsKey(item))
            {

                newItem.SetPrice(inventory[item].GetPrice());
                inventory.Remove(item);
                inventory.Add(item, newItem);

            }
            else inventory.Add(newItem.GetName(), newItem);


        }

        public override void UpdatePrice(string item, double price)
        {

            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(item))    //could also be keypair.Key.Equals(item) 
                {
                    keypair.Value.SetPrice(price);
                    return;
                }

            }

        }





        public override void UpdateQty(string item, uint qty)
        {
            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(item))
                {
                    // if (qty == 0) inventory.Remove(keypair.Key);                 //remove item in case of 0 stock
                    /*else*/
                    keypair.Value.SetQty(qty);
                    return;
                }

            }

        }


        public override void RemoveItem(string item)
        {
            foreach (var keypair in inventory)
            {
                if (keypair.Value.GetName().Equals(item))
                {
                    inventory.Remove(keypair.Key);
                }

            }

        }

        public Dictionary<string, MenuItem> GetMenu()
        {
            return inventory;
        }

















    }







    public class Cart : Inventory
    {
        private Dictionary<string, uint> cart = new Dictionary<string, uint>();





        public void AddItem(string name, uint qty)
        {
            if (cart.ContainsKey(name)) UpdateQty(name, qty);
            else cart.Add(name, qty);
        }

        public double CalcValue(Inventory inv)
        {
            double value = 0;

            foreach (var keypair in inv.GetInventory())                       //for each item in inventory..
            {
                foreach (var cartPair in cart)
                {
                    if (cartPair.Key.Equals(keypair.Value.GetName()))
                    {
                        value += keypair.Value.GetPrice() * cartPair.Value;  //calc the value of the # of that item in the cart
                    }
                }

            }


            return value;
        }


        public override void UpdateQty(string item, uint newQty)
        {
            if (newQty == 0) RemoveItem(item);
            else if (cart.ContainsKey(item))
            {
                cart.Remove(item);
                cart.Add(item, newQty);

            }

        }

        public override void RemoveItem(string item)
        {
            if (cart.ContainsKey(item)) cart.Remove(item);
        }




    }


    class Program
    {



        static void printList(Inventory inv)
        {
            Console.Write("\n");
            inv.PrintInventory();
        }

        static void printList(Menu inv)
        {
            Console.Write("\n");
            inv.PrintInventory();
        }


        static void printList(Dictionary<char, string> list)
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



        static void modList(Inventory inv, char function)
        {
            string usrInp1, usrInp2, usrInp3;
            bool invalidInp = true;
            bool skipToQTY = false;
            double usrInp4 = 0;
            int usrInp5 = 0;
            char f = char.ToUpper(function);


            Console.Write("\n");

            switch (f)
            {

                case 'A':
                    {
                        Console.WriteLine("Please enter the name of the item you wish to add its price, and the available quantity\n(Type 'CANCEL' or '\\c' to return to main menu)");
                        do
                        {

                            Console.Write("\nNAME >\t");
                            usrInp1 = Console.ReadLine();

                            if (usrInp1.ToUpper() == "CANCEL" || usrInp1.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp1)) invalidInp = true;
                            else if (inv.CheckInventory(usrInp1))                                                                                               // if item already exists, ask if qty needs to be updated
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem already exists!");
                                do
                                {
                                    Console.Write("\nUpdate QTY? (y/n) >\t");
                                    usrInp3 = Console.ReadLine();
                                }
                                while (string.IsNullOrEmpty(usrInp3) || usrInp3.Length > 1 || (!usrInp3.ToLower().Equals("y") && !usrInp3.ToLower().Equals("n")));

                                if (usrInp3.ToLower().Equals("y"))
                                {
                                    skipToQTY = true;
                                    break;
                                }

                            }
                            else invalidInp = false;

                        }
                        while (invalidInp);

                        do
                        {
                            if (skipToQTY) break;

                            Console.Write("\n$>\t");
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
                                usrInp4 = price;
                            }
                        }
                        while (invalidInp);


                        do
                        {
                            Console.Write("\nQTY>\t");
                            usrInp3 = Console.ReadLine();

                            if (usrInp3.ToUpper() == "CANCEL" || usrInp3.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp3) || !int.TryParse(usrInp3, out int qty) || qty < 0)                       //can have 0 stock 
                            {
                                invalidInp = true;
                                Console.WriteLine("\nQTY is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp5 = qty;
                            }
                        }
                        while (invalidInp);

                        inv.AddItem(usrInp1, usrInp4, (uint)usrInp5);
                        if (skipToQTY) Console.WriteLine($"\n{usrInp1} updated to {usrInp5} units");                                      //if updating an existing qty
                        else
                        {
                            Console.Write("\nnew item added successfully!");
                            Console.WriteLine(string.Format("({0} x {1} @ {2:C})\n", usrInp5, usrInp1, usrInp3));

                        }

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
                            else if (!inv.CheckInventory(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem does not exist!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        do
                        {
                            Console.Write("\n$>\t");
                            usrInp2 = Console.ReadLine();

                            if (usrInp2.ToUpper() == "CANCEL" || usrInp2.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp2) || !double.TryParse(usrInp2, out double price) || price <= 0)
                            {
                                invalidInp = true;
                                Console.WriteLine("\nprice is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp4 = price;
                            }
                        }
                        while (invalidInp);

                        inv.UpdatePrice(usrInp1, usrInp4);


                        Console.WriteLine($"\nprice updated successfully!");
                        Console.WriteLine(string.Format("{0} -> {1:C}", usrInp1, usrInp4));

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
                            else if (!inv.CheckInventory(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem not found!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        inv.RemoveItem(usrInp1);
                        Console.WriteLine($"\nitem {usrInp1} removed successfully");

                        break;





                    }

                case 'S':
                    {
                        Console.WriteLine("Please enter the name and quantity of the item you wish to sell\n(Type 'CANCEL' or '\\c' to return to main menu)");
                        do
                        {

                            Console.Write("\nITEM >\t");
                            usrInp1 = Console.ReadLine();

                            if (usrInp1.ToUpper() == "CANCEL" || usrInp1.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp1)) invalidInp = true;
                            else if (!inv.CheckInventory(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem does not exist!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        do
                        {
                            Console.Write("\nQTY>\t");
                            usrInp2 = Console.ReadLine();

                            if (usrInp2.ToUpper() == "CANCEL" || usrInp2.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp2) || !int.TryParse(usrInp2, out int qty) || qty < 1)
                            {
                                invalidInp = true;
                                Console.WriteLine("\nQTY is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp5 = qty;
                            }
                        } while (invalidInp);

                        inv.SellItem(usrInp1, (uint)usrInp5, out double p);








                        break;

                    }



            }

            return;

        }


        static void modList(Menu inv, char function)                                                        //overload for Lab 3_3
        {
            string usrInp1, usrInp2, usrInp3;
            bool invalidInp = true;
            bool skipToQTY = false;
            double usrInp4 = 0;
            int usrInp5 = 0;
            char f = char.ToUpper(function);


            Console.Write("\n");

            switch (f)
            {

                case 'A':
                    {
                        Console.WriteLine("Please enter the name of the item you wish to add its price, and the available quantity\n(Type 'CANCEL' or '\\c' to return to main menu)");
                        do
                        {

                            Console.Write("\nNAME >\t");
                            usrInp1 = Console.ReadLine();

                            if (usrInp1.ToUpper() == "CANCEL" || usrInp1.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp1)) invalidInp = true;
                            else if (inv.CheckInventory(usrInp1))                                                                                               // if item already exists, ask if qty needs to be updated
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem already exists!");
                                do
                                {
                                    Console.Write("\nUpdate QTY? (y/n) >\t");
                                    usrInp3 = Console.ReadLine();
                                }
                                while (string.IsNullOrEmpty(usrInp3) || usrInp3.Length > 1 || (!usrInp3.ToLower().Equals("y") && !usrInp3.ToLower().Equals("n")));

                                if (usrInp3.ToLower().Equals("y"))
                                {
                                    skipToQTY = true;
                                    break;
                                }

                            }
                            else invalidInp = false;

                        }
                        while (invalidInp);

                        do
                        {
                            if (skipToQTY) break;

                            Console.Write("\n$>\t");
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
                                usrInp4 = price;
                            }
                        }
                        while (invalidInp);


                        do
                        {
                            Console.Write("\nQTY>\t");
                            usrInp3 = Console.ReadLine();

                            if (usrInp3.ToUpper() == "CANCEL" || usrInp3.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp3) || !int.TryParse(usrInp3, out int qty) || qty < 0)                       //can have 0 stock 
                            {
                                invalidInp = true;
                                Console.WriteLine("\nQTY is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp5 = qty;
                            }
                        }
                        while (invalidInp);

                        inv.AddItem(usrInp1, usrInp4, (uint)usrInp5);
                        if (skipToQTY) Console.WriteLine($"\n{usrInp1} updated to {usrInp5} units");                                      //if updating an existing qty
                        else
                        {
                            Console.Write("\nnew item added successfully!");
                            Console.WriteLine(string.Format("({0} x {1} @ {2:C})\n", usrInp5, usrInp1, usrInp3));

                        }

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
                            else if (!inv.CheckInventory(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem does not exist!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        do
                        {
                            Console.Write("\n$>\t");
                            usrInp2 = Console.ReadLine();

                            if (usrInp2.ToUpper() == "CANCEL" || usrInp2.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp2) || !double.TryParse(usrInp2, out double price) || price <= 0)
                            {
                                invalidInp = true;
                                Console.WriteLine("\nprice is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp4 = price;
                            }
                        }
                        while (invalidInp);

                        inv.UpdatePrice(usrInp1, usrInp4);


                        Console.WriteLine($"\nprice updated successfully!");
                        Console.WriteLine(string.Format("{0} -> {1:C}", usrInp1, usrInp4));

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
                            else if (!inv.CheckInventory(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem not found!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        inv.RemoveItem(usrInp1);
                        Console.WriteLine($"\nitem {usrInp1} removed successfully");

                        break;





                    }

                case 'S':
                    {
                        Console.WriteLine("Please enter the name and quantity of the item you wish to sell\n(Type 'CANCEL' or '\\c' to return to main menu)");
                        do
                        {

                            Console.Write("\nITEM >\t");
                            usrInp1 = Console.ReadLine();

                            if (usrInp1.ToUpper() == "CANCEL" || usrInp1.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp1)) invalidInp = true;
                            else if (!inv.CheckInventory(usrInp1))
                            {
                                invalidInp = true;
                                Console.WriteLine("\nitem does not exist!");
                            }
                            else invalidInp = false;
                        }
                        while (invalidInp);

                        do
                        {
                            Console.Write("\nQTY>\t");
                            usrInp2 = Console.ReadLine();

                            if (usrInp2.ToUpper() == "CANCEL" || usrInp2.ToLower() == "\\c") return;
                            else if (String.IsNullOrEmpty(usrInp2) || !int.TryParse(usrInp2, out int qty) || qty < 1)
                            {
                                invalidInp = true;
                                Console.WriteLine("\nQTY is invalid!");
                            }
                            else
                            {
                                invalidInp = false;
                                usrInp5 = qty;
                            }
                        } while (invalidInp);

                        inv.GetMenu()[usrInp1].Sell(usrInp5);







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
            functionList.Add('S', "SELL ITEM");



            Menu menu = new Menu();

            menu.AddItem("Turkey Sammich (Rye)", 7.00, 100);
            menu.AddItem("Ham Sammich (White)", 6.00, 100);
            menu.AddItem("Chicken Shwarma", 9.00, 100);
            menu.AddItem("Fries", 2.50, 100);
            menu.AddItem("Fries (sweet potato)", 3.00, 100);
            menu.AddItem("Reuben Sammich", 8.00, 100);

            string version = "0.22"; // 0.05 removed unneded menu validation function, implemented full functionality
                                     // 0.07 removed typos in output formatting, removed case sensitivity for functions
                                     // 0.15 revised base code for use with objects
                                     // 0.20 updated code per lab 3_3 revised specs
                                     // 0.22 added overrides for lab 3_3 spec object compatibility; full functionality 


            string usrInp;



            Console.WriteLine($"////////////////////////////////////////////////// EasyMenu ver {version} ////////////////////////////////////////////////// ");


            while (true) //home menu
            {

                printList(menu);

                do
                {
                    Console.Write("\nPlease select a function to continue ('L' to list all fuctions or 'Q' to quit) >\t");

                    usrInp = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(usrInp) && usrInp.Trim().ToUpper() == "Q") return;
                    else if (!String.IsNullOrWhiteSpace(usrInp) && usrInp.Trim().ToUpper() == "L") printList(functionList);

                }
                while (!valInp(functionList, usrInp));

                modList(menu, usrInp[0]);



            }





        }
    }
}