using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddressDesc { get; set; }
        public string ContactPhone { get; set; }
        public string MapInfo { get; set; }
        
        public int? WardId { get; set; }
        [ForeignKey("WardId")]
        public Ward Ward { get; set; }
        public int? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public Province City { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
    }
}
