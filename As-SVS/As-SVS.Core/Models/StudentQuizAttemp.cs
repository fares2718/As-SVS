using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class StudentQuizAttemp
{
    public int StudentId { get; set; }

    public int QuizId { get; set; }

    public DateTime? AttempDate { get; set; }

    public double ScoreAchived { get; set; }

    public virtual Quize Quiz { get; set; } = default!;

    public virtual Student Student { get; set; } = default!;
}
