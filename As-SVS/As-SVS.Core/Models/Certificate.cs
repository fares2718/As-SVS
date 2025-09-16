using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class Certificate
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int GradeId { get; set; }

    public int CertificateNumber { get; set; }

    public DateOnly IssuedAt { get; set; }

    public string FileUrl { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
