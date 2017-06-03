using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartSale.Models.BaseModels;

namespace SmartSale.Models.TransportModels
{
    public class TransportIndex
    {
        private Product _specialProduct;
        private IEnumerable<Product> _listProduct;
        private IEnumerable<String> _tag;

        public TransportIndex()
        {
            //_listProduct = (new ProductModel()).SelectProduct(2);
        }

        public Product SpecialProduct
        {
            get
            {
                return _specialProduct;
            }

            set
            {
                _specialProduct = value;
            }
        }

        public IEnumerable<Product> ListProduct
        {
            get
            {
                return _listProduct;
            }

            set
            {
                _listProduct = value;
            }
        }

        public IEnumerable<string> Tag
        {
            get
            {
                return _tag;
            }

            set
            {
                _tag = value;
            }
        }
    }
}