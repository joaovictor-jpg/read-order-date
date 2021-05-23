using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Course.Entities.Enums;

namespace Course.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return  sum;
        }

        public override string ToString()
        {
            StringBuilder product = new StringBuilder();
            product.Append("Order moment: ");
            product.AppendLine(Moment.ToString("dd/mm/yyyy HH:mm:ss"));
            product.Append("Order status: ");
            product.AppendLine(Convert.ToString(Status));
            product.Append("Client: ");
            product.Append(Client.Name);
            product.Append(" ");
            product.Append(Client.Date.ToString("dd/mm/yyyy"));
            product.Append(" - ");
            product.Append(Client.Email);
            product.AppendLine("\nOrder items: ");
            foreach (OrderItem item in Items)
            {
                product.Append(item.Product.Name);
                product.Append(", $");
                product.Append(item.Price.ToString("F2", CultureInfo.InvariantCulture));
                product.Append(", ");
                product.Append("Quantity: ");
                product.Append(item.Quantity);
                product.Append(", ");
                product.Append("Subtotal: $");
                product.AppendLine(item.SubTotal().ToString("F2",CultureInfo.InvariantCulture));
            }
            product.Append("Total price: $");
            product.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            return product.ToString();
        }
    }
}
