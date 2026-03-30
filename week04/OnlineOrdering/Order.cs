class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach(var p in _products)
        {
            total += p.GetTotalCost();
        }

        if(_customer.LivesInUSA())
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
        foreach (var p in _products)
        {
            label += p.GetPackingInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetName() + "\n" + _customer.GetAddress();
    }
}
