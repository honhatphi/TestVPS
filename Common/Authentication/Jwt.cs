﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trackify.Data.Type;

namespace Trackify.Common.Authentication;
public class Jwt(IOptions<JwtOptions> options)
{
    public string GenerateToken(User user)
    {
        var key = SecurityKey(options.Value.Key);

        var token = new JwtSecurityToken
        (
            claims: [new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())],
            signingCredentials: new(key, SecurityAlgorithms.HmacSha256Signature),
            expires: DateTime.UtcNow.AddYears(1)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static SymmetricSecurityKey SecurityKey(string key) => new(Encoding.ASCII.GetBytes(key));
}
