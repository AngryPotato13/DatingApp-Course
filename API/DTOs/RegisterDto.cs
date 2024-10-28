using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public required string Username { get; set; } //No Uppercase n in username since that how it is in the database

    [Required]
    public required string Password { get; set; }
}
