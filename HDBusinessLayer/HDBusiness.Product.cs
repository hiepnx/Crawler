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
        public bool InsertProduct(Product pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var ProductRepositories = new Repository<Product>(context);
                ProductRepositories.Insert(pr);
                ProductRepositories.SaveChanges();
            }
            return ret; 
        }
        public bool InsertProductRange(List<Product> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Product>(context);
                repositories.InsertRange(prs);
                repositories.SaveChanges();
            }
            return ret;
        }
        

        public bool RemoveAllProduct()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Product>(context);
                repositories.DeleteAll();
                repositories.SaveChanges();
            }
            return ret;
        }
    }
}
