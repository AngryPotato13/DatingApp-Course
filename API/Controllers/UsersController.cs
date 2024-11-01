using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController   //this class now dervies from BaseApiController
{                                                                       
    [HttpGet]     //api/users    It gets this from the class name
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()   //Gets the list of users from AppUser
    {
        var users = await userRepository.GetMembersAsync();  //Calls GetUsersAsync() in UserRepository

        return Ok(users);
    }


    [HttpGet("{username}")] // api/users/(username)
    public async Task<ActionResult<MemberDto>> GetUsers(string username)   //gets the int id from the HttpGet above
    {
        var user = await userRepository.GetMemberAsync(username);    //Gets data from the Users table and stores it as user

        if (user == null) return NotFound();  //if user is null it returns a 404 not found

        return user;
    }
}
