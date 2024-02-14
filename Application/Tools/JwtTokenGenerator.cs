using Application.Dtos;
using Application.Features.Mediator.Authentication.CheckUser;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenDto GeneratorToken(CheckUserResult result)
        {
            var claims = new List<Claim>();
            if(!string.IsNullOrWhiteSpace(result.Role))
                claims.Add(new Claim(ClaimTypes.Role,result.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id));
            if (!string.IsNullOrWhiteSpace(result.UserName))
                claims.Add(new Claim("username",result.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signinCreadentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,
                audience:JwtTokenDefaults.ValidAuidience,
                claims:claims,
                notBefore:DateTime.UtcNow,
                expires:expireDate,
                signingCredentials:signinCreadentials);

            JwtSecurityTokenHandler tokenHandler=new JwtSecurityTokenHandler();
            return new TokenDto(tokenHandler.WriteToken(token),expireDate);
        }
    }
}
