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
        public bool InsertOrder(Order pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var OrderRepositories = new Repository<Order>(context);
                OrderRepositories.Insert(pr);
            }
            return ret; 
        }
        public bool InsertOrderRange(List<Order> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Order>(context);
                repositories.InsertRange(prs);
            }
            return ret;
        }
        

        public bool RemoveAllOrder()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Order>(context);
                repositories.DeleteAll();
            }
            return ret;
        }
    }
}
