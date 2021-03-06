﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Net.Http.Headers;

[assembly: OwinStartup("LoanSvcApi",typeof(LoanSvc.Startup))]

namespace LoanSvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new
                    {
                        id = RouteParameter.Optional
                    }
                );
            app.UseWebApi(config);
        }
    }
}
