using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Clothing
{
    public class BabyDress
    {
        public int Size { set; get; }
        public string? Color { get; set; }
        public string? Brand { get; set; }
        public double Price { get; set; }
    }
    public class BabyUtlity
    {
        public static void AddDressToCart(BabyDress dress)
        {
            Program.babyDresses.Add(dress);

        }
        public bool RemoveDressFromCart(string brand)
        {
            return Program.babyDresses.RemoveAll(dress => dress.Brand == brand) > 0;

        }
        public static double CalculateTotalPrice()
        {
            return Program.babyDresses.Sum(dress => dress.Price);
        }
    }

    public class Program
    {
        public static List<BabyDress> babyDresses = new List<BabyDress>();
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1. Add dress to cart");
                Console.WriteLine("2. Remove dress to cart");
                Console.WriteLine("3. Exit");
                Console.WriteLine("enter your choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("enter the dress size");
                        int size = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the dress color");
                        string color = Console.ReadLine();
                        Console.WriteLine("enter the dress brand");
                        string brand = Console.ReadLine();
                        Console.WriteLine("enter the dress price");
                        double price = double.Parse(Console.ReadLine());
                        BabyDress babyDress = new BabyDress
                        {
                            Size = size,
                            Price = price,
                            Brand = brand,
                            Color = color
                        };
                        BabyUtlity.AddDressToCart(babyDress);
                        Console.WriteLine("Successfully added to the cart");
                        break;
                    case 2:
                        Console.WriteLine("enter the dress brand name to remove from the cart");
                        string brandname = Console.ReadLine();
                        Console.WriteLine( "removed sucesufully");
                        break;
                    case 3:
                        Console.WriteLine("Thank you");
                        return;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }
    }
}