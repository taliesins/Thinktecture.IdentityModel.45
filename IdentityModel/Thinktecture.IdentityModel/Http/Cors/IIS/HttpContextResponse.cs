/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

using System.Web;

namespace Thinktecture.IdentityModel.Http.Cors.IIS
{
    public class HttpContextResponse : IHttpResponseWrapper
    {
        readonly HttpResponseBase _response;
        public HttpContextResponse(HttpResponseBase response)
        {
            this._response = response;
        }

        public void AddHeader(string name, string value)
        {
            _response.AddHeader(name, value);
        }
    }
}
