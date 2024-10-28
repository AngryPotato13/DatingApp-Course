using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController   //this class now dervies from BaseApiController
{                                                                       
    [AllowAnonymous]  //alows anonymous users to access this end point
    [HttpGet]     //api/users    It gets this from the class name
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()   //Gets the list of users from AppUser
    {
        var users = await context.Users.ToListAsync();  //Gets data from the Users table and stores it as users

        return users;
    }

    [Authorize]
    [HttpGet("{id:int}")] // api/users/(id number)
    public async Task<ActionResult<AppUser>> GetUsers(int id)   //gets the int id from the HttpGet above
    {
        var user = await context.Users.FindAsync(id);    //Gets data from the Users table and stores it as user

        if (user == null) return NotFound();  //if user is null it returns a 404 not found

        return user;
    }
}
