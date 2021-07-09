using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Utils
{
    static public class Discount
    {
        static public decimal GetDiscount(decimal price, double discount)
        {
            if (discount > 0)
            {
                return Math.Round(price - Convert.ToDecimal(discount / 100), 2);
            }
            return Math.Round(price, 2);
        }
    }
}
