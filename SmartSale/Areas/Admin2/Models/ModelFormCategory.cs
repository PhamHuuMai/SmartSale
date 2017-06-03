using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartSale.Models;

namespace SmartSale.Areas.Admin2.Models
{
    public class ModelFormCategory
    {
        private SmartSale.Models.Category _cat;
        private IQueryable<SmartSale.Models.Category> _listCat;

        public Category Cat
        {
            get
            {
                return _cat;
            }

            set
            {
                _cat = value;
            }
        }

        public IQueryable<Category> ListCat
        {
            get
            {
                return _listCat;
            }

            set
            {
                _listCat = value;
            }
        }
        public ModelFormCategory(Category cat,IQueryable<Category> listCat)
        {
            _listCat = listCat;
            _cat = cat;
        } 
    }
}