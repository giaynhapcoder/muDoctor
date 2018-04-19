using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaio.Core
{
    public class CartItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public double Discounts { get; set; }

        public double Costs
        {
            get
            {
                var _costs = Price * Quantity;
                return Math.Round(_costs - ((_costs * Discounts) / 100), 2);
            }
        }
    }

    public class ShoppingCart
    {



        public List<CartItem> Items { get; set; }

        public string Note { get; set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public static ShoppingCart Instant
        {
            get
            {
                return (ShoppingCart)HttpContext.Current.Session["__SHOPPINGCART"] ?? new ShoppingCart();
            }
        }

        public CartItem Get(string id)
        {
            return Items.Find(x => x.Id == id);
        }

        public void Add(CartItem item)
        {
            Items.Add(item);
        }

        public void Remove(CartItem x)
        {
            Items.Remove(x);
        }

        public void Remove(string id)
        {

            Items = Items.Where(x => x.Id != id).ToList();
        }

        public void Update(CartItem item)
        {
            int _index = Items.FindIndex(x => x.Id == item.Id);
            Items[_index] = item;
        }

        public double TotalCosts
        {
            get
            {
                return Items.Sum(x => x.Costs);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
