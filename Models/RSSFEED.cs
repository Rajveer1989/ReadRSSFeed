using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Read_RSS_Feed.Models
{
    public class RSSFEED
    {
        public int ID { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        
        public string title { get; set; }
    }
}