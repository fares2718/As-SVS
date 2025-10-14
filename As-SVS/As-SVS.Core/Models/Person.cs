using System;
using System.Collections.Generic;

namespace As_SVS.Core.Models;

[Flags]
public enum Permissions
{
    None = 0,
    Student = 1 << 1,
    Teacher = 1 << 2,
    Admin = 1 << 3
}
public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string FullName()
    {
        return $"{FirstName} {MiddleName} {LastName}";
    }

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public bool Gender { get; set; }

    public  Permissions Permission { get; set; }

    public virtual Admin? Admin { get; set; } 

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
