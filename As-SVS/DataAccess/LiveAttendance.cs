using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class LiveAttendance
{
    public int StudentId { get; set; }

    public int SessionId { get; set; }

    public TimeOnly JoinedAt { get; set; }

    public TimeOnly? LeftAt { get; set; }

    public virtual LiveSession Session { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
