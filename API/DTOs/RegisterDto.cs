using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = string.Empty;    //No Uppercase n in username since that how it is in the database

    [Required] public string? KnownAS { get; set; }

    [Required] public string? Gender { get; set; }

    [Required] public string? DateOfBirth { get; set; }

    [Required] public string? City { get; set; }

    [Required] public string? Country { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; } = string.Empty;
}
