using Microsoft.IdentityModel.Tokens;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{

        public class JWTService : IJWTService
        {
            private readonly IJWTRepository reposiytory;
            public JWTService(IJWTRepository reposiytory)
            {
                this.reposiytory = reposiytory;
            }

            public string Auth(User user)
            {
                var result = reposiytory.Auth(user);

                if (result == null)
                {
                    return null;
                }
                else
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hello oday ,hello roqaya algorthem enchode(key in singniger)"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
                    var claims = new List<Claim>

                {
                new Claim("email", result.Email),
                new Claim("roleid", result.Roleid.ToString()),
                new Claim("userid", result.Userid.ToString()),
                new Claim("name", result.Username.ToString())

                };

                    var tokeOptions = new JwtSecurityToken(
                                        claims: claims,
                                        expires: DateTime.Now.AddHours(24),
                                        signingCredentials: signinCredentials
                                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return tokenString;

                }
            }
        }
    }
