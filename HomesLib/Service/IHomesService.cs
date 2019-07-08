using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomesLib.Model;
using HomesDAL;
namespace HomesLib.Service
{
    public interface IHomesService
    {
        HomesListModel GetAllHomes();
        HomesModel GetHomeById(int id);
        void AddCartItem(string userId, int homeId, int qty);
        ShoppingCartListModel GetCart();
        decimal addTotalPrice();
        void RemoveFromCart(int homeId);
        HomesListModel GetHomeBySearch(string SearchString);
        void RemoveAllFromCart(string userId);
        void AddOneToCart(int homeId);
    }
}
