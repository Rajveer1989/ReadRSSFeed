﻿using System.Web;
using System.Web.Mvc;

namespace Read_RSS_Feed
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
