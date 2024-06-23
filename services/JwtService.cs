using System.IdentityModel.Tokens.Jwt;

namespace MyProject.Services;

public static class JwtService {

    public static string GetJwtClaim(string token, string claimType) {
        var handler = new JwtSecurityTokenHandler();
        var tokenS = handler.ReadToken(token) as JwtSecurityToken;
        
        return tokenS?.Claims.FirstOrDefault(c => c.Type == claimType)?.Value ?? string.Empty;
    }

}
