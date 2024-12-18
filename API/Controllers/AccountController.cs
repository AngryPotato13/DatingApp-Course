using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper) : BaseApiController
{
    [HttpPost("register")] //account(Name of the controller)/register
                           //This is how we get to the endpoint from the client
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)  //Uses registerDto and returns a UserDto
    {

        if(await UserExists(registerDto.Username)) return BadRequest("Username is taken");  //does UserExists and returns if its already taken

        // using var hmac = new HMACSHA512();   //used to encrypt text

        var user = mapper.Map<AppUser>(registerDto);  //maps into an AppUser from a registerDto

        user.UserName = registerDto.Username.ToLower();
        // user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));   //this hashes the password
        // user.PasswordSalt = hmac.Key;    //This is used to scramble the hashed password

        // context.Users.Add(user);
        // await context.SaveChangesAsync();  // saves the info (context) into the database (Users)

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if(!result.Succeeded) return BadRequest(result.Errors);

        return new UserDto   //returns the UserDto which contains the username and the token
        {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user),
            KnownAs = user.KnownAs,
            Gender = user.Gender
        };
    }

    [HttpPost("login")]  //account(Name of the controller)/login
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)  //Uses loginDto and returns a UserDto
    {
        var user = await userManager.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.NormalizedUserName == loginDto.Username.ToUpper());        //returns first user that matches in database or null
        if (user == null || user.UserName == null) return Unauthorized("Invalid username");   //does this if the username dosen't exist

        var result = await userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!result) return Unauthorized();

        // using var hmac = new HMACSHA512(user.PasswordSalt);

        // var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        // for (int i = 0; i < computedHash.Length; i++)    //compares the computed hash with the hash stored in the database
        // {
        //     if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        // }

        return new UserDto
        {
            Username = user.UserName,
            KnownAs = user.KnownAs,
            Token = await tokenService.CreateToken(user),
            PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
            Gender = user.Gender
        };
    }


    private async Task<bool> UserExists(string username)  //checks if username is alredy taken
    {
        return await userManager.Users.AnyAsync(x => x.NormalizedUserName == username.ToUpper()); //UserName is from above and username is from the database
    }
}
