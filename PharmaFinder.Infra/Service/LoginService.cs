using Microsoft.IdentityModel.Tokens;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using PharmaFinder.Infra.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class LoginService:ILoginService
    {

            private readonly ILoginRepository loginRepository;

            public LoginService(ILoginRepository loginRepository)
            {
                this.loginRepository = loginRepository;
            }
            public string GenerateToken(User users)// return token value 
                  {
                var identity = loginRepository.GenerateToken(users); // return roleid and username if they match

            if (identity == null)
            {

                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloTraineesinwebapicourse@34567"));//Encode header + payload of token 
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, identity.Username),
                   new Claim(ClaimTypes.Role, identity.Roleid.ToString())
                };

                var tokeOptions = new JwtSecurityToken(
                                    claims: claims,
                                     expires: DateTime.Now.AddHours(24),
                                     signingCredentials: signinCredentials
                        );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);//
                return tokenString;

            }
        }

    }
}
