using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class QuizeAttempDTO
    {
        public int StudentId { get; set; } 
        public int QuizeId { get; set; } 
        public DateTime? AttempDate { get; set; }
        public double ScoreAchived { get; set; }
        public List<QuestionOptionDTO> StudentOptionsNumbers = new List<QuestionOptionDTO>();
    }
}
