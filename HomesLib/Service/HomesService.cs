using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomesLib.Model;
using HomesDAL;

namespace HomesLib.Service
{
    public class HomesService : IHomesService
    {
        public HomesListModel GetAllHomes()
        {
            HomesListModel model = new HomesListModel();

            using (var db = new HomesEntities())
            {
                var query = db.HomeTables.Select(h => h);
                var homeList = query.ToList();
                homeList.ForEach(home => model.Homes.Add(
                    new HomesModel()
                    {
                        HomeID = home.HomeID,
                        StreetAddress = home.StreetAddress,
                        City = home.City,
                        State = home.State,
                        Zip = home.Zip,
                        HomeInfo = home.HomeInfo,
                        Price = home.Price,
                        HomeDetailOne = home.HomeDetailOne,
                        HomeDetailTwo = home.HomeDetailTwo,
                        HomeDetailThree = home.HomeDetailThree,
                        Image = home.Image
                    }
            )
                    );
            }
            return model;
        }


        public HomesModel GetHomeById(int id)
        {
            return GetAllHomes().Homes.Where(x => x.HomeID == id).First();
        }

        public ShoppingCartModel GetCartById(int id)
        {
            return GetCart().Cart.Where(x => x.CartID == id).First();
        }
        public HomesListModel GetHomeBySearch(string SearchString)
        {
            HomesListModel model = new HomesListModel();

            using (var db = new HomesEntities())
            {
                var query = db.HomeTables.Where(h => h.StreetAddress.Contains(SearchString));
                var homeList = query.ToList();
                homeList.ForEach(home => model.Homes.Add(
                    new HomesModel()
                    {
                        HomeID = home.HomeID,
                        StreetAddress = home.StreetAddress,
                        City = home.City,
                        State = home.State,
                        Zip = home.Zip,
                        HomeInfo = home.HomeInfo,
                        Price = home.Price,
                        HomeDetailOne = home.HomeDetailOne,
                        HomeDetailTwo = home.HomeDetailTwo,
                        HomeDetailThree = home.HomeDetailThree,
                        Image = home.Image
                    }
            )
                    );
            db.SaveChanges();
            }
            return model;
            //return GetAllHomes().Homes.Where(x => x.HomeInfo.Contains(SearchString)).ToList();

        }

        public ShoppingCartListModel GetCart()
        {
            ShoppingCartListModel model = new ShoppingCartListModel();

            using (var db = new HomesEntities())
            {
                var query = db.ShoppingCartLines.Select(h => h);
                var cartList = query.ToList();
                cartList.ForEach(data => model.Cart.Add(
                    new ShoppingCartModel()
                    {
                        CartID = data.CartID,
                        HomeID = data.HomeID,
                        HomeDetail = data.HomeTable.HomeInfo,
                        Quantity = data.Quanity,
                        Price = data.Quanity * data.HomeTable.Price
                    }
                    ));
                return model;
            }
        }
        public decimal addTotalPrice()
        {
            return GetCart().Cart.Sum(e => e.Price * e.Quantity);
        }
        public void RemoveFromCart(int homeId)
        {
            using (var db = new HomesEntities())
            {
                var query = db.ShoppingCartLines.Where(x => x.HomeID == homeId).First();
                if (query.Quanity != 0)
                {
                    query.Quanity -= 1;
                    if (query.Quanity == 0)
                    {
                        db.ShoppingCartLines.Remove(query);
                    }
                }
                db.SaveChanges();
            }
        }
        public void AddOneToCart(int homeId)
        {

            using (var db = new HomesEntities())
            {
                var query = db.ShoppingCartLines.Where(x => x.HomeID == homeId).First();
                if (query.Quanity != 0)
                {
                    query.Quanity += 1;
                    if (query.Quanity == 0)
                    {
                        db.ShoppingCartLines.Remove(query);
                    }
                }
                db.SaveChanges();
            }
        }
        public void RemoveAllFromCart(string userId)
        {
            using (var db = new HomesEntities())
            {
                var query = db.AspNetUsers.Select(x => x.Id == userId);
                var user = query.First();

                var shopToRemove = db.ShoppingCarts.Where(x => x.UserID == userId).First();
                var lineRemove = db.ShoppingCartLines.Where(x => x.CartID == shopToRemove.CartID).ToList();
                foreach (var a in lineRemove)
                {
                    db.ShoppingCartLines.Remove(a);
                }
                db.SaveChanges();
            }

        }

        public void AddCartItem(string userId, int homeId, int qty)
        {

            using (var db = new HomesEntities())
            {
                var query = db.AspNetUsers.Select(x => x.Id == userId);

                var user = query.First();
                // Get User by Id;
                if (db.ShoppingCarts.Where(x => x.UserID == userId).Count() == 0)
                {

                    db.ShoppingCarts.Add(new ShoppingCart()
                    {

                        UserID = userId
                    });

                    db.SaveChanges();
                }
                var cart = db.ShoppingCarts.Where(x => x.UserID == userId).First();

                if (db.ShoppingCartLines.Where(x => x.HomeID == homeId).Count() == 0)
                {
                    var newCartLine = new ShoppingCartLine()
                    {
                        CartID = cart.CartID,
                        HomeID = homeId,
                        Quanity = qty
                    };
                    db.ShoppingCartLines.Add(newCartLine);

                }
                else
                {
                    var shopquery = db.ShoppingCartLines.Where(x => x.HomeID == homeId).First();
                    shopquery.Quanity += 1;
                }
                db.SaveChanges();
                // Get cart from user.ShoppingCarts.First()
                // Create new CartLine objecct
                // Add Cart Line to Cart.CartLines collection
                // Tell DB to save
            }
        }

    }
}
