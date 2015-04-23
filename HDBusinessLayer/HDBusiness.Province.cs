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
        public bool InsertProvince(Province pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var ProvinceRepositories = new Repository<Province>(context);
                ProvinceRepositories.Insert(pr);
            }
            return ret; 
        }
        public bool InsertProvinceRange(List<Province> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Province>(context);
                repositories.InsertRange(prs);
            }
            return ret;
        }
        

        public bool RemoveAllProvince()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Province>(context);
                repositories.DeleteAll();
                
            }
            return ret;
        }
        public Province GetProvinceById(int Id)
        {
            Province ret = new Province() ;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Province>(context);
                ret= repositories.GetById(Id);

            }
            return ret;
        }
    }
}
