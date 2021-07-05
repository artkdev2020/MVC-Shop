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
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "Bigint")]
        public long? SubcategoryFk { get; set; }
        [ForeignKey("SubcategoryFk")]
        [JsonIgnore]
        public virtual Subcategory Subcategory { get; set; }

        [MaxLength(70)]
        [Required]
        public string Name { get; set; }

        [MaxLength(150)]
        [Required]
        public string ShortDescription { get; set; }

        [Column(TypeName = "Text")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "DateTime")]
        [Required]
        public DateTime MomentAdded { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime MomentEdited { get; set; }

        [Required]
        [Column(TypeName = "SmallMoney")]
        public decimal Price { get; set; }

        [Column(TypeName = "Float")]
        public double Discount { get; set; }


        [Range(0, 5)]
        [Column(TypeName = "Float")]
        public float Rating { get; set; }

        [Required]
        public long Model { get; set; }

        [Column(TypeName = "Bit")]
        [JsonIgnore]
        public bool InArchive { get; set; }

        [JsonIgnore]
        public ICollection<ProductImage> Images { get; set; }
        [JsonIgnore]
        public ICollection<Characteristic> Characteristics { get; set; }
        [JsonIgnore]
        public ICollection<OrderDetails> OrderDetails { get; set; }

        static Product()
        {
            Triggers<Product>.Deleting += e =>
            {
                Console.WriteLine("DELETING PRODUCT TRIGGER CALLED");

                e.Cancel = true;
                e.Entity.InArchive = true;

                var images = e.Entity.Images;
                foreach (var image in images)
                    e.Context.Remove(image);

                var characteristics = e.Entity.Characteristics;
                foreach (var characteristic in characteristics)
                    e.Context.Remove(characteristic);
            };

            Triggers<Product>.Updating += e =>
            {
                e.Entity.MomentEdited = DateTime.UtcNow;
            };

            Triggers<Product>.Inserting += e =>
            {
                e.Entity.MomentAdded = DateTime.UtcNow;
                e.Entity.MomentEdited = DateTime.UtcNow;
            };
        }
    }
}
