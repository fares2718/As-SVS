namespace As_SVS.Core.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsProgressLimited { get; set; }

    public string? CourseCode { get; set; }

    public int GradeId { get; set; }
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; } = default!;
    public virtual Room Room { get; set; } = default!;
    public virtual Grade Grade { get; set; } = default!;
    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
