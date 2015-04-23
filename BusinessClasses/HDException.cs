using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClasses
{
    public class HDException
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string InnerErrMessage { get; set; }
    }
}
