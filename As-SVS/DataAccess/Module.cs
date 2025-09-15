using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Module
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<Quize> Quizes { get; set; } = new List<Quize>();
}
