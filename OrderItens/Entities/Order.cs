using OrderItens.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderItens.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Itens { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Itens.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Itens.Remove(item);
        }

        public double Total()
        {
            double Total = 0;
            foreach (OrderItem item in Itens)
            {
                Total += item.subTotal();
            }
            return Total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment);
            sb.AppendLine("Order status: " + Status.ToString());
            sb.AppendLine("Client: " + Client.Name + " (" + Client.Birthdate + ") - " + Client.Email);
            sb.AppendLine("Order items:");
            foreach(OrderItem item in Itens)
            {
                sb.AppendLine(item.Product.Name + ", " + item.Price.ToString("C") + ", Quantity: " + item.Quantity + ", " + item.subTotal().ToString("C"));
            }
            double total = Total();
            sb.AppendLine("Total price: " + total.ToString("C"));
            return sb.ToString();
        }
    }
}
