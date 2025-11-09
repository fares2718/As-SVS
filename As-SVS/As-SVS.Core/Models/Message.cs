namespace As_SVS.Core.Models;

public partial class Message
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string applicationUserId { get; set; } = null!;

    public string MessageContent { get; set; } = null!;
    public DateOnly CreatedAt { get; set; }

    public virtual ApplicationUser applicationUser { get; set; } = default!;

    public virtual Room Room { get; set; } = default!;
}
