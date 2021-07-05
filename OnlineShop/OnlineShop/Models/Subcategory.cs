using EntityFrameworkCore.Triggers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Subcategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "Bigint")]
        public long? CategoryFk { get; set; }
        [ForeignKey("CategoryFk")]
        [JsonIgnore]
        public virtual Category Category { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }

        static Subcategory()
        {
            Triggers<Subcategory>.Deleting += e =>
            {
                Console.WriteLine("DELETING SUBCATEGORY TRIGGER CALLED");

                var products = e.Entity.Products;

                foreach (var product in products)
                    e.Context.Remove(product);
            };
        }
    }
}
