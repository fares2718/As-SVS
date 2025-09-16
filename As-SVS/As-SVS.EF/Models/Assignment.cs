using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class Assignment
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public string Title { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public DateOnly DueDate { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateOnly UpdatedDue { get; set; }

    public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    public virtual Course Course { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
