using System;
using System.Collections.Generic;
using ShoppingCheckout.Models;

namespace ShoppingCheckout.Services
{
    public class CheckoutServices
    {
        private readonly Dictionary<char, Item> _items;
        private Dictionary<char, int> _itemCounts;

        public CheckoutServices()
        {
            _items = new Dictionary<char, Item>();
            _itemCounts = new Dictionary<char, int>();
            InitializeItems();
        }

        public void Scan(string sku)
        {
            if (sku.Length != 1)
            {
                throw new ArgumentException("SKU must be a single character.");
            }

            char skuChar = sku[0];

            if (_items.TryGetValue(skuChar, out Item item))
            {
                if (!_itemCounts.ContainsKey(skuChar))
                {
                    _itemCounts[skuChar] = 0;
                }
                _itemCounts[skuChar]++;
            }
            else
            {
                throw new ArgumentException($"Invalid SKU: {sku}");
            }
        }

        public int Checkout(string skus)
        {
            ResetItemCount();
            foreach (char sku in skus)
            {
                Scan(sku.ToString());
            }
            return CalculateTotalPrice();
        }

        private int CalculateTotalPrice()
        {
            int totalPrice = 0;
            foreach (var kvp in _itemCounts)
            {
                char sku = kvp.Key;
                int count = kvp.Value;
                Item item = _items[sku];

                if (item.Offer != null && count >= item.Offer.Quantity)
                {
                    int offerPrice = (count / item.Offer.Quantity) * item.Offer.Price;
                    int remainingItems = count % item.Offer.Quantity;
                    int remainingPrice = remainingItems * item.Price;
                    totalPrice += offerPrice + remainingPrice;
                }
                else
                {
                    totalPrice += count * item.Price;
                }
            }
            return totalPrice;
        }

        private void ResetItemCount()
        {
            _itemCounts.Clear();
        }

        private void InitializeItems()
        {
            // Add items to the dictionary with their SKUs, prices, and offers if applicable
            _items['A'] = new Item('A', 50, new Offer(3, 130));
            _items['B'] = new Item('B', 30, new Offer(2, 45));
            _items['C'] = new Item('C', 20);
            _items['D'] = new Item('D', 15);
            // Add more items as needed
        }
    }
}

