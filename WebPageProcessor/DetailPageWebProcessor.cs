using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessClasses;
using HtmlAgilityPack;

namespace WebPageProcessor
{
    public class DetailPageWebProcessor<T>: IWebProcessor<T>     
        where T:class
    {
        public DetailPageWebProcessor()
        {
            page = new HtmlWeb();
        }
        public DetailPageWebProcessor(string _url)
        {
            page = new HtmlWeb();
            url = _url;
        }
        public HtmlWeb page;
        public HtmlDocument doc;
        public string _url;
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
            string classToFind = "exception-logo";
            var allElementsWithClassExceptionLogo = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", classToFind));
            return ret = (allElementsWithClassExceptionLogo == null) || (allElementsWithClassExceptionLogo.Count == 0) ? true : false;
        }

        public List<T> Result
        {
            get
            {
                List<T> ret = new List<T>();
                if (typeof(T) != typeof(Product)) return null;
                else
                {
                    Product ret1 = new Product();
                    ret1.Category = GetCategory();
                    ret1.Name = GetProductName();
                    ret1.CityId = GetCityId();
                    ret1.ShortDescription = GetShortDescription();
                    ret1.HightLights = GetHightlight();
                    ret1.Conditions = GetConditions();
                    ret1.Description = GetDescription();
                    ret1.ExpiredTime = GetExpiredTime();
                    ret1.DeliveryMethodId = GetDeliveryMethodId();
                    ret1.PriceBeforeDiscount = GetPriceBeforeDiscount();
                    ret1.PriceAfterDiscount = GetPriceAfterDiscount();
                    ret1.Supplier = GetSupplier();
                    ret1.ProductLink = GetProductLink();
                    List<string> imgs = GetSliderImageList();
                    if ((imgs.Count() > 0 ) && (imgs[0] != null)) ret1.ImageLink1 = imgs[0];
                    if ((imgs.Count() > 1) && (imgs[1] != null)) ret1.ImageLink2 = imgs[1];
                    if ((imgs.Count() > 2) && (imgs[2] != null)) ret1.ImageLink3 = imgs[2];
                    if ((imgs.Count() > 3) && (imgs[3] != null)) ret1.ImageLink4 = imgs[3];
                    if ((imgs.Count() > 4) && (imgs[4] != null)) ret1.ImageLink5 = imgs[4];
                    if ((imgs.Count() > 5) && (imgs[5] != null)) ret1.ImageLink6 = imgs[5];
                    ret.Add(ret1 as T);
                }
              return ret;
            }
            set
            {

            }
        }

        public string GetProductLink()
        {
            var nodes = doc.DocumentNode.SelectNodes(@"//link[@rel='canonical']");
            string link = (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].Attributes["href"].Value;
            return link;
        }

        private Supplier GetSupplier()
        {
            Supplier supplier = new Supplier();
            List<Address> addresses = new List<Address>();
            DeliveryMethod method = this.GetDeliveryMethod();
            if (method.Name.ToUpper().Contains("VOUCHER")) // the Supplier would not be the main company
            {
                //get the address of
                addresses = GetAddressList();
                supplier.Addresses = addresses;
            }
            else // the supplier is the main company
            {
                addresses.Add(new Address { City = this.GetCity(), ContactPhone = "04.7305 5707",Description = "HotDeal's headquarter",Name = "HotDeal",AddressDesc = "109 Trường Chinh",DistrictId = 6 });
                supplier.Addresses = addresses;
                supplier.SupplierName = "HotDeal";
                supplier.SupplierNameForAdmin = "Hot Deal";
                supplier.SupplierWebsite = "http://www.hotdeal.vn";
                supplier.Comment = "Our own company";
                supplier.Description = "HotDeal company";                
            }
            return supplier;
        }
        public string GetProductName()
        {
            string TitleClass = "product-title";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]",TitleClass));
            return (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
        }

