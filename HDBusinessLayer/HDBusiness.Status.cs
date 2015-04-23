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
        public bool InsertStatus(Status pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var StatusRepositories = new Repository<Status>(context);
                StatusRepositories.Insert(pr);
            }
            return ret; 
        }
        public bool InsertStatusRange(List<Status> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Status>(context);
                repositories.InsertRange(prs);
            }
            return ret;
        }
        

        public bool RemoveAllStatus()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Status>(context);
                repositories.DeleteAll();
            }
            return ret;
        }
    }
}
