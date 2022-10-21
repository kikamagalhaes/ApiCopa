using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System;
using apideteste.models;
using Newtonsoft.Json.Linq;

namespace apideteste.Services
{
    public class Token
    {
        public static string CriarToken(Admin adm)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            var key = Encoding.ASCII.GetBytes(jAppSettings["Secret"].ToString());
            var expirationTime = Convert.ToInt32(jAppSettings["TempoExpiracao"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.Name, adm.Nome),
                        new Claim(ClaimTypes.Email,adm.Email),
                        new Claim(ClaimTypes.Role, adm.Perm),
                    }),
                
                Expires = DateTime.UtcNow.AddMinutes(expirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
