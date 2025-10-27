using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Models
{
    public class RegisterModel
    {
        [Required,StringLength(100)]
        public string FirstName { get; set; } = null!;
        [Required, StringLength(100)]
        public string MiddleName { get; set; } = null!;
        [Required, StringLength(100)]
        public string LastName { get; set; } = null!;
        [Required, StringLength(50)]
        public string Username { get; set; } = null!;
        [Required, StringLength(150)]
        public string Email { get; set; } = null!;
        [Required, StringLength(100)]
        public string Password { get; set; } = null!;
    }
}
