﻿using System.Web;
using System.Web.Mvc;

namespace JSE.EmployeeLeaveSystem.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
