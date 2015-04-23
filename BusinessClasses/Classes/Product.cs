using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
    public class Product
    {
        public int Id { get; set; }
        //public int ExternalId { get; set; } // the Id from the website
        public string Name { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public Province City { get; set; }

        public string ShortDescription { get; set; }
        public string HightLights { get; set; }
        public string Conditions { get; set; }
        public string Description { get; set; }
        public DateTime ExpiredTime { get; set; }

        public int? DeliveryMethodId { get; set; }
        [ForeignKey("DeliveryMethodId")]
        public DeliveryMethod DeliveryMethod { get; set; }

        public decimal PriceBeforeDiscount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string ImageLink3 { get; set; }
        public string ImageLink4 { get; set; }
        public string ImageLink5 { get; set; }
        public string ImageLink6 { get; set; }

        public int? ProductLinkId { get; set; }
        [ForeignKey("ProductLinkId")]
        public ProductLink link { get; set; }

        public string ProductLink { get; set; }


    }
       
}
