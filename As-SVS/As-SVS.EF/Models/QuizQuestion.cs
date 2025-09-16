using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class QuizQuestion
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    public int Number { get; set; }

    public string Question { get; set; } = null!;

    public virtual ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();

    public virtual Quize Quiz { get; set; } = null!;
}
