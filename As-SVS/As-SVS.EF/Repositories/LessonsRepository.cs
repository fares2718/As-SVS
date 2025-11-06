namespace AsSVS.EF.Repositories
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly As_SVSContext _context;

        public LessonsRepository(As_SVSContext context)
        {
            _context = context;
        }

        #region Creat
        public async Task<int> AddNewAsync(Lesson lesson, int courseId, int moduleId)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == courseId);
            if (course is null)
                return -1;
            var module = course.Modules.SingleOrDefault(m => m.Id == moduleId);
            if (module is null)
                return -1;
            module.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return lesson.Id;
        }
        public async Task<bool> UploadVideoToDatabase(string fileName, int courseId,int moduleId, int lessonId)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(
                c => c.Id == courseId);

            if (course is null)
                return false;

            var module = course.Modules.SingleOrDefault(m => m.Id == moduleId);

            if(module is null)
                return false;

            var lesson = module.Lessons.FirstOrDefault(l => l.Id == lessonId);

            if (lesson is null)
                return false;

            lesson.VideoUrl = fileName;
            return true;
        }
        #endregion

    }
}
