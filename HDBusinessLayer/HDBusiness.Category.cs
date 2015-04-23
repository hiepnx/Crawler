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
        public bool InsertCategory(Category pr)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var CategoryRepositories = new Repository<Category>(context);
                CategoryRepositories.Insert(pr);
                CategoryRepositories.SaveChanges();
            }
            return ret; 
        }
        public bool InsertCategoryRange(List<Category> prs)
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Category>(context);
                repositories.InsertRange(prs);
                repositories.SaveChanges();
            }
            return ret;
        }

        public int GetCategoryByName(string CategoryName)
        {
            int ret = -1;
            using (var context = new HotdealDBContext())
            {
                var repositories = new Repository<Category>(context);
               Category cat=  repositories.SearchFor(i => i.Name.Equals(CategoryName)).FirstOrDefault();
               if (cat == null)
               {
                   this.InsertCategory(new Category {Name = CategoryName,Description = CategoryName });
                   Category cat1 = repositories.SearchFor(i => i.Name.Equals(CategoryName)).FirstOrDefault();
                   ret = cat1.Id;
               }
               else
               {
                   ret = cat.Id;
               }
            }
            return ret;
        }

        public bool RemoveAllCategory()
        {
            bool ret = true;
            using (var context = new HotdealDBContext())
            {

                var repositories = new Repository<Category>(context);
                repositories.DeleteAll();
                repositories.SaveChanges();
            }
            return ret;
        }
    }
}
