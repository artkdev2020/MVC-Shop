using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class OrderDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "Bigint")]
        public long OrderFk { get; set; }
        [ForeignKey("OrderFk")]
        [JsonIgnore]
        public virtual Order Order { get; set; }

        [Required]
        [Column(TypeName = "Bigint")]
        public long ProductFk { get; set; }
        [ForeignKey("ProductFk")]
        [JsonIgnore]
        public virtual Product Product { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
