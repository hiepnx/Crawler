using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
   public class HotdealDBContext:DbContext
    {
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductLink> ProductLinks { get; set; }
       public DbSet<Supplier> Suppliers {get;set;}
        public HDException SaveChange()
        {
            HDException ex = new HDException {ErrorCode = 1, ErrorMessage = "" };
            
            try
            {
                this.SaveChanges();
            }
            catch (Exception exe)
            {
                ex.ErrorCode = exe.HResult;
                ex.ErrorMessage = exe.Message;
                ex.InnerErrMessage = exe.InnerException.InnerException.Message;
            }
            return ex;
        }
    }
}
