using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebPageProcessor
{
    public interface IWebProcessor<T>
    {
        bool IsValidWebPage();
        List<T> Result { get; set; }
        string url { get; set; }
    }
}
