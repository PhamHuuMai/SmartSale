using SmartSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSale.Areas.Admin2.Models
{
    public class Item
    {
        private int idProduct;
        private string nameProduct;
        private double price;
        private int amount;

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string NameProduct
        {
            get
            {
                return nameProduct;
            }

            set
            {
                nameProduct = value;
            }
        }

        public int IdProduct
        {
            get
            {
                return idProduct;
            }

            set
            {
                idProduct = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}