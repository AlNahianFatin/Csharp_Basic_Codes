// C# Program to illustrate calling various constructors

using System;

namespace ConstructorExample
{

    class Geek
    {

        int num, id;
        string name;

        // this would be invoked while the
        // object of that class created.
        Geek()
        {
            Console.WriteLine("\nDefault Constructor Automatically Called While Creating Instance");
        }

        // parameterized constructor would
        // initialized data members with
        // the values of passed arguments
        // while object of that class created.
        Geek(String name, int id)
        {
            Console.WriteLine("\nParameterized Constructor Called");
            this.name = name;
            this.id = id;
        }

        private string month;
        private string year;

        // declaring Copy constructor
        public Geek(Geek s)
        {
            Console.WriteLine("\nCopy Constructor Called");
            month = s.month;
            year = s.year;
        }

        // Instance constructor
        public Geek(string month, string year)
        {
            this.month = month;
            this.year = year;
        }

        // Get details of Geek
        public string Details
        {
            get
            {
                return "Month: " + month + "\nYear: " + year.ToString();
            }
        }

        // declare private Constructor
        //use private constructor when we have only static members.
        //private Geek()
        //{
        //}

        // declare static variable field
        public static int count_geeks;

        // declare static method
        public static int geeks_Count()
        {
            return ++count_geeks;
        }


        // It is invoked before the first
        // instance constructor is run.
        static Geek()
        {

            // The following statement produces
            // the first line of output,
            // and the line occurs only once.
            Console.WriteLine("Static Constructor Executed Automatically, Even Before Creating Instance");
        }

        // Instance constructor.
        public Geek(int i)
        {
            Console.WriteLine("Instance Constructor " + i);
        }

        // Instance method.
        public string geeks_detail(string name, int id)
        {
            return "Name:" + name + " id:" + id;
        }


        // Main Method
        public static void Main()
        {
            // this would invoke default
            // constructor.
            Geek geek1 = new Geek();
            // Default constructor provides
            // the default values to the
            // int and object as 0, null
            // Note:
            // It Give Warning because
            // Fields are not assign
            Console.WriteLine(geek1.name);
            Console.WriteLine(geek1.num);


            // This will invoke parameterized
            // constructor.
            Geek geek2 = new Geek("GFG", 2);
            Console.WriteLine("GeekName = " + geek2.name + " and GeekId = " + geek2.id);


            // Create a new Geeks object.
            Geek g1 = new Geek("June", "2018");
            // here g1 details gets copied to g2.
            Geek g2 = new Geek(g1);
            Console.WriteLine(g2.Details);


            // If you uncomment the following
            // statement, it will generate
            // an error because the constructor
            // is unaccessible:
            Geek s = new Geek(); // Error
            Geek.count_geeks = 99;
            // Accessing without any
            // instance of the class
            Geek.geeks_Count();
            Console.WriteLine(Geek.count_geeks);
            // Accessing without any
            // instance of the class
            Geek.geeks_Count();
            Console.WriteLine(Geek.count_geeks);


            // Here Both Static and instance
            // constructors are invoked for
            // first instance
            Geek obj = new Geek(1);
            Console.WriteLine(obj.geeks_detail("GFG", 1));
            // Here only instance constructor
            // will be invoked
            Geek obj1 = new Geek(2);
            Console.WriteLine(obj1.geeks_detail("GeeksforGeeks", 2));

            Console.ReadKey();
        }
    }
}
