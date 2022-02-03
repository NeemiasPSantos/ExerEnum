using System;
using ExerFixEnums.Entities;
using ExerFixEnums.Entities.Enums;
using System.Globalization;

namespace ExerFixEnums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime bDate = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            DateTime OrDat = DateTime.Now;

            Client c1 = new Client(name, email, bDate);
            Order o1 = new Order(OrDat,status, c1);
            OrderItem order;

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) 
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameP = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product p1 = new Product(nameP,price);
                order = new OrderItem(quantity,price, p1);

                order.SubTotal();

                o1.AddItem(order);
            }

            Console.WriteLine();
            Console.WriteLine(o1);

        }
    }
}
