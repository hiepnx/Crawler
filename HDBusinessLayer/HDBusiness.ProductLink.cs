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
        public bool InsertProductLink(ProductLink pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var ProductLinkRepositories = new Repository<ProductLink>(context);
                ProductLinkRepositories.Insert(pr);
                ProductLinkRepositories.SaveChanges();
            }
            return ret; 
        }
        public bool InsertProductLinkRange(List<ProductLink> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<ProductLink>(context);
                repositories.InsertRange(prs);
                repositories.SaveChanges();
            }
            return ret;
        }
        public List<int> GetAllProductCode()
        {
            List<int> ret = new List<int>();
            using (var context = new HotdealDBContext())
            {
                ret = context.ProductLinks.Select(i => i.ProductCode.Value).ToList();
            }
            return ret;
        }

        public List<string> GetAllProductLink()
        {
            List<string> ret = new List<string>();
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<ProductLink>(context);
                ret = repositories.GetAll().Select(i => i.Link).ToList();
                //ret = context.Get.Select(i => i.ProductCode.Value).ToList();
            }
            return ret;
        }

        public bool RemoveAllProductLink()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<ProductLink>(context);
                repositories.DeleteAll();
                repositories.SaveChanges();
            }
            return ret;
        }
    }
}
