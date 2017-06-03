using SmartSale.Areas.Admin2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSale.Models.BaseModels
{
    public class BillModel
    {
        private EntityDataContext data;
        public BillModel()
        {
            data = new EntityDataContext();
        }
        public void InsertBill(Bill bill, Hashtable billdetail)
        {
            data.Bills.InsertOnSubmit(bill);
            data.SubmitChanges();
            IEnumerator ie = billdetail.Keys.GetEnumerator();
            while (ie.MoveNext())
            {
                BillDetail bd = new BillDetail();
                Object obj = ie.Current;
                bd.IDBill = bill.ID;
                bd.IDProduct = (int)obj;
                bd.Number = (int)billdetail[obj];
                bd.Price = 0;
                data.BillDetails.InsertOnSubmit(bd);
            }
            data.SubmitChanges();
        }
        public IEnumerable GetBill()
        {
            return from i in data.Bills
                   select i;
        }
        public Ticket GetTicket(int idBill)
        {
            Ticket ticket = new Ticket();
            ticket.Bill = data.Bills.SingleOrDefault(x => x.ID == idBill);
            var i = from ii in data.BillDetails
                    where ii.IDBill == idBill
                    select new Item {
                        IdProduct = ii.IDProduct,
                        NameProduct = ii.Product.ProductName,
                        Price = ii.Product.NewPrice,
                        Amount=ii.Number
                  };
            ticket.Items = i.ToList();           
            return ticket;
        }
        public void DeleteBill(int id)
        {

            data.BillDetails.DeleteAllOnSubmit(from i in data.BillDetails
                                               where i.IDBill == id
                                               select i
                                               );
            data.SubmitChanges();
            data.Bills.DeleteOnSubmit(data.Bills.SingleOrDefault(x => x.ID == id));
            data.SubmitChanges();
        }
        public void CheckBill(int id)
        {
            Bill b= data.Bills.SingleOrDefault(x => x.ID==id);
            if (b.IsDeleted==0)
             b.IsDeleted = 1;
            else
             b.IsDeleted = 0;
            data.SubmitChanges();
        }
    }
}