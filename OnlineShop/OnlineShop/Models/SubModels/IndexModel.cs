using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.SubModels
{
    public class IndexModel
    {
        public IEnumerable<OnlineShop.Models.Category> category { get; set; }
        public IEnumerable<OnlineShop.Models.Subcategory> subcategory { get; set; }
        public IEnumerable<OnlineShop.Models.Product> products { get; set; }
        public IEnumerable<OnlineShop.Models.ProductImage> productImages { get; set; }


        public IndexModel(IEnumerable<OnlineShop.Models.Category> category,
            IEnumerable<OnlineShop.Models.Subcategory> subcategory,
            IEnumerable<OnlineShop.Models.Product> products,
            IEnumerable<OnlineShop.Models.ProductImage> productImages)
        {
            this.category = category;
            this.subcategory = subcategory;
            this.products = products;
            this.productImages = productImages;
        }

        //public IEnumerable<OnlineShop.Models.Category> category { get; set; }
        //public IEnumerable<OnlineShop.Models.Subcategory> subcategory { get; set; }

        //public IndexModel(IEnumerable<OnlineShop.Models.Category> category,
        //    IEnumerable<OnlineShop.Models.Subcategory> subcategory)
        //{
        //    this.category = category;
        //    this.subcategory = subcategory;
        //}
    }
}
