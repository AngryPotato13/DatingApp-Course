using System.Security.Claims;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService) : BaseApiController   //this class now dervies from BaseApiController
{     
                                                               
    [HttpGet]     //api/users    It gets this from the class name
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery]UserParams userParams)   //Gets the list of users from AppUser
    {
        userParams.CurrentUsername = User.GetUserName();
        var users = await unitOfWork.UserRepository.GetMembersAsync(userParams);  //Calls GetUsersAsync() in unitOfWork.UserRepository

        Response.AddPaginationHeader(users);

        return Ok(users);
    }


    [HttpGet("{username}")] // api/users/(username)
    public async Task<ActionResult<MemberDto>> GetUser(string username)   //gets the int id from the HttpGet above
    {
        var user = await unitOfWork.UserRepository.GetMemberAsync(username);    //Gets data from the Users table and stores it as user

        if (user == null) return NotFound();  //if user is null it returns a 404 not found

        return user;
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
    {
        var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUserName());

        if (user == null) return BadRequest("Could not find user");

        mapper.Map(memberUpdateDto, user);   //This adds the information from memberUpdateDto to the user in the database

        if (await unitOfWork.Complete()) return NoContent();

        return BadRequest("Failed to update the user");
    }

    [HttpPost("add-photo")]
    public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
    {
        var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUserName());

        if(user == null) return BadRequest("Cannot update user");

        var result = await photoService.AddPhotoAsync(file);

        if (result.Error != null) return BadRequest(result.Error.Message);

        var photo = new Photo
        {
            Url = result.SecureUrl.AbsoluteUri,
            PublicId = result.PublicId
        };

        if (user.Photos.Count == 0) photo.IsMain = true;

        user.Photos.Add(photo);

        if (await unitOfWork.Complete()) return CreatedAtAction(nameof(GetUser), new {username = user.UserName}, mapper.Map<PhotoDto>(photo));  //returns a created status

        return BadRequest("Problem adding photo");
    }

    [HttpPut("set-main-photo/{photoId:int}")]
    public async Task<ActionResult> SetMainPhoto(int photoId)
    {
        var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUserName());

        if (user == null) return BadRequest("Could not find user");

        var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

        if (photo == null || photo.IsMain) return BadRequest("Cannot use this as main photo");

        var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
        if (currentMain != null) currentMain.IsMain = false;
        photo.IsMain = true;

        if (await unitOfWork.Complete()) return NoContent();

        return BadRequest("Problem setting main photo");

    }

    [HttpDelete("delete-photo/{photoId:int}")]
    public async Task<ActionResult> DeletePhoto(int photoId)
    {
        var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUserName());

        if (user == null) return BadRequest("User not found");

        var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

        if (photo == null || photo.IsMain) return BadRequest("This photo cannot be deleted");

        if (photo.PublicId != null)
        {
            var result = await photoService.DeletePhotoAsync(photo.PublicId);
            if (result.Error != null) return BadRequest(result.Error.Message);
        }

        user.Photos.Remove(photo);

        if (await unitOfWork.Complete()) return Ok();

        return BadRequest("Problem deleting photo");
    }

}
