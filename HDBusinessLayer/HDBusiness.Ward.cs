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
        public bool InsertWard(Ward pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var WardRepositories = new Repository<Ward>(context);
                WardRepositories.Insert(pr);
            }
            return ret; 
        }
        public bool InsertWardRange(List<Ward> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Ward>(context);
                repositories.InsertRange(prs);
            }
            return ret;
        }
        

        public bool RemoveAllWard()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Ward>(context);
                repositories.DeleteAll();
            }
            return ret;
        }
    }
}
