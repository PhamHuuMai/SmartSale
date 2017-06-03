using SmartSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSale.Areas.Admin2.Models
{
    public class ImageModel
    {
        private EntityDataContext data;
        public ImageModel()
        {
            data = new SmartSale.Models.EntityDataContext();
        }
        public void InsertImg(int id,String queueImg)
        {
            queueImg = queueImg.Remove(queueImg.Length - 1);
            String[] list= queueImg.Split('-');
            foreach(var i in list)
            {
                Image img = new Image();
                img.IDProduct = id;
                img.name =i.Split('.')[0] ;
                img.url =i;
                img.extend = ".png";
                data.Images.InsertOnSubmit(img);
                data.SubmitChanges();
            }
        }
        public void DeleteImg(String image)
        {
            try
            {
                data.Images.DeleteOnSubmit(data.Images.SingleOrDefault(x => x.name.Equals(image)));
                data.SubmitChanges();
            }
            catch { }
        }
    }
}