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
        public bool InsertUser(User pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var UserRepositories = new Repository<User>(context);
                UserRepositories.Insert(pr);
            }
            return ret; 
        }
        public bool InsertUserRange(List<User> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<User>(context);
                repositories.InsertRange(prs);
            }
            return ret;
        }
        

        public bool RemoveAllUser()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<User>(context);
                repositories.DeleteAll();
            }
            return ret;
        }
    }
}
