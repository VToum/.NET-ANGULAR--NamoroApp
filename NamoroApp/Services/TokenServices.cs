using Microsoft.IdentityModel.Tokens;
using NamoroApp.Interface;
using NamoroApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NamoroApp.Services
{
    public class TokenServices : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenServices(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CriarToken(UsuarioApp usuarioApp)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuarioApp.Login)
            };

            var creditoToken = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var descricaoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creditoToken
            };

            var manipularToken = new JwtSecurityTokenHandler();

            var token = manipularToken.CreateToken(descricaoToken);

            return manipularToken.WriteToken(token);
        }
    }
}
