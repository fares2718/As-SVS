namespace As_SVS.Core.Models;

public partial class Enrolment
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime? EnrolmentDate { get; set; }

    public DateTime? CompletionDate { get; set; }

    public virtual Course Course { get; set; } = default!;

    public virtual Student Student { get; set; } = default!;

}
