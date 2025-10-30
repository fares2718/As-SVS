using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class LessonServices : ILessonsServices
    {
        private readonly ILessonsRepository _lessonsRepository;

        public LessonServices(ILessonsRepository lessonsRepository)
        {
            _lessonsRepository = lessonsRepository;
        }

        public async Task<IEnumerable<Lesson>> GetModulesLessons(int moduleId)
        {
            return await _lessonsRepository.GetModulesLessons(moduleId);
        }
    }
}
