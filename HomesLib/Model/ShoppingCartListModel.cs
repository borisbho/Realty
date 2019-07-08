using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesLib.Model
{
    public class ShoppingCartListModel
    {
        public List<ShoppingCartModel> Cart { get; set; }
        private decimal  totalPrice;

        public decimal getTotalPrice()
        {
            decimal price = Cart.Sum(e => e.Price * e.Quantity);
             
           


            return price;
        }
        public ShoppingCartListModel()
        {
            Cart = new List<ShoppingCartModel>();
        }
        
    }
}
