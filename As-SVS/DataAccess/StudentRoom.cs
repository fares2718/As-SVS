using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class StudentRoom
{
    public int StudentId { get; set; }

    public int RoomId { get; set; }

    public DateOnly JoinDate { get; set; }

    public virtual Room Room { get; set; } = null!;
}
