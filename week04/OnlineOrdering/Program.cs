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

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return street + "\n" + city + ", " + state + "\n" + country;
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingInfo()
    {
        return name + "(ID: " + productId + ")";
    }
}

class Order
{
    private Customer customer;
    private List<Product> products = new List<Product>();

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach(var p in products)
        {
            total += p.GetTotalCost();
        }

        if(customer.LivesInUSA())
        {
            total += 5; //Shipping cost inside
        }
        else
        {
            total += 35; //Shipping cost outside
        }
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var p in products)
        {
            label += p.GetPackingInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + customer.GetName() + "\n" + customer.GetAddress();
    }
}
