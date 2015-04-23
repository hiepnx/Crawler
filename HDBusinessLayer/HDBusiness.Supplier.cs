using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessClasses;

namespace HDBusinessLayer
{
    public partial class HDBusiness
    {
        public bool InsertSupplier(Supplier pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var SupplierRepositories = new Repository<Supplier>(context);
                SupplierRepositories.Insert(pr);
                SupplierRepositories.SaveChanges();
            }
            return ret; 
        }
        public bool InsertSupplierRange(List<Supplier> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Supplier>(context);
                repositories.InsertRange(prs);
                repositories.SaveChanges();
            }
            return ret;
        }
        public int GetSupplierIdByAddress(List<Address> addresses)
        {
            int ret = -1;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Supplier>(context);
                var addrepositories = new Repository<Address>(context);
               // var address = addrepositories.SearchFor(i => i.ContactPhone.Trim().Equals(addresses[0].ContactPhone.Trim())).FirstOrDefault();
                var add = addrepositories.GetAll().ToList().Where(i => i.ContactPhone.Trim().Equals(addresses[0].ContactPhone.Trim())).FirstOrDefault();
                if (add == null)
                {
                    Supplier s = new Supplier{SupplierName = "Supplier Without Name",SupplierNameForAdmin = "Supplier Without Name"};
                    this.InsertSupplier(s);
                    var newlyAddedSupp= repositories.GetAll().OrderByDescending(i => i.Id).FirstOrDefault();
                    if (newlyAddedSupp != null)
                    {
                        foreach (var item in addresses)
                        {
                            item.SupplierId = newlyAddedSupp.Id;
                        }
                        this.InsertAddressRange(addresses);
                        ret = newlyAddedSupp.Id;
                    }
                }
                else
                {
                    ret = add.SupplierId;
                }
            }
            return ret;
        }

        public bool RemoveAllSupplier()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Supplier>(context);
                repositories.DeleteAll();
                repositories.SaveChanges();
            }
            return ret;
        }
    }
}
