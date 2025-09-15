using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class StudentLesson
{
    public int StudentId { get; set; }

    public int LessonId { get; set; }

    public bool IsCompleted { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
