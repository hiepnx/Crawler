using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebPageProcessor
{
    public class HomePageWebProcessor<T>: IWebProcessor<T>     
        where T:class
    {
        public HomePageWebProcessor()
        {
            page = new HtmlWeb();
        }
        public HomePageWebProcessor(string _url)
        {
            page = new HtmlWeb();
            url = _url;
        }
        private HtmlWeb page;
        private HtmlDocument doc;
        private string _url;
        public string url { 
            get
            {
                return _url;
            }
            
            set
            {
                if (value != _url)
                {
                    _url = value;
                     doc = page.Load(value);
                }
            }
        }
        public bool IsValidWebPage()
        {
            bool ret = false;
            string classToFind = "no-items";
            var allElementsWithClassNoItems = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));
           return ret = (allElementsWithClassNoItems == null) || (allElementsWithClassNoItems.Count == 0) ? true : false;
        }

        public List<T> Result
        {
            get
            {
                List<T> ret = new List<T>();
                if (typeof(T) != typeof(string)) return null;
                else
                {

                    List<string> ret1 = new List<string>();
                    string classToFind = "product-item";
                    var allLinksWithClassProductItems = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]//*[contains(@class,'{1}')]//a", classToFind, "thumb"));
                    if (allLinksWithClassProductItems != null)
                    {
                        foreach (var item in allLinksWithClassProductItems)
                        {
                            ret1.Add(item.Attributes["href"].Value);
                        }
                    }
                    ret= ret1 as List<T>;
                }
              return ret;
            }
            set
            {

            }
            
        }
    }
}
