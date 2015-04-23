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
        public bool InsertAddress(Address pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var AddressRepositories = new Repository<Address>(context);
                AddressRepositories.Insert(pr);
                context.SaveChange();
            }
            return ret; 
        }
        public bool InsertAddressRange(List<Address> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Address>(context);
                repositories.InsertRange(prs);
                context.SaveChange();
            }
            return ret;
        }
        

        public bool RemoveAllAddress()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Address>(context);
                repositories.DeleteAll();
                context.SaveChange();
            }
            return ret;
        }
    }
}
