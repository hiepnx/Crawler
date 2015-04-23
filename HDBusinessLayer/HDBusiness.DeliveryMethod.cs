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
        public bool InsertDeliveryMethod(DeliveryMethod pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var DeliveryMethodRepositories = new Repository<DeliveryMethod>(context);
                DeliveryMethodRepositories.Insert(pr);
                DeliveryMethodRepositories.SaveChanges();
            }
            return ret; 
        }
        public bool InsertDeliveryMethodRange(List<DeliveryMethod> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<DeliveryMethod>(context);
                repositories.InsertRange(prs);
                repositories.SaveChanges();
            }
            return ret;
        }

        public int GetDeliveryMethodByName(string DeliveryMethodName)
        {
            int ret = -1;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<DeliveryMethod>(context);
                DeliveryMethod cat = repositories.SearchFor(i => i.Name.Equals(DeliveryMethodName)).FirstOrDefault();
                if (cat == null)
                {
                    this.InsertDeliveryMethod(new DeliveryMethod { Name = DeliveryMethodName, Description = DeliveryMethodName });
                    DeliveryMethod cat1 = repositories.SearchFor(i => i.Name.Equals(DeliveryMethodName)).FirstOrDefault();
                    ret = cat1.Id;
                }
                else
                {
                    ret = cat.Id;
                }
            }
            return ret;
        }
        public bool RemoveAllDeliveryMethod()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<DeliveryMethod>(context);
                repositories.DeleteAll();
                repositories.SaveChanges();
            }
            return ret;
        }
    }
}
