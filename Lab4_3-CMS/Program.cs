using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab4_3_CMS
{


    class Customer
    {

        private string Company;
        private string ContactName;
        private string ContactEmail;
        private string Phone;

/*-------------------------------------------------------------------------- */

        public Customer(string Name, string Company, string Email, string PhoneNum)
        {
            this.Company = Company;
            ContactName = Name;
            ContactEmail = Email;
            Phone = PhoneNum;
        }


/*-------------------------------------------------------------------------- */


        public string GetCompany() => Company;

        public string GetName() => ContactName;

        public string GetEmail() => ContactEmail;

        public string GetPhone() => Phone;

/*-------------------------------------------------------------------------- */

        public void SetCompany(string Company) => this.Company = Company;

        public void SetName(string Name) => ContactName = Name;

        public void SetEmail(string Email) => ContactEmail = Email;

        public void SetPhone(string PhoneNumber) => Phone = PhoneNumber;

        /*-------------------------------------------------------------------------- */

        public static bool FindCustomer(List<Customer> customers, string company, out string client)
        {
            client = null;
            List<string> searchMatch = new List<string>();

            if (customers == null || string.IsNullOrWhiteSpace(company)) return false;
            
            foreach(Customer customer in customers)
            {
                if(customer.GetCompany() == company)
                {
                    searchMatch.Add(customer.ToString());
                }
            }

            if (searchMatch.Count == 0) return false;
            else
            {
                foreach(string s in searchMatch)
                {
                    client = client + "\n" + s + "\n";
                }

                return true;
            }
                

            
           
        }

        public static void FindCustomer(List<Customer> customers)  //allows user to search for any of the fields
        {

            

        }

        public static void ListCustomers(List<Customer> customers)
        {
            foreach (Customer c in customers) 
            {
                Console.WriteLine($"\n{c}");
                Thread.Sleep(550);

            }

            Console.WriteLine("(end of list)\n");
        }


        public override string ToString()
        {
            return String.Format(" NAME: {0}\n COMPANY: {1}\n - CONTACT INFO - \n > {2}\n >{3}", ContactName, Company, ContactEmail, Phone);
        }


    }




    class Program
    {
        static void Main(string[] args)
        {


            string[] Names = { "John Doe", "Jane Doe", "Jay Doe", "Jenny Doe", "Jim Doe", "Jean Doe", "J. Doe" };
            string[] Companies = { "QL", "Rocket Mortgage", "Quicken Loans", "Rock Central", "Quicken", "Bedrock", "Team Rocket" };
            string[] emailAddrs = { "somename@QL.com", "name@domain.com", "abc123@something.com", "def456@somewhere.com", "a_person@rocketmortgage.com", "example@test.com", "N/A" };
            string[] PhoneNums = { "(123)-456-7890", "1234567890", "+1(333)4567", "(xxx)8675309", "(xxx)xxx-xxx", "N/A", "1112223333" };

            int testObj = Names.Length;

            Random r = new Random();
            List<Customer> clients = new List<Customer>();



            Console.WriteLine("Generating test objects..");

            for (int i = 0; i < testObj; i++)
            {

                clients.Add(new Customer(Names[r.Next(testObj)], Companies[r.Next(testObj)], emailAddrs[r.Next(testObj)], PhoneNums[r.Next(testObj)]));

            }

            Thread.Sleep(2500);

            Console.WriteLine("Objects generated!\n");
            Thread.Sleep(1000);
            Console.WriteLine("Listing objects..\n");
            Thread.Sleep(1000);


            /*foreach (Customer c in clients)
              {
                  Console.WriteLine($"{c}\n");
                  Thread.Sleep(550);

              }*/

            Customer.ListCustomers(clients);
            

            Console.WriteLine("Testing Setters..\n");
            Thread.Sleep(1000);

            foreach (Customer c in clients)
            {
                if (clients.IndexOf(c) % 2 == 0)
                {
                    c.SetCompany("COMPANY SET");
                    c.SetEmail("EMAIL SET");
                }
                else
                {
                    c.SetName("NAME SET");
                    c.SetPhone("PHONE SET");
                   
                }

               

                Console.WriteLine($"{c}\n");

                Thread.Sleep(550);

            }

            Console.WriteLine("Testing Getters..\n");
            Thread.Sleep(1500);

            foreach (Customer c in clients)
            {

                Console.WriteLine("\nNAME: {0}", c.GetName());
                Console.WriteLine("COMPANY: {0}", c.GetCompany());
                Thread.Sleep(250);
                Console.WriteLine("EMAIL: {0}", c.GetEmail());
                Thread.Sleep(250);
                Console.WriteLine("PHONE#: {0}\n", c.GetPhone());


                Thread.Sleep(350);

            }

            Console.WriteLine("Testing FindCustomers()");
          //string testCompany = Companies[r.Next(testObj)];
            string testCompany ="COMPANY SET";
            Console.WriteLine("( searching for customers at company {0}..\n", testCompany );
            Thread.Sleep(1500);

            if (Customer.FindCustomer(clients, testCompany, out string matches)) Console.WriteLine(matches);
            else Console.WriteLine("\n(No Matches for company {0} found)", testCompany);




            Console.WriteLine("\nTesting completed!");
            Console.ReadLine();






        }
    }
}
