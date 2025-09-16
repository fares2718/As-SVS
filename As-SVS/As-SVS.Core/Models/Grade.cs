using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string GradeLevel { get; set; } = null!;

    public decimal Number { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
