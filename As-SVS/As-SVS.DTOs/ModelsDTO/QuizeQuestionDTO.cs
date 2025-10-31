using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class QuizeQuestionDTO
    {
        public int Number { get; set; }

        public string Question { get; set; } = null!;
        public List<QuestionOptionDTO> QuestionOptions { get; set; } = new List<QuestionOptionDTO>();
    }
}
