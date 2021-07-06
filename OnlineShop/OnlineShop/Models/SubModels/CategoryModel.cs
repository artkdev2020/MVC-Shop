using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.SubModels
{
    public class CategoryModel
    {
        public IEnumerable<OnlineShop.Models.Category> category{ get; set; }
        public IEnumerable<OnlineShop.Models.Subcategory> subcategory { get; set; }

        public CategoryModel(IEnumerable<OnlineShop.Models.Category> category,
            IEnumerable<OnlineShop.Models.Subcategory> subcategory)
        {
            this.category = category;
            this.subcategory = subcategory;
        }
    }
}
