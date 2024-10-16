using System;

namespace API.Entities;

public class AppUser     //this is the table and the properties below are all columns in the table
{
    public int Id { get; set; }  //this is the property for the id of the user

    public required string UserName { get; set; }  //required means it is required for it to be entered into the table

    public required byte[] PasswordHash { get; set; }

    public required byte[] PasswordSalt { get; set; }
}
