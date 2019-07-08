using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesLib.Model
{
    public class ShoppingCartModel
    {
        public int CartID { get; set; }
        public int HomeID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string HomeDetail { get; set; }

    }
}
