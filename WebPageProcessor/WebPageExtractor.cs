using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebPageProcessor
{
    class WebPageExtractor
    {
        public static List<string> GetUrlListOnFirstPage(HtmlDocument doc)
        {
            List<string> ret1 = new List<string>();
            string classToFind = "product-item";
            var allLinksWithClassProductItems = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]//*[contains(@class,'{1}')]//a", classToFind, "thumb"));
            foreach (var item in allLinksWithClassProductItems)
            {
                ret1.Add(item.Attributes["href"].Value);
            }
            return ret1;
        }
    }
}
