using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = string.Empty; //No Uppercase n in username since that how it is in the database

    [Required]
    public string Password { get; set; } = string.Empty;
}
