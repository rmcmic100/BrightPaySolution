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
        public void Scan(string item)
        {

        }

        public int GetTotalPrice()
        {
            return 0;
        }
    }
}
