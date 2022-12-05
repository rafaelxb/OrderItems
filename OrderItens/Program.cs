using OrderItens.Entities;
using OrderItens.Entities.Enums;

string name, email;
DateOnly date;
OrderStatus status;
int quantityItems;

Console.WriteLine("Enter client data:");

Console.Write("Name: ");
name = Console.ReadLine();
Console.Write("");

Console.Write("Email: ");
email = Console.ReadLine();
Console.Write("");

Console.Write("Birth date (DD/MM/YYYY): ");
date = DateOnly.Parse(Console.ReadLine());
Console.Write("");

Client client = new Client(name,email,date);

Console.WriteLine("Enter order data:");
Console.Write("Status: ");
status = Enum.Parse<OrderStatus>(Console.ReadLine());
Console.Write("");

DateTime now = DateTime.Now;

Order order = new Order(now,status,client);

Console.Write("How many items to this order? ");
quantityItems = int.Parse(Console.ReadLine());

for(int i = 0; i < quantityItems; i++)
{
    Console.WriteLine($"Enter #{i +1} item data:");
    Console.Write("Product Name: ");
    string productName = Console.ReadLine();
    Console.Write("");
    Console.Write("Product price: ");
    double productPrice = double.Parse(Console.ReadLine());
    Console.Write("");
    Console.Write("Quantity: ");
    int productQuantity = int.Parse(Console.ReadLine());
    Console.Write("");

    Product product = new Product(productName,productPrice);

    OrderItem orderItem = new OrderItem(productQuantity,productPrice,product);

    order.AddItem(orderItem);
}

Console.WriteLine(order.ToString());

Console.WriteLine("-------------");

