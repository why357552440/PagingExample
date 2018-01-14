using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ViewResultObj
    {
        public int BS { get; set; }
        public string Msg { get; set; }
        public object rows { get; set; }

        public int count { get; set; }
    }
}