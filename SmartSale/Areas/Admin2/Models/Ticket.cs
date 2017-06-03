using SmartSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSale.Areas.Admin2.Models
{
    public class Ticket
    {
        private Bill bill;
        private List<Item> items;

        public Bill Bill
        {
            get
            {
                return bill;
            }

            set
            {
                bill = value;
            }
        }

        public List<Item> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }
    }
}