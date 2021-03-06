﻿using System;
using System.Web;
#if RELEASE45
using System.Web.Mvc;
#endif
namespace DigitalTechnologies.RemoveHeaders
{
    public class RemoveHeadersModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
#if RELEASE45
            MvcHandler.DisableMvcResponseHeader = true;
#endif
        }

        private void BeginRequest(object sender, EventArgs args)
        {
            // Remove the "Server" HTTP Header from response
            var app = sender as HttpApplication;
            if (app == null || app.Context == null)
            {
                return;
            }

            var headers = app.Context.Response.Headers;
            headers.Remove("Server");
        }

        public void Dispose()
        {
        }
    }
}
