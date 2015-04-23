using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPageProcessor;

namespace Crawler.Test
{
    /// <summary>
    /// Summary description for DetailPageTest
    /// </summary>
    [TestClass]
    public class DetailPageTest
    {

        [TestMethod]
        public void TestIsValidPageTrue()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual(true,proc.IsValidWebPage());
        }

        [TestMethod]
        public void TestIsValidPageFalse()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-7804.html");
            Assert.AreEqual(false, proc.IsValidWebPage());
        }

        [TestMethod]
        public void TestGetProductName()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("Vé Bơi 7 Lượt Tại Bể Bơi Olympia", proc.GetProductName().Trim());
        }

        [TestMethod]
        public void TestGetCategory()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("Đào Tạo & Giải Trí", proc.GetCategory().Name.Trim());
        }

        [TestMethod]
        public void TestGetCity()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("440", proc.GetCity().Name.Trim());
        }

        [TestMethod]
        public void TestShortDescription()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("440", proc.GetShortDescription().Trim());
        }

        [TestMethod]
        public void TestHightlight()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("440", proc.GetHightlight().Trim());
        }

        [TestMethod]
        public void TestConditions()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("440", proc.GetConditions().Trim());
        }

        [TestMethod]
        public void TestDescription()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("440", proc.GetDescription().Trim());
        }

        [TestMethod]
        public void TestDeliveryMethod()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual("GIAO VOUCHER", proc.GetDeliveryMethod().Name.Trim().ToUpper());
        }

        [TestMethod]
        public void TestPriceBeforeDiscount()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual((decimal)490.000, proc.GetPriceBeforeDiscount());
        }

        [TestMethod]
        public void TestPriceAfterDiscount()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/dao-tao-giai-tri/ve-boi-7-luot-tai-be-boi-olympia-78044.html");
            Assert.AreEqual((decimal)210.000, proc.GetPriceAfterDiscount());
        }

        [TestMethod]
        public void TestSliderImageList()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/an-uong/combo-ga-danh-cho-2-nguoi-tai-bbq-chicken-63364.html");
            Assert.AreEqual("440", proc.GetSliderImageList());
        }
        [TestMethod]
        public void TestAddresses()
        {
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/spa-lam-dep/giam-beo-cong-nghe-cao-tai-87-quan-hoa-81785.html");
            Assert.AreEqual("440", proc.GetAddressList());
        }
        [TestMethod]
        public void TestProductLink()
        {
            string link = "http://www.hotdeal.vn/ha-noi/me-be/meo-tom-biet-noi-81977.html";
            DetailPageWebProcessor<string> proc = new DetailPageWebProcessor<string>(link);
            Assert.AreEqual(link,proc.GetProductLink());
        }
    }
}
