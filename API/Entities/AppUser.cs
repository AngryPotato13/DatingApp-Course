using System;
using API.Extensions;

namespace API.Entities;

public class AppUser     //this is the table and the properties below are all columns in the table
{
    public int Id { get; set; }  //this is the property for the id of the user

    public required string UserName { get; set; }  //required means it is required for it to be entered into the table

    public byte[] PasswordHash { get; set; } = [];  //this stores the password hash

    public byte[] PasswordSalt { get; set; } = [];  //this stores the password salt

    public DateOnly DateOfBirth { get; set; }

    public required string KnownAs { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    
    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public required string Gender { get; set; }

    public string? Introduction { get; set; }

    public string? Interests { get; set; }

    public string? LookingFor { get; set; }

    public required string City { get; set; }

    public required string Country { get; set; }
    public List<Photo> Photos { get; set; } = [];      //Uses Photo.cs

    // public int GetAge()
    // {
    //     return DateOfBirth.CalculateAge();   //uses Calculate age from DateTimeExtension.cs
    // }
}
