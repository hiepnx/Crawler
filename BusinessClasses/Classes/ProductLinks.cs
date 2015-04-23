using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
    public class ProductLink
    {
        public ProductLink()
        {
        }

        public ProductLink(string Link)
        {
            this.Link = Link;
            this.ProductCode = GetProductCode(Link);
        }
        public int Id { get; set; }
        public string Link { get; set; }
        
        public int? ProductCode
        {
          
            get;
            set;
        }
        private int GetProductCode(string link)
        {
            int ret = 0;
            string[] strs = link.Split('-');
            if (strs.Length != 0)
            {
                string s = strs[strs.Length - 1];
                int IndexOfDot = s.IndexOf('.');
                string s1 = s.Remove(IndexOfDot, s.Length - IndexOfDot);
                int a = 0;
                if (Int32.TryParse(s1, out a))
                {
                    ret = a;
                }
            }
            return ret;
        }
    }
}
