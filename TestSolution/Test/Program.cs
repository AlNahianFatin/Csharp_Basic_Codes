using System;

namespace Test
{
    public abstract class Shape
    {
        private string name;
        public Shape(string s) 
        {
            // calling the set accessor of the Id property.
            Id = s; 
        } 
        public string Id 
        { 
            get 
            { 
                return name; 
            } 
            set 
            { 
                name = value; 
            } 
        }

        // Area is a read-only property - only a get accessor is needed:
        public abstract double Area 
        { 
            get; 
        }
        public override string ToString() 
        { 
            return Id + " Area = " + string.Format("{0:F2}", Area); 
        }
    }

    public class Square : Shape
    {
        private int side;
        public Square(int side, string id) : base(id) 
        { 
            this.side = side; 
        }
        public override double Area
        {
            get
            { // Given the side, return the area of a square:
                return side * side; 
            } 
        } 
    } 
    
    public class Circle : Shape 
    { 
        private int radius;
        public Circle(int radius, string id) : base(id) 
        { 
            this.radius = radius; 
        }
        public override double Area
        {
            get
            { // Given the radius, return the area of a circle:
                return radius * radius * System.Math.PI; 
            } 
        } 
    }

    public class Rectangle : Shape
    {
        private int width; 
        private int height;
        public Rectangle(int width, int height, string id) : base(id) 
        { 
            this.width = width; 
            this.height = height; 
        }
        public override double Area
        {
        get
        { // Given the width and height, return the area of a rectangle:
            return width * height;
        } 
    } 

        static void Main(string[] args)
        {
            //int x = 32;
            //System.Console.WriteLine(x);

            //Int32 y = 55;
            //Console.WriteLine(y);

            //System.Int32 z = 11;
            //System.Console.WriteLine(z);



            Shape[] shapes =
            {
                new Square(5, "Square #1"),
                new Circle(3, "Circle #1"),
                new Rectangle( 4, 5, "Rectangle #1")
            };
            System.Console.WriteLine("Shapes Collection");
            foreach (Shape s in shapes)
            {
                System.Console.WriteLine(s);
            }

            System.Console.ReadKey();
        }
    }
}
