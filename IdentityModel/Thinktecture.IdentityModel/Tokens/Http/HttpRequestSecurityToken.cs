﻿/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System.Net.Http;

namespace Thinktecture.IdentityModel.Tokens.Http
{
    public class HttpRequestSecurityToken : WrappedSecurityToken<HttpRequestMessage>
    {
        public HttpRequestSecurityToken(HttpRequestMessage request) : 
            base(request)
        { }
    }
}
