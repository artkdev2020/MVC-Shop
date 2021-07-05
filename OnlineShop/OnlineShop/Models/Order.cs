using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "Bigint")]
        public long CustomerFk { get; set; }
        [ForeignKey("CustomerFk")]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime MomentCreated { get; set; }

        [Column(TypeName = "Text")]
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<OrderDetails> OrderDetails { get; set; }
        [JsonIgnore]
        public ICollection<FiscalBill> FiscalBill { get; set; }
    }
}
