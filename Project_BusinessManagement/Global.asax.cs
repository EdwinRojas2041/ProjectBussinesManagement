﻿using Project_BusinessManagement.App_Start;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IBusiness.Common;
using InstancesBll;

namespace Project_BusinessManagement
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.Configure(GlobalFilters.Filters);
            RouteConfig.Configure(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var lIfacade = RegisterInterfaces.RegisTerFacade();           
            FacadeProvider.FacadeProviderInstance = lIfacade.RegisterFacadeProvider();
        }

    protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = this.Server.GetLastError();
            if (ex != null)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}