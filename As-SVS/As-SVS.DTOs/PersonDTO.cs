using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs
{
    public class PersonDTO
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
    }
}
