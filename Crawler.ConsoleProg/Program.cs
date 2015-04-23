using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler;
using WebPageProcessor;
using BusinessClasses;
using HDBusinessLayer;

namespace Crawler.ConsoleProg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HotdealDBContext>());
            Database.SetInitializer(new HotdealDBInitializer());

            HDBusiness hb = new HDBusiness();
            string url = "http://www.hotdeal.vn/ha-noi/spa-lam-dep/massage-chan-body-korean-kem-an-banh-va-uong-nuoc-qua-tuoi-tai-foot-massage-87-quan-hoa-81978.html";

            string baseUrl = "http://www.hotdeal.vn/ha-noi/?page=";
            string webName = "http://www.hotdeal.vn";
            List<string> urls = new List<string>();
            for (int i = 1; i < 25; i++)
            {
                urls.Add(baseUrl + i.ToString());
            }
            List<ProductLink> productLinks = new List<ProductLink>();
            Crawler<string> Crawler = new Crawler<string>(new HomePageWebProcessor<string>(), urls, 3);
            List<string> ret = Crawler.Result;
            var oldProductLinkCodes = hb.GetAllProductCode();
            var oldProductLinksDict = oldProductLinkCodes.Select((s, i) => new { s, i }).ToDictionary(x => x.s, x => x.i);

            foreach (var item in ret)
            {
                var pl = new ProductLink(webName + item);
                if (!oldProductLinksDict.Keys.Contains(pl.ProductCode.Value))
                {
                    productLinks.Add(new ProductLink(webName + item));
                }
            }
             hb.InsertProductLinkRange(productLinks);
            List<string> AllProductLinks = hb.GetAllProductLink();
            List<string> ProductUrls = new List<string>();
            ProductUrls.AddRange(AllProductLinks);
           // ProductUrls.Add("http://www.hotdeal.vn/ha-noi/thoi-trang-nu/ao-han-quoc-xu-huong-he-2014-78031.html");
           // ProductUrls.Add("http://www.hotdeal.vn/ha-noi/thoi-trang-nu/dam-cong-so-phong-cach-hien-dai-83212.html");
            Crawler<Product> ProductCrawler = new Crawler<Product>(new WebPageProcessor.DetailPageWebProcessor<Product>(), ProductUrls, 1);
            List<Product> products = new List<Product>();
              products.AddRange( ProductCrawler.Result);
          //adjust the data before updateting
              foreach (var item in products)
              {
                  //adjust the CategoryId
                  item.CategoryId = hb.GetCategoryByName(item.Category.Name);
                  item.Category = null;
                  //adjust the Supplier
                  //if ((item.Supplier.SupplierName == null) || (item.Supplier.SupplierName.Trim().Length == 0))
                  //{
                      item.SupplierId = hb.GetSupplierIdByAddress(item.Supplier.Addresses);
                      item.Supplier = null;
                 // }
                  if (item.CityId == null)
                  {
                      Console.WriteLine(item.Name);
                  }
                  Console.WriteLine(item.Name);
              }
            hb.InsertProductRange(products);
              //for (int i = 0; i < products.Count; i++)
              //{
              //    Console.WriteLine(i);
              //    hb.InsertProduct(products[i]);
              //}
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Xong");
            Console.ReadLine();
           // Console.WriteLine(ret.Count);
            
        }

        
    }
}
