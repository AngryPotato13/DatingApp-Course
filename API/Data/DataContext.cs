using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
                                                //This class was used when creating a migration
public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }  //used to save instances of AppUser(Entities folder)
                                               //it will give us a table called Users the id being the primary key
}                                              
