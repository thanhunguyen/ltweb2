using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWEB2.Helpers
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        
        public Cart()
        {
            this.Items = new List<CartItem>();
        }       

        public void Add(CartItem item)
        {
            this.Items.Add(item);
        }

        public int GetTotal()
        {
            return this.Items.Sum(i=>i.Quantity);
        }
    }



    public class CartItem
    {
        public int ProID { get; set; }
        public int Quantity { get; set; }
    }
}

