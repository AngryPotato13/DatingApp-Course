using System;

namespace API.Entities;

public class UserLike
{
    public AppUser SourceUser { get; set; } = null!;    //user thats doing the liking

    public int SourceUserId { get; set; }

    public AppUser TargetUser { get; set; } = null!;   //user thats getting liked

    public int TargetUserId { get; set; }
}
