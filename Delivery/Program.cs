using System.ComponentModel;
using System.Net.Http.Headers;
using System.Security.Principal;

namespace Delivery
{
    public class OutOfStockException : Exception
    {
        public override string Message => "Product is out of stock";
    }
    public class Product
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
    }
    public class DeliverSerives
    {
        public bool PlacedOrder(Product product)
        {

            if (product.Stock>0)
            {
                return true;
            }
            else
            {
                throw new OutOfStockException();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DeliverSerives deliverSerives = new DeliverSerives();
            try
            {
                Console.WriteLine("enter the product name");
                string pname = Console.ReadLine();
                Console.WriteLine("enter the number of stock");
                int stock = int.Parse(Console.ReadLine());

                Product product = new Product()
                {
                    Name = pname,
                    Stock = stock

                };
                if (deliverSerives.PlacedOrder(product))
                {
                    Console.WriteLine("your order is suceesfull");
                }
            }
            catch(OutOfStockException ex) {
                Console.WriteLine(ex.Message);
            }
            finally{
                Console.WriteLine("order updated sucessfully");
            }
        }
    }
}
