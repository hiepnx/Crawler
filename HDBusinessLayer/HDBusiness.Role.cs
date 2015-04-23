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
        public bool InsertRole(Role pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var RoleRepositories = new Repository<Role>(context);
                RoleRepositories.Insert(pr);
            }
            return ret; 
        }
        public bool InsertRoleRange(List<Role> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Role>(context);
                repositories.InsertRange(prs);
            }
            return ret;
        }
        

        public bool RemoveAllRole()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Role>(context);
                repositories.DeleteAll();
            }
            return ret;
        }
    }
}
