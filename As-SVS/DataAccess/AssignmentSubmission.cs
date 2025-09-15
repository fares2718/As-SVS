using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class AssignmentSubmission
{
    public int Id { get; set; }

    public int AssignmentId { get; set; }

    public int StudentId { get; set; }

    public string FileUrl { get; set; } = null!;

    public string? Feedback { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
