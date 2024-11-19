using System;

namespace API.DTOs;

public class MessageDto      //This is what gets sent back to the client
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public required string SenderUsername { get; set; }

    public required string SenderPhotoUrl { get; set; }

    public int RecipientIdd { get; set; }

    public required string RecipientUsername { get; set; }

    public required string RecipientPhotoUrl { get; set; }

    public required string Content { get; set; }

    public DateTime? DateRead { get; set; }

    public DateTime MessageSent { get; set; }

}