        public Category GetCategory()
        {
            var nodes = doc.DocumentNode.SelectNodes(@"//span[@itemprop='category']");
            string CatName= (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
            return new Category { Name = CatName };
        }
        public int GetCityId()
        {
            int id = 1;
            var nodes = doc.DocumentNode.SelectNodes(@"//option[@selected='selected']");
            string CityCode =  (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].Attributes["value"].Value;
            if (CityCode == "440")
            {
                id = 1;
            }
            else if (CityCode == "437")
            {
                id = 50;
               
            }
            else
            {
                id = 64;
               
            }
            return id;
        }
        public Province GetCity()
        {
            var nodes = doc.DocumentNode.SelectNodes(@"//option[@selected='selected']");
            string CityCode = (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].Attributes["value"].Value;
            Province pr = new Province();
            if (CityCode == "440")
            {
                pr.Id = 1;
                pr.Name = "Hà Nội";
                pr.Type = "Thành Phố";
            }
            else if (CityCode == "437")
            {
                pr.Id = 50;
                pr.Name = "Hồ Chí Minh";
                pr.Type = "Thành Phố";
            }
            else
            {
                pr.Id = 64;
                pr.Name = "Tỉnh thành khác";
                pr.Type = "Tỉnh";
            }
            return pr;
        }
        public string GetShortDescription()
        {
            var nodes= doc.DocumentNode.SelectSingleNode("//meta[@name='description']");//.GetAttributeValue("co‌​ntent");
            return (nodes == null) ? String.Empty : nodes.Attributes["content"].Value;
        }
        public string GetHightlight()
        {
            string className = "product-conditions";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", className));
            return (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
        }

        public string GetConditions()
        {
            string className = "product-feature";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", className));
            return (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
        }

        public string GetDescription()
        {
            string className = "product-description";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", className));
            return (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
        }

        public DateTime GetExpiredTime()
        {
            return DateTime.Now.AddDays(7);
        }
        public DeliveryMethod GetDeliveryMethod()
        {
            string TypeClass = "product-type";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", TypeClass));
            string DeliveryMethodName =  (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
            int Id = 0;
            if (DeliveryMethodName.ToUpper().Contains("VOUCHER")) Id = 1;
            else
            {
                Id = 2;
            }
            return new DeliveryMethod {Id= Id, Name = DeliveryMethodName };
        }
        public int GetDeliveryMethodId()
        {
            string TypeClass = "product-type";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", TypeClass));
            string DeliveryMethodName = (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
            int Id = 0;
            if (DeliveryMethodName.ToUpper().Contains("VOUCHER")) Id = 1;
            else
            {
                Id = 2;
            }
            return Id;
        }
        public decimal GetPriceBeforeDiscount()
        {
            string ListPriceClass = "list-price";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", ListPriceClass));
            string s = (nodes == null) || (nodes.Count == 0) ? String.Empty : nodes[0].InnerText;
            var doubleArray = Regex.Split(s, @"[^0-9\.]+").Where(c => c != "." && c.Trim() != "");
            string number = doubleArray.Where(i => i.Trim().Length > 0).FirstOrDefault();
            number = number.Replace(".",String.Empty);
            return decimal.Parse(number);
        }
        public decimal GetPriceAfterDiscount()
        {
            string ListPriceClass = "sell-price";
            var nodes = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", ListPriceClass));
           string s = (nodes == null) || (nodes.Count == 0) ? "0": nodes[0].InnerText;
           var doubleArray = Regex.Split(s, @"[^0-9\.]+").Where(c => c != "." && c.Trim() != "");
           string number = doubleArray.Where(i => i.Trim().Length > 0).FirstOrDefault();
           number = number.Replace(".", String.Empty);
           return decimal.Parse(number);

        }
        
        public List<string> GetSliderImageList()
        {
            var ret1 = new List<string>();
            string classToFind = "sliders-wrap-inner";
            var allLinksWithClassProductItems = doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]//li//img", classToFind));
            if (allLinksWithClassProductItems != null)
            {
                foreach (var item in allLinksWithClassProductItems)
                {
                    ret1.Add(item.Attributes["src"].Value);
                }
            }
            return ret1;
        }
        public List<Address> GetAddressList()
        {
            List<Address> ret = new List<Address>();
            try
            {
                string classToFind = "address-box";
                var allLinksWithClassAddressBoxes = doc.DocumentNode.SelectNodes(string.Format("//*[@class='{0}']", classToFind));
                foreach (var item in allLinksWithClassAddressBoxes)
                {

                    string add = item.ChildNodes.Where(i => i.Attributes.Contains("class") && i.Attributes["class"].Value == "address").FirstOrDefault().InnerText;
                    string phone = item.ChildNodes.Where(i => i.Attributes.Contains("class") && i.Attributes["class"].Value == "phone").FirstOrDefault().InnerText;
                    string MapInfo = String.Empty;
                    string mapInfoIndicator = "https://maps.google.com/maps?q=" + add;
                    IEnumerable<HtmlNode> links = doc.DocumentNode.SelectNodes(string.Format("//a[starts-with(@href, '{0}')]", mapInfoIndicator));
                    if ((links != null) && (links.Count() > 0))
                    {
                        MapInfo = links.First().Attributes["href"].Value;
                    }
                    ret.Add(new Address { ContactPhone = phone, MapInfo = MapInfo, AddressDesc = add,Name = add });
                }
            }
            catch (Exception ex)
            {

            }
            return ret;
        }
    }
}
