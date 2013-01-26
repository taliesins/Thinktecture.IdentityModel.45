﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class General
    {
        [TestMethod]
        public void NoCredential()
        {
            var client = new HttpClient(Factory.GetDefaultServer());
            var request = Factory.GetDefaultRequest();

            var response = client.SendAsync(request).Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
