using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsProgressLimited { get; set; }

    public string? CourseCode { get; set; }

    public int GradeId { get; set; }

    public virtual ICollection<Annoucement> Annoucements { get; set; } = new List<Annoucement>();

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
