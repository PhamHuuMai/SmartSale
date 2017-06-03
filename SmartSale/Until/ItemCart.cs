using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSale.Until
{
    public class ItemCart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}