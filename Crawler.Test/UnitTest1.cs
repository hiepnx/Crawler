using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPageProcessor;

namespace Crawler.Test
{
    [TestClass]
    public class HomePageTest
    {
        [TestMethod]
        public void TestValidWebPageValid()
        {
            IWebProcessor<string> webProc = new WebPageProcessor.HomePageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/?page=10");
            Assert.AreEqual(webProc.IsValidWebPage(), true);
        }

        [TestMethod]
        public void TestValidWebPageInValid()
        {
            IWebProcessor<string> webProc = new WebPageProcessor.HomePageWebProcessor<string>("http://www.hotdeal.vn/ha-noi/?page=100");
            Assert.AreEqual(webProc.IsValidWebPage(), false);
        }

        [TestMethod]
        public void TestResult()
        {
            IWebProcessor<List<string>> webProc = new WebPageProcessor.HomePageWebProcessor<List<string>>("http://www.hotdeal.vn/ha-noi/?page=10");
            Assert.AreEqual(webProc.Result, false);
        }
       
    }
}
