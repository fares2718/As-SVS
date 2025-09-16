using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class Student
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int GradeId { get; set; }

    public string MotherName { get; set; } = null!;

    public double? Average { get; set; }

    public string StudentCode { get; set; } = null!;

    public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual Grade Grade { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
