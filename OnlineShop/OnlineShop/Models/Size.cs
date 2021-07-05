using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Size
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "Bigint")]
        public long CharacteristicFk { get; set; }
        [ForeignKey("CharacteristicFk")]
        [JsonIgnore]
        public virtual Characteristic Characteristic { get; set; }

        [MaxLength(10)]
        [Required]
        public string Value { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
