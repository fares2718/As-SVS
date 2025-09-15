using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Annoucement
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public string Title { get; set; } = null!;

    public string Annoucement1 { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
