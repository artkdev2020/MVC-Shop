using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.NewEmailModel
{
    public class City
    {
        [Key]
        public string CityID { get; set; } // Код населенного пункта, должен выступать в роли первичного ключа. Заполняется из поля Ref api новой почты

        [MaxLength(100)]
        public string Description { get; set; } // Город на Украинском языке
        [MaxLength(100)]
        public string DescriptionRu { get; set; } // Город на русском языке
        public string Ref { get; set; } // Идентификатор города
        [MaxLength(36)]
        public string Area { get; set; } // Область
        [MaxLength(36)]
        public string SettlementType { get; set; } // Идентификатор (REF) типа населенного пункта
        [MaxLength(100)]
        public string SettlementTypeDescription { get; set; } // Описание типа населенного пункта на Украинском языке
        [MaxLength(100)]
        public string SettlementTypeDescriptionRu { get; set; } // Описание типа населенного пункта на Русском языке
        [MaxLength(100)]
        public string AreaDescription { get; set; } // Описание типа области на Украинском языке
        [MaxLength(100)]
        public string AreaDescriptionRu { get; set; } // Описание типа области на Русском языке

        public City() { }

        public City(string cityID,
            string description,
            string descriptionRu,
            string area,
            string settlementType,
            string settlementTypeDescription,
            string settlementTypeDescriptionRu,
            string areaDescription,
            string areaDescriptionRu)
        {
            CityID = cityID;
            Description = description;
            DescriptionRu = descriptionRu;
            Area = area;
            SettlementType = settlementType;
            SettlementTypeDescription = settlementTypeDescription;
            SettlementTypeDescriptionRu = settlementTypeDescriptionRu;
            AreaDescription = areaDescription;
            AreaDescriptionRu = areaDescriptionRu;
        }
    }
}
