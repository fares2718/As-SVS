using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace As_SVS.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public DateOnly DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public bool Gender { get; set; }
        public virtual Admin? Admin { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Student? Student { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
