/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Thinktecture.IdentityModel.Http
{
    public class RequireHttpsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                var forbiddenResponse =
                    request.CreateErrorResponse(HttpStatusCode.Forbidden, "HTTPS Required");

                forbiddenResponse.ReasonPhrase = "HTTPS Required";
                return Task.FromResult<HttpResponseMessage>(forbiddenResponse);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
