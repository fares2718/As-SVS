using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Message
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public int PersonId { get; set; }

    public string MessageContent { get; set; } = null!;

    public string? Attachments { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateOnly? EditedAt { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
