using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class Enrolment
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public DateOnly? EnrolmentDate { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
