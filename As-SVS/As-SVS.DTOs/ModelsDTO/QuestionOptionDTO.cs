using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class QuestionOptionDTO
    {
        public string OptionText { get; set; } = null!;

        public decimal Number { get; set; }

        public bool IsCorrect { get; set; }
    }
}
