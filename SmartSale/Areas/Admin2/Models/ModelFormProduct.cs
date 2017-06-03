using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartSale.Models;
namespace SmartSale.Areas.Admin2.Models
{
    public class ModelFormProduct
    {
        private Product product;
        private IEnumerable<Brand> brand;
        private IEnumerable<Category> category;

        public Product Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
            }
        }

        public IEnumerable<Brand> Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
            }
        }

        public IEnumerable<Category> Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

    }
}