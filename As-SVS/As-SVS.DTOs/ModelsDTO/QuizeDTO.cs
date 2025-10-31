

namespace As_SVS.DTOs.ModelsDTO
{
    public class QuizeDTO
    {
        public string Name { get; set; } = null!;

        public int Number { get; set; }

        public int CourseOrder { get; set; }

        public double MinPassScore { get; set; }

        public bool IsPassRequiered { get; set; }

        public List<QuizeQuestionDTO> QuizQuestions { get; set; } = new List<QuizeQuestionDTO>();
    }
}
