using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")] //account(Name of the controller)/register
                           //This is how we get to the endpoint from the client
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)  //Uses registerDto and returns a UserDto
    {

        if(await UserExists(registerDto.Username)) return BadRequest("Username is taken");  //does UserExists and returns if its already taken

        using var hmac = new HMACSHA512();   //used to encrypt text

        var user = new AppUser
        {
            UserName = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),   //this hashes the password
            PasswordSalt = hmac.Key    //This is used to scramble the hashed password
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();  // saves the info (context) into the database (Users)

        return new UserDto   //returns the UserDto which contains the username and the token
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]  //account(Name of the controller)/login
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)  //Uses loginDto and returns a UserDto
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());        //returns first user that matches in database or null
        if (user == null) return Unauthorized("Invalid username");   //does this if the username dosen't exist

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)    //compares the computed hash with the hash stored in the database
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        }

        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }


    private async Task<bool> UserExists(string username)  //checks if username is alredy taken
    {
        return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()); //UserName is from above and username is from the database
    }
}
