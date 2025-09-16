using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public string Specialization { get; set; } = null!;

    public string NationalNumber { get; set; } = null!;

    public string TeacherCode { get; set; } = null!;

    public string Qualifications { get; set; } = null!;

    public int GradesId { get; set; }

    public string? Feedbacks { get; set; }

    public decimal Salary { get; set; }

    public virtual ICollection<Annoucement> Annoucements { get; set; } = new List<Annoucement>();

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual Grade Grades { get; set; } = null!;

    public virtual ICollection<LiveSession> LiveSessions { get; set; } = new List<LiveSession>();

    public virtual Person Person { get; set; } = null!;
}
