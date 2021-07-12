using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Utils
{
    public class ProductWithImg
    {
        public Product Prod { get; set; }
        public ProductImage ProdImg { get; set; }
        public ProductWithImg(Product prod, ProductImage productImage)
        {
            Prod = prod;
            ProdImg = productImage;
        }
    }
}
