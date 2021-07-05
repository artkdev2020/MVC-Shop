using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Characteristic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Bigint")]
        public long ProductFk { get; set; }
        [ForeignKey("ProductFk")]
        [JsonIgnore]
        public virtual Product Product { get; set; }

        [MaxLength(15)]
        [Required]
        public string Color { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public string MaterialRatio { get; set; }

        [MaxLength(25)]
        [Required]
        public string ProducingCountry { get; set; }

        [MaxLength(25)]
        [Required]
        public string BrandCountry { get; set; }

        public string Additional { get; set; }

        [JsonIgnore]
        public ICollection<Size> Sizes { get; set; }

    }
}
