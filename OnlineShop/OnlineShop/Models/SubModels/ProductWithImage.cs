using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.SubModels
{
    public class ProductWithImage
    {
        public IEnumerable<OnlineShop.Models.Product> products { get; set; }
        public IEnumerable<OnlineShop.Models.ProductImage> productImages { get; set; }

        public ProductWithImage(IEnumerable<OnlineShop.Models.Product> products,
            IEnumerable<OnlineShop.Models.ProductImage> productImages)
        {
            this.products = products;
            this.productImages = productImages;
        }
    }
}
