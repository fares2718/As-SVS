using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

public partial class Admin
{
    public int Id { get; set; }
    public string applicationUserId { get; set; } = null!;
    public decimal Salary { get; set; }

    public virtual ApplicationUser applicationUser { get; set; } = default!;
}
