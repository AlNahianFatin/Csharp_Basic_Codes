using System;

namespace MyApp
{
    public class grandParent
    {
        public virtual void Test() //premits parent and other inherited classes to override
        {
            //this.Test(); //calling Test within same class will create infinite loop and will throw stack overflow runtime exception
            Console.WriteLine("Grandparent Test");
        }
    }
    public class parent : grandParent
    {
        internal static int a;
        public sealed override void Test() //Method Overriding - only override keyword lets parent and child both to override, and sealed keyword prevents child from overriding
        {
            base.Test(); //though the Test method is overriden, as this calls grandParent Test method, that will execute here
            Console.WriteLine("Parent Test"); //if this overriden method was not present, grandParent Test method would have executed from child class as there is multilevel inheritance from grandParent->parent->child
        }
    }
    public class child : parent
    {
        //public override void Test() //shows error as Test method has been sealed by parent class and can no longer be overriden
        //{
        //    base.Test();
        //    Console.WriteLine("Child Test");
        //}

        public new void Test() //Method Hiding/Shadowing - but using new keyword will hide parent/grandparent class method and allow the method to be accessed by child instance
        {
            base.Test();
            Console.WriteLine("Child Test");
        }
    }
    public class child2 : parent
    {

    }

    public class grandchild : child
    {
        static internal int x;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            const int m = 13;
            Console.WriteLine(m);

            int x1 = 6;

            child c = new child();
            parent p = c; //implicit type conversion but not with casting
            child c0 = (child)p; //explicit type conversion with casting
            Console.WriteLine(c.GetType());


            string s = x1.ToString(); //explicit conversion for reference types 

            child c1 = new child();
            parent p1 = c1;
            //child2 c2 = (child2) p1; //build succeeded but throws exception in run time because p1 is pointing to a child type instance, which can not be stored in child2
            //child2 c3 = (child) p1; //shows compile time error because conversion is not possible within siblings, only possible within parent-child or parent-child2 classes

            if (p1 is child2)
            {
                child2 c2 = (child2)p1;
                Console.WriteLine("p1 is child2");
            }
            else if (p1 is child)
            {
                child c2 = (child)p1;
                Console.WriteLine("p1 is child");
            }

            object o = "AIUB"; //will always need explicit type conversion as object is the ultimate base type in .NET Framework

            if (o is string)
            {
                string s1 = (string)o;
                Console.WriteLine("o is implicitly s1");
            }

            else
                Console.WriteLine("o is not string");

            object[] myObjects = new object[] { 10, 206, 30.50, "This is a string", "Don't forget the semicolons!" };

            for (int i = 0; i < myObjects.Length; i++)
            {
                Console.Write("for i = " + i + " ");
                string s4 = myObjects[i] as string;

                if (s4 == null)
                    Console.WriteLine("This is not my string data type");

                else
                    Console.WriteLine(s4);
            }

            int il, j = 1, k;
            for (il = 0; il < 5; il++)
            {
                k = j++ + ++j;
                Console.Write(k + " ");
            }

            int[,] arr = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

            //string name = null;
            //string name2 = "";

            //Console.WriteLine("Name: ");
            //name = Console.ReadLine();
            //name2 = Console.ReadLine();
            //Console.Write(name + " ");
            //Console.WriteLine(name2);

            grandchild.x = 5;
            Console.WriteLine(grandchild.x);
            Console.WriteLine(parent.a = 4);

            Console.WriteLine("\nExample of Method Overriding : ");
            parent p10 = new parent();
            p10.Test();

            Console.WriteLine("\nExample of Method Hiding/Shadowing : ");
            child c10 = new child();
            c10.Test();
        }
    }
}