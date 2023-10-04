using Lab05.Models;

namespace Lab05.Repository
{
    public interface CourseRepository
    {
        List<Course> FindAll(decimal? min, decimal? max);
        Course FindOne(string code);
        void saveCourse(Course course);
    }
}
