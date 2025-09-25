using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTO
{
    public class PersonDTO
    {
        public enum enPermission { None=0,Student=1,Teatcher=2,Admin=3};
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return $"{this.FirstName} {this.MiddelName} {this.LastName}";
        }
        public DateOnly DateOfBirth;
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Phone { get; set; } 
        public string? ImageUrl { get; set; }
        public bool Gender { get; set; }
        public enPermission Permission;  

    }
}
