using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace SmartSale.Until
{
    public class ShoppingCart
    {
        private Hashtable _Cart;
        private static ShoppingCart sc;
        //private ShoppingCart()
        //{
        //    _Cart = new Hashtable();
        //}
        //public static ShoppingCart getInstance()
        //{
        //    if (ShoppingCart.getInstance() == null)
        //    {
        //        sc = new ShoppingCart();
        //    }
        //    return sc;
        //}

        public ShoppingCart()
        {
            _Cart = new Hashtable();
        }

        public Hashtable Cart()
        {
            return _Cart;
        }
        public IEnumerator Key()
        {
            Hashtable temp = (Hashtable)_Cart.Clone();
            return temp.Keys.GetEnumerator();
        }
        public void AddToCard(int idProduct, int number)
        {
            int num = 0;
            if (_Cart.ContainsKey(idProduct))
            {
                num = (int)_Cart[idProduct] + number;
                _Cart[idProduct]=num;
            }
            else
            {
                _Cart.Add(idProduct, number);
            }
            return;
        }

        public void UpdateItem(int idProduct, int number)
        {
            if (_Cart.ContainsKey(idProduct))
            {
                if (number <= 0)
                    _Cart.Remove(idProduct);
                else
                    _Cart[idProduct] = number;
            }
        }

        public void RemoveItem(int idProduct)
        {
            if (_Cart.ContainsKey(idProduct))
            {
                _Cart.Remove(idProduct);
            }
        }

        public int GetNumberItem()
        {
            IEnumerator vl= _Cart.Values.GetEnumerator();
            int sum = 0;

            while (vl.MoveNext())
            {
                sum = sum +(int)vl.Current;
            }

            return sum;
        }

        public void RemoveAll()
        {
            _Cart.Clear();
        }
    }
}