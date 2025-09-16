using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class LiveSession
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public int TeacherId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public DateOnly Date { get; set; }

    public string MeetingUrl { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
