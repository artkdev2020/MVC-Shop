using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.NewEmailModel
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [MaxLength(36)]
        [Column("CityRefFk")]
        public string CityRef { get; set; } // Идентификатор населенного пункта - внешний ключ на город, берем из CityRef Warehouses
        public string SiteKey { get; set; } // Код отделения decimal[9999999999]
        [MaxLength(99)]
        public string Description { get; set; } // Название отделения на Украинском
        [MaxLength(99)]
        public string DescriptionRu { get; set; } // Название отделения на русском
        [MaxLength(99)]
        public string ShortAddress { get; set; } // Ничипорівка, Андрія Бобира, 13

        [MaxLength(99)]
        public string ShortAddressRu { get; set; } // Ничипоровка, Андрея Бобырь, 13
        public string Number { get; set; } // Номер отделения
        [MaxLength(50)]
        public string CityDescription { get; set; } // Название населенного пункта на Украинском
        [MaxLength(50)]
        public string CityDescriptionRu { get; set; } // Название населенного пункта на русском
        public string TotalMaxWeightAllowed { get; set; } // Максимальный вес отправления
        public string PlaceMaxWeightAllowed { get; set; } // Максимальный вес одного места отправления

        public Warehouse() { }
        public Warehouse(
            string cityRef,
            string siteKey,
            string description,
            string descriptionRu,
            string shortAddress,
            string shortAddressRu,
            string number,
            string cityDescription,
            string cityDescriptionRu,
            string totalMaxWeightAllowed,
            string placeMaxWeightAllowed
            )
        {
            CityRef = cityRef;
            SiteKey = siteKey;
            Description = description;
            DescriptionRu = descriptionRu;
            ShortAddress = shortAddress;
            ShortAddressRu = shortAddressRu;
            Number = number;
            CityDescription = cityDescription;
            CityDescriptionRu = cityDescriptionRu;
            TotalMaxWeightAllowed = totalMaxWeightAllowed;
            PlaceMaxWeightAllowed = placeMaxWeightAllowed;
        }
    }
}
