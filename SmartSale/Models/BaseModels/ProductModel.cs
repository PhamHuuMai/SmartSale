using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartSale.Models;
using System.Collections;
using System.Data.Linq;
using SmartSale.Until;
namespace SmartSale.Models.BaseModels
{
    public class ProductModel
    {
        private EntityDataContext data;
        public ProductModel()
        {
            data = new EntityDataContext();
        }
        public IEnumerable<Product> SeachProduct(String key)
        {
            var pro= data.ExecuteQuery<Product>(@"select * from Product where ProductName like '%"+key+ "%' or Model like '%" + key + "%' or ID like '%" + key + "%' "); 
            return pro;
        }

        public IEnumerable<Product> SelectALLProduct(int iPage, ref int ss)
        {
            Table<Product> products = data.GetTable<Product>();
            var pro = from p in products
                      select p;
            int n = pro.Count();
            int numPage = (n % Static.recPerPage == 0) ? (n / Static.recPerPage) : (n / Static.recPerPage + 1);
            ss = numPage;
            if (iPage > numPage || iPage <= 0)
                return null;
            else
            {
                return pro.Skip((iPage - 1) * Static.recPerPage).Take(Static.recPerPage).AsEnumerable<Product>();
            }
        }
        public IEnumerable<Product> SelectALLProduct()
        {
            Table<Product> products = data.GetTable<Product>();
            var pro = from p in products
                      select p;
            return pro;
        }
        public IEnumerable<Product> SelectProductByCat(int iPage, ref int ss, int idCat)
        {
            Table<Product> products = data.GetTable<Product>();
            var pro = from p in products
                      where p.IDCategory == idCat
                      select p;
            int n = pro.Count();
            int numPage = (n % Static.recPerPage == 0) ? (n / Static.recPerPage) : (n / Static.recPerPage + 1);
            ss = numPage;
            if (iPage > numPage || iPage <= 0)
                return null;
            else
            {
                return pro.Skip((iPage - 1) * Static.recPerPage).Take(Static.recPerPage).AsEnumerable<Product>();
            }
        }
        public IEnumerable<Product> SelectProductByBrand(int iPage, ref int ss, int idBrand)
        {
            Table<Product> products = data.GetTable<Product>();
            var pro = from p in products
                      where p.IDBrand == idBrand
                      select p;
            int n = pro.Count();
            int numPage = (n % Static.recPerPage == 0) ? (n / Static.recPerPage) : (n / Static.recPerPage + 1);
            ss = numPage;
            if (iPage > numPage || iPage <= 0)
                return null;
            else
            {
                return pro.Skip((iPage - 1) * Static.recPerPage).Take(Static.recPerPage).AsEnumerable<Product>();
            }
        }
        public Product SelectProduct()
        {
            Table<Product> products = data.GetTable<Product>();
            var pro = from p in products
                      select p;
            return pro.FirstOrDefault();
        }
        public Product SelectProduct(int id)
        {
            Table<Product> products = data.GetTable<Product>();
            return id==0?new Product(): products.SingleOrDefault(x=>x.ID==id);
        }
        public IEnumerable<String> GetTag()
        {

            Table<Product> products = data.GetTable<Product>();
            var pro = from p in products
                      select p.Tag.Split('#');
            var ll = new List<String>();
            foreach (var item in pro)
            {
                foreach (var s in item)
                {
                    if (!ll.Contains(s))
                        ll.Add(s);
                }
            }
            return ll.AsEnumerable<string>();
        }
        public void DeleteProduct(int id)
        {
            try
            {
                data.Products.DeleteOnSubmit(data.Products.SingleOrDefault(x => x.ID == id));
                data.SubmitChanges();
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        public int InsertProduct(Product pro)
        {
            try
            {
                data.Products.InsertOnSubmit(pro);
                data.SubmitChanges();
                return pro.ID;
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        public void UpdateProduct(Product pro)
        {
            try
            {
                Product p=data.Products.Single(x => x.ID == pro.ID);
                p.Color = pro.Color;
                p.Description = pro.Description;
                p.IDBrand = pro.IDBrand;
                p.IDCategory = pro.IDCategory;
                p.Model = pro.Model;
                p.NewPrice = pro.NewPrice;
                p.OldPrice = pro.OldPrice;
                p.ProductName = pro.ProductName;
                p.ReviewProduct = pro.ReviewProduct;
                p.Size = pro.Size;
                p.Tag = pro.Tag;
                data.SubmitChanges();
            }catch(Exception ee)
            {
                throw ee;
            }
        }
    }
}