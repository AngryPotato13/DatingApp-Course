using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception ("Cannot access tokenKey from appsettings");   //if token key is null it throws the exception
        if (tokenKey.Length < 64) throw new Exception ("Your token key needs to be longer");  //Makes sure the token key is long enough
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));   //Key is created here and symmetric security key uses the same key for both encryption and decryption
                                                                                //TokenKey is stored in appsettings.json

        var claims = new List<Claim>   //defines the users claims
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName)
        };

        var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor   //defines the descriptors
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),    //key is valid for 7 days
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);  //returns the json web token
    }
}
