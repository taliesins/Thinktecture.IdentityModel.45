/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

using System.Net.Http;

namespace Thinktecture.IdentityModel.Http.Cors.WebApi
{
    public class WebApiHttpResponse : IHttpResponseWrapper
    {
        readonly HttpResponseMessage _response;

        public WebApiHttpResponse(HttpResponseMessage response)
        {
            this._response = response;
        }

        public void AddHeader(string name, string value)
        {
            this._response.Headers.Add(name, value);
        }
    }
}
