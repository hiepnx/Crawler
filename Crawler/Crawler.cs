using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SuperQueue;
using WebPageProcessor;

namespace Crawler
{
    public class Crawler<T>
    {
        public Crawler()
        {

        }
        public Crawler(IWebProcessor<T> WebProc, List<string> urls,int numberOfThread)
        {
            this.WebProcessor = WebProc;
            this.webUrls = urls;
            this.NumberOfThread = numberOfThread;
            _result = new List<T>(10000);
            this.queues = new SuperQueue<string>(numberOfThread,
                (url) => 
                {
                    WebProcessor.url = url;
                    if(WebProcessor.IsValidWebPage())
                    {
                        _result.AddRange(WebProcessor.Result);
                    }
                }
                );
            foreach (var item in urls)
            {
                queues.EnqueueTask(item);
            }
        }
        
        public IWebProcessor<T> WebProcessor { get; set; }

        public List<string> webUrls { get; set; }

        public int NumberOfThread { get; set; }

        public SuperQueue<string> queues { get; set; }

        private List<T> _result;
        public List<T> Result
        {
            get
            {
                while (queues.ProcessedCount < webUrls.Count())
                {
                    Thread.Sleep(100);
                    Console.WriteLine("Processing...({0}/{1})",queues.ProcessedCount,webUrls.Count);
                }
                return _result.Distinct().ToList();
            }
            
        }
        public void SetWebProcessor(IWebProcessor<T> proc)
        {
            this.WebProcessor = proc;
        }

    }
}
