using System;

namespace Lab4_1_1_ClassObjPrac
{

    public class Parallelogram
    {
        private double length;
        private double width;

        public Parallelogram()
        {

        }

        public Parallelogram(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double GetArea()
        {
            return length * width;

        }

        public double GetPerimeter()
        {
            return (length * 2) + (width * 2);

        }

        public void Print()
        {
            Console.WriteLine("\nLength: {0}\nWidth (Height): {1}\nArea: ({0} x {1}) = {2} sqUnits \nPerimeter: (2x{0} + 2x{1}) = {3}", width, length, GetArea(), GetPerimeter());

        }

        public void Resize(double new_L, double new_W)
        {
            if (new_L <= 0 || new_W <= 0)
            {
                Console.WriteLine("\nError: values cannot be zero or negative");
                return;

            }
            else
            {
                length = new_L;
                width = new_W;

            }


        }
    }


    public class Book
    {
        private string title;
        private string a_FirstName;
        private string a_LastName;
        private string ID;
        private string publisher;
        private int numSold;

        public Book()
        {

        }

        public Book(string title, string a_FirstName, string a_LastName, string ID, string PubName, int numSold)
        {
            this.title = title;
            this.a_FirstName = a_FirstName;
            this.a_LastName = a_LastName;
            this.ID = ID;
            publisher = PubName;
            this.numSold = numSold;

        }

        public void Sell(int newSales)
        {
            if (newSales > 0) numSold += newSales;

        }

        public void Print()
        {
            Console.WriteLine("\n TITLE: {0}\n AUTHOR: {1}\n ID: {2}\n PUBLISHER: {3}\n # COPIES SOLD: {4}", title, a_FirstName + " " + a_LastName, ID, publisher, numSold);
        }


    }



    class Program
    {
        static void Main(string[] args)
        {
            Parallelogram newShape = new Parallelogram(34, 60);

            newShape.Print();


            Book book1 = new Book("NewTitle", "John", "Doe", "0000000000xABCD456", "Cooked Books, INC", 220400);
            Book book2 = new Book("NewTitle Part II", "John", "Doe", "0000000000xABCD456", "Cooked Books, INC", 300000);
            Book book3 = new Book("NewTitle Part III", "John", "Doe", "0000000000xABCD456", "Cooked Books, INC", 350000);
            Book book4 = new Book("OldTitle", "Jane", "Doe", "0000000000xABCD456", "Cooks Books, INC", 750000);

            book1.Sell(25000);
            book1.Print();

            book2.Sell(25000);
            book2.Print();

            book3.Sell(25000);
            book3.Print();

            book4.Sell(25000);
            book4.Print();






        }
    }
}
