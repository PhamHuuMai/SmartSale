using System;
using System.Collections.Generic;
using System.Collections; 
using System.Linq;
using System.Web;
using SmartSale.Models.BaseModels;
namespace SmartSale.Models.TransportModels
{
    public class TransportSidebar
    {
        private Hashtable _categoryList;
        private IQueryable<Brand> _brandList;
        public TransportSidebar()
        {
            BrandModel brand = new BrandModel();
            CategoryModel cat = new CategoryModel();
            _brandList= brand.SelectListBrand();
            _categoryList = cat.SelectListCategory();
        }
        public Hashtable CategoryList
        {
            get
            {
                return _categoryList;
            }
        }

        public IQueryable<Brand> BrandList
        {
            get
            {
                return _brandList;
            }
        }
    }
}