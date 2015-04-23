using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
   public class User
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public int? CityId { get; set; }
       [ForeignKey("CityId")]
       public Province City { get; set; }
       public int? DistrictId { get; set; }
       [ForeignKey("DistrictId")]
       public District District { get; set; }
       public int? WardId { get; set; }
       [ForeignKey("WardId")]
       public Ward Ward { get; set; }
       public string NumberAddress { get; set; }
       public string Street { get; set; }
       public string Floor { get; set; }
       public string Mobile { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public string DOB { get; set; }
       public int Gender { get; set; }
       public int RoleId { get; set; }
       [ForeignKey("RoleId")]
       public Role Role { get; set; }
    }
}
