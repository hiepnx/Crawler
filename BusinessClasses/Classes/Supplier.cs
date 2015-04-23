using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNameForAdmin { get; set; }
        public string Description { get; set; }
        public string SupplierWebsite { get; set; }
        public string SupplierFanpage { get; set; }
        public string Comment { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
