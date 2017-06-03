using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartSale.Models;
using System.Collections;
using System.Data.Linq;
namespace SmartSale.Models.BaseModels
{
    public class CategoryModel
    {
        private EntityDataContext data;
        public CategoryModel()
        {
            data = new EntityDataContext();
        }
        public Hashtable SelectListCategory()
        {
            Hashtable hash = new Hashtable();
            Table<Category> categorys = data.GetTable<Category>();

            var catParent = from cat in categorys
                            join cat1 in categorys on cat.ID equals cat1.CategoryParent into ff
                            from left in ff.DefaultIfEmpty()
                            where cat.CategoryParent == null
                            select new
                            {
                                cat.ID,
                                cat.CategoryName,
                                s = left.CategoryName == null ? "" : left.CategoryName,
                                g = (int)left.ID == 0 ? "" : left.ID.ToString()
                            };


            foreach (var cat in catParent)
            {
                if ("".Equals(cat.s))
                {
                    hash.Add((int)cat.ID, new Category(cat.ID, cat.CategoryName));
                }
                else
                {
                    bool check = false;
                    IEnumerator key = hash.Keys.GetEnumerator();
                    Category cate = new Category(Convert.ToInt32(cat.ID), cat.CategoryName);
                    while (key.MoveNext())
                    {
                        if (cate.Equals(((Category)key.Current)))
                        {
                            check = true;
                            cate = (Category)key.Current;
                        }
                    }
                    if (check)
                    {
                        ((List<Category>)hash[cate]).Add(new Category(Convert.ToInt32(cat.g), cat.s));
                    }
                    else
                    {
                        List<Category> l = new List<Category>();
                        l.Add(new Category(Convert.ToInt32(cat.g), cat.s));
                        hash.Add(new Category(Convert.ToInt32(cat.ID), cat.CategoryName), l);
                    }
                }

            }
            return hash;
        }
        public IQueryable<Category> SelectCategory()
        {
            Table<Category> catTable = data.Categories;
            var re = from cat in catTable
                     select cat;
            return re;
        }
        public IQueryable<Category> SelectParentCategory()
        {
            Table<Category> catTable = data.Categories;
            var re = from cat in catTable
                     where cat.Category1 == null
                     select cat;
            return re;
        }
        public Category SelectCategory(int id)
        {
            return id == 0 ? new Category() : data.Categories.SingleOrDefault(x => x.ID == id);
        }
        public void DeleteCategory(int id)
        {
            try
            {
                data.Categories.DeleteOnSubmit(data.Categories.Single(x => x.ID == id));
                data.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
        public void InsertCategory(Category cat)
        {
            try
            {
                //  data.ExecuteCommand("Insert into Category(CategoryName) values('xxxxxxx') ", null);
                Table<Category> c = data.GetTable<Category>();
                cat.IsDeleted = "0";
                c.InsertOnSubmit(cat);
                data.SubmitChanges();
            }
            catch(Exception ee)
            {
                throw ee;
            }
        }
        public void UpdateCategory(Category cat)
        {
            try
            {
                Category cate=data.Categories.Single(x => x.ID == cat.ID);
                cate.CategoryName = cat.CategoryName;
                cate.CategoryParent = cat.CategoryParent;
                data.SubmitChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}