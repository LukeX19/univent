using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Univent.Application.Options;

namespace Univent.Application.Services
{
    public class IdentityService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly byte[] _key;

        public IdentityService(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
            _key = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);
        }

        private SecurityTokenDescriptor GetTokenDescriptor(ClaimsIdentity claimsIdentity)
        {
            return new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Expires = DateTime.Now.AddHours(2),
                Audience = _jwtSettings.Audiences[0],
                Issuer = _jwtSettings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
        }

        public JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();

        public SecurityToken CreateSecurityToken(ClaimsIdentity claimsIdentity)
        {
            var tokenDescriptor = GetTokenDescriptor(claimsIdentity);
            return TokenHandler.CreateToken(tokenDescriptor);
        }

        public string WriteToken(SecurityToken token)
        {
            return TokenHandler.WriteToken(token);
        }
    }
}
