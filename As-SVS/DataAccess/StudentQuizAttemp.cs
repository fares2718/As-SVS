using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class StudentQuizAttemp
{
    public int StudentId { get; set; }

    public int QuizId { get; set; }

    public DateOnly? AttempDate { get; set; }

    public double ScoreAchived { get; set; }

    public virtual Quize Quiz { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
