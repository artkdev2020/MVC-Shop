using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class FiscalBill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Bigint")]
        public long OrderFk { get; set; }
        [ForeignKey("OrderFk")]
        [JsonIgnore]
        public virtual Order Order { get; set; }

        [Required]
        public Guid BillGuid { get; set; }
    }
}
