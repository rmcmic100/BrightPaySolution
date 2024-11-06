using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightPaySolution
{
    interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
    internal class Checkout : ICheckout
    {
        // creating a dictionary for the items as it perfectly suits the key/value pairing of SKU and Unit Price
        private readonly Dictionary<string, int> items = new Dictionary<string, int>
        {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        };

        // creating a dictionary for the multiprice deals, utilising a tuple for the quantity and price values
        private readonly Dictionary<string, (int quantity, int price)> multipriceDeals = new Dictionary<string, (int quantity, int price)>
        {
            { "A", (3, 130) },
            { "B", (2, 45) }
        };

        // creating a dictionary for the cart to store the item SKU and the quantity
        private readonly Dictionary<string, int> cart = new Dictionary<string, int>();

        public void Scan(string item)
        {
            if (items.ContainsKey(item))
            {
                if (cart.ContainsKey(item))
                {
                    cart[item]++;
                }
                else
                {
                    cart.Add(item, 1);
                }
            } else
            {
                Console.WriteLine("Invalid item - Please scan a valid item");
            }
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in cart)
            {
                if (multipriceDeals.ContainsKey(item.Key))
                {
                    int noOfMultipriceDeals = item.Value / multipriceDeals[item.Key].quantity;
                    int remainder = item.Value % multipriceDeals[item.Key].quantity;

                    totalPrice += noOfMultipriceDeals * multipriceDeals[item.Key].price;
                    totalPrice += remainder * items[item.Key];
                } else
                {
                    totalPrice += item.Value;
                }
            }

            return totalPrice;
        }
    }
}
