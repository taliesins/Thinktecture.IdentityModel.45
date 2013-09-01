using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace Thinktecture.IdentityModel.Tokens
{
    class JwtSecurityTokenHandlerWrapper : JwtSecurityTokenHandler
    {
        readonly TokenValidationParameters _validationParams;

        public JwtSecurityTokenHandlerWrapper(TokenValidationParameters validationParams, Dictionary<string, string> inboundClaimTypeMap = null)
        {
            _validationParams = validationParams;

            if (inboundClaimTypeMap != null)
            {
                InboundClaimTypeMap = inboundClaimTypeMap;
            }
        }

        public override System.Collections.ObjectModel.ReadOnlyCollection<System.Security.Claims.ClaimsIdentity> ValidateToken(SecurityToken token)
        {
            var jwt = token as JwtSecurityToken;
            var list = new List<ClaimsIdentity>(this.ValidateToken(jwt, _validationParams).Identities);
            return list.AsReadOnly();
        }
    }
}
