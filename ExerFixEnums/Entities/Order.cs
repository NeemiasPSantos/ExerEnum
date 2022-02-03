using System;
using System.Collections.Generic;
using ExerFixEnums.Entities.Enums;
using System.Text;
using System.Globalization;

namespace ExerFixEnums.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            this.client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveContract(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder os = new StringBuilder();

            os.AppendLine("ORDER SUMMARY: ");
            os.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyy HH:mm:ss"));
            os.AppendLine("Order Status: ");        
            os.AppendLine("Client: " + client);
            os.AppendLine("Order items: ");
            foreach (OrderItem item in Items) 
            {
                os.AppendLine(item.ToString());            
            }
            os.AppendLine("Total price: $"+ Total().ToString("F2", CultureInfo.InvariantCulture));
            return os.ToString();
        }
    }
}
