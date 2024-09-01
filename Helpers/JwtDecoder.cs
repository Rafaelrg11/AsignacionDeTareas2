using System.IdentityModel.Tokens.Jwt;

namespace AsignacionDeTareas2.Helpers
{
    public class JwtDecoder
    {
        public static string DecodeJwt(string token, string claimName)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == claimName)?.Value;

                return claimValue;
            }
            catch
            {
                return null;
            }
        }
    }
}
