using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class StudentRoom
{
    public int StudentId { get; set; }

    public int RoomId { get; set; }

    public DateOnly JoinDate { get; set; }

    public virtual Room Room { get; set; } = null!;
}
