using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.VideoDTO
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public string applicationUserId { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
