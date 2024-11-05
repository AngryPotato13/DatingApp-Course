using System;

namespace API.DTOs;

public class MemberDto
{
    public int Id { get; set; }  //this is the property for the id of the user

    public string? Username { get; set; }  //required means it is required for it to be entered into the table

    public int Age { get; set; }

    public string? PhotoUrl { get; set; }

    public string? KnownAs { get; set; }

    public DateTime Created { get; set; }
    
    public DateTime LastActive { get; set; }

    public string? Gender { get; set; }

    public string?  Introduction { get; set; }

    public string? Interests { get; set; }

    public string? LookingFor { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
    public List<PhotoDto>? Photos { get; set; }   //Calls PhotoDto.cs
}
