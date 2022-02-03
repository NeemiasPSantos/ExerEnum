﻿using System;
using ExerFixEnums.Entities;
using System.Globalization;

namespace ExerFixEnums.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }



        public OrderItem()
        {

        }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal() 
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return Product 
                + ", " 
                + Price.ToString("F2", CultureInfo.InvariantCulture) 
                + ", Quantity: " 
                + Quantity
                + "Subtotal: $ "
                + SubTotal();
        }
    }
}
