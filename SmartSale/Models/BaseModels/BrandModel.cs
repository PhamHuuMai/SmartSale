using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using SmartSale.Models;
namespace SmartSale.Models.BaseModels
{
    public class BrandModel
    {
        private EntityDataContext data;
        public BrandModel()
        {
            data = new EntityDataContext();
        }
        public IQueryable<Brand> SelectListBrand()
        {
            Table<Brand> brands = data.GetTable<Brand>();
            return from br in brands
                   where br.IsDeleted == 0
                   select br;
        }
        public Brand SelectBrand(int id)
        {
            Table<Brand> brands = data.GetTable<Brand>();
            return (from br in brands
                   where br.IsDeleted == 0 &&br.ID==id
                   select br).FirstOrDefault();
        }
        public void DeleteBrand(int id)
        {
            try
            {
                Table<Brand> brands = data.GetTable<Brand>();
                var br = (from b in brands
                          where b.ID == id
                          select b).FirstOrDefault();
                brands.DeleteOnSubmit(br);
                data.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
        public void InsertBrand(Brand brand)
        {
            try
            {
                Table<Brand> brands = data.GetTable<Brand>();
                brands.InsertOnSubmit(brand);
                data.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
        public void UpdateBrand(Brand brand)
        {
            try
            {
                Table<Brand> brands = data.GetTable<Brand>();
                Brand br = (from b in brands
                            where b.ID == brand.ID
                            select b).FirstOrDefault();
                br.BrandName = brand.BrandName;
                br.FromTo = brand.FromTo;
                data.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}