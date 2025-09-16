using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class QuestionOption
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string OptionText { get; set; } = null!;

    public decimal Number { get; set; }

    public bool IsCorrect { get; set; }

    public virtual QuizQuestion Question { get; set; } = null!;
}
