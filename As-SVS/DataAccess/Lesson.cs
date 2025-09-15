using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Lesson
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public string VideoUrl { get; set; } = null!;

    public string LessonDetails { get; set; } = null!;

    public int CourseOrder { get; set; }

    public virtual Module Module { get; set; } = null!;
}
