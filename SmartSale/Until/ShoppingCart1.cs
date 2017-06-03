using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSale.Until
{
    public class ShoppingCart1
    {
        List<ItemCart> list = new List<ItemCart>();
        public void AddItem(ItemCart item)
        {
            if (list.Count(x => x.Id == item.Id) == 0)
            {
                //add
                list.Add(item);
            }
            else {
                ItemCart i = list.Find(x => x.Id == item.Id);
                i.Amount = i.Amount + item.Amount; 
            }
        }



    }
}