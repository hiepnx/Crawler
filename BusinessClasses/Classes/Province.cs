using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
   public class Province
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Type { get; set; }
       //List<Product> Products { get; set; }
    }
   public class District
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Type { get; set; }
       public string Location { get; set; }

       public int ProvinceId { get; set; }
       [ForeignKey("ProvinceId")]
       public Province Province { get; set; }
   }

   public class Ward
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Type { get; set; }
       public string Location { get; set; }
       public int DistrictId {get;set;}
       [ForeignKey("DistrictId")]
       public District District { get; set; }
   }
}
