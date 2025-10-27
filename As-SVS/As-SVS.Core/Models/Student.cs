using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class Student
{
    public int Id { get; set; }

    public string applicationUserId { get; set; } = null!;

    public int GradeId { get; set; }

    public string MotherName { get; set; } = null!;

    public double? Average { get; set; }

    public string StudentCode { get; set; } = null!;

    public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual Grade Grade { get; set; } = default!;

    public virtual ApplicationUser applicationUser { get; set; } = default!;
}
