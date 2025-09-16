using System;
using System.Collections.Generic;

namespace As_SVS.EF.Models;

public partial class Admin
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal Salary { get; set; }

    public virtual Person Person { get; set; } = null!;
}
