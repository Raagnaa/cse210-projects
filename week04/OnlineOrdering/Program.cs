using System;

class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("2345 Fresnos Ave", "Brownsville", "TX", "USA");
        Customer customer1 = new Customer("Emmanuel Garcia", address1);

        Product product1 = new Product("Mouse Pad", "MOUSEP", 40, 1);
        Product product2 = new Product("Desk", "DESK", 240, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine();

        Address address2 = new Address("3 Fransisco Rincon", "Matamoros", "Tamaulipas", "Mexico");
        Customer customer2 = new Customer("Fernando Garcia", address1);

        Product product3 = new Product("Boat", "BOAT", 42220, 1);
        Product product4 = new Product("Sword", "SWORD", 280, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}