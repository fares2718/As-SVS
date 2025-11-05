using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace AsSVS.EF.Repositories
{
    public class QuizeRepository : IQuizeRepository
    {
        private readonly As_SVSContext _context;

        public QuizeRepository(As_SVSContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewAsync(Quize quize, int courseId, int moduleId)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            var module = course.Modules.SingleOrDefault(m => m.Id == moduleId);
            if (course is null || module is null)
                return -1;
            module.Quizes.Add(quize);
            await _context.SaveChangesAsync();
            return quize.Id;
        }

        public async Task AttempQuize(StudentQuizAttemp studentQuizAttemp)
        {
            await _context.StudentQuizAttemps.AddAsync(studentQuizAttemp);
            await _context.SaveChangesAsync();
        }

        public async Task<QuizeDTO> GetQuizeToAttemoAsync(int courseId, int quizeId)
        {
            var query =
                await _context.Quizes
                    .Where(q => q.Module.CourseId == courseId)
                    .Select(
                        q => new QuizeDTO
                        {
                            Id = q.Id,
                            Name = q.Name,
                            Number = q.Number,
                            CourseOrder = q.CourseOrder,
                            MinPassScore = q.MinPassScore,
                            IsPassRequiered = q.IsPassRequiered,
                            QuizQuestions = q.QuizQuestions
                            .Select(
                                    qq => new QuizeQuestionDTO
                                    {
                                        Number = qq.Number,
                                        Question = qq.Question,
                                        QuestionOptions = qq.QuestionOptions
                                        .Select(
                                                qo => new QuestionOptionDTO
                                                {
                                                    Number = qo.Number,
                                                    OptionText = qo.OptionText,
                                                    IsCorrect = qo.IsCorrect,
                                                }
                                            ).ToList(),
                                    }
                                ).ToList(),
                        }
                    ).ToListAsync();
            return query.SingleOrDefault(q => q.Id == quizeId)??new QuizeDTO();
        }
    }
}
