using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class Quize
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public int CourseOrder { get; set; }

    public double MinPassScore { get; set; }

    public bool IsPassRequiered { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
}
