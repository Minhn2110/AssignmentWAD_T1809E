using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD.Models;

namespace WAD.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        private MyDatabaseContext db = new MyDatabaseContext();
        private const string ShoppingCartSessionName = "SHOPPING_CART";
        public ActionResult AddToCart(int productId, int quantity)
        {
            var existingproduct = db.ProductsChild.FirstOrDefault(p => p.Id == productId);
            if (existingproduct == null)
            {
                return new HttpNotFoundResult();
            }

            var shoppingCart = GetShoppingCart();
            shoppingCart.Add(existingproduct, quantity, false);
            SetShoppingCart(shoppingCart);

            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult ShowCart()
        {
            return View("ShowCart", GetShoppingCart());
        }

        private ShoppingCart GetShoppingCart()
        {
            ShoppingCart shoppingCart = null;
            if (Session[ShoppingCartSessionName] != null)
            {
                try
                {
                    shoppingCart = Session[ShoppingCartSessionName] as ShoppingCart;
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
            }

            return shoppingCart;
        }

        private void SetShoppingCart(ShoppingCart shoppingCart)
        {
            Session[ShoppingCartSessionName] = shoppingCart;
        }

        private void ClearShoppingCart()
        {
            Session[ShoppingCartSessionName] = null;
        }
    }
}