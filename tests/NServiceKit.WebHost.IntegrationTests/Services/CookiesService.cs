﻿using System.Collections.Generic;
using System.Linq;
using NServiceKit.ServiceHost;

namespace NServiceKit.WebHost.IntegrationTests.Services
{
    [Route("/cookies")]
    public class Cookies : IReturn<CookiesResponse>
    { }

    public class CookiesResponse
    {
        public List<string> RequestCookieNames { get; set; }
    }

    public class CookiesService : ServiceInterface.Service
    {
        public CookiesResponse Any(Cookies c)
        {
            var response = new CookiesResponse
            {
                RequestCookieNames = Request.Cookies.Keys.ToList(),
            };
            return response;
        }
    }
}