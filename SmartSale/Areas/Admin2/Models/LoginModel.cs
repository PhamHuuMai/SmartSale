using SmartSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSale.Areas.Admin2.Models
{
    public class LoginModel
    {
        private EntityDataContext data;
        public LoginModel()
        {
            data = new EntityDataContext();
        }

        public bool CheckAccount(string acc, string pass)
        {
            if (data.Administraors.Count(x => (x.Username.Equals(acc) & x.Password.Equals(pass))) == 1)
                return true;
            else
                return false;
        }

    }
}