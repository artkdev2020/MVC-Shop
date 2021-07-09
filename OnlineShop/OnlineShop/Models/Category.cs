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
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [JsonIgnore]
        public ICollection<Subcategory> Subcategories { get; set; }

        static Category()
        {
            Triggers<Category>.Deleting += e =>
            {
                Console.WriteLine("DELETING CATEGORY TRIGGER CALLED");

                var subcategories = e.Entity.Subcategories;

                foreach (var subcategory in subcategories)
                    e.Context.Remove(subcategory);
            };
        }
    }
}