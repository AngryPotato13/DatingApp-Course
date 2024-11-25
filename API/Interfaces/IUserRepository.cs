using System;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);   //Takes an AppUser as a paramater and names it user
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    Task<MemberDto?> GetMemberAsync(string username);

}
