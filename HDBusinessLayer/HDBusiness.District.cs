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
        public bool InsertDistrict(District pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var DistrictRepositories = new Repository<District>(context);
                DistrictRepositories.Insert(pr);
            }
            return ret; 
        }
        public bool InsertDistrictRange(List<District> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<District>(context);
                
                repositories.InsertRange(prs);
            }
            return ret;
        }
        

        public bool RemoveAllDistrict()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<District>(context);
                repositories.DeleteAll();
            }
            return ret;
        }
    }
}
