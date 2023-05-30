using ShoppingCheckout.Models;

namespace ShoppingCheckout.Models
{
    public class Item
    {
        private string v1;
        private int v2;

        public char SKU { get; set; }
        public int Price { get; set; }
        public Offer Offer { get; set; }

        public Item(char sku, int price, Offer offer = null)
        {
            SKU = sku;
            Price = price;
            Offer = offer;
        }

        public Item(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
    public class Offer
    {
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Offer(int quantity, int price)
        {
            Quantity = quantity;
            Price = price;
        }
    }
}