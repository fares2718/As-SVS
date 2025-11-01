using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string applicationUserId { get; set; } = null!;

    public string? Specialization { get; set; }

    public string TeacherCode { get; set; } = null!;

    public string? Qualifications { get; set; }

    public int GradesId { get; set; }

    public string? Feedbacks { get; set; }

    public decimal Salary { get; set; }

    public virtual Grade Grades { get; set; } = default!;

    public virtual ApplicationUser applicationUser { get; set; } = default!;
}
