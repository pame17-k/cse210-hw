using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        //Customer in USA
        Address addr1 = new Address("234 Main St", "Atlanta", "GA", "USA");
        Customer cust1 = new Customer("Alice Burton", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Shoes", "P001", 1000, 1));
        order1.AddProduct(new Product("Laptop", "P002", 1800, 2));

        //Customer outside
        Address addr2 = new Address("Alianza 108", "Oaxaca", "OAX", "Mexico");
        Customer cust2 = new Customer("Jose Hernandez", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Camera", "P010", 500, 1));
        order2.AddProduct(new Product("TV", "P011", 1300, 1));
        order2.AddProduct(new Product("Backpack", "P012", 130, 1));

        //Results
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());
    }
}

