namespace As_SVS.Core.Models;

public partial class Room
{
    public int Id { get; set; }

    public int GradeId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
