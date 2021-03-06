﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Add(new SyndicationFeedFormatter());

            GlobalConfiguration.Configuration.Formatters.Insert(0, new SyndicationFeedFormatter("text/html"));
        }
    }
}
