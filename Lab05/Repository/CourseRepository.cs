using Lab05.Models;

namespace Lab05.Repository
{
    public interface CourseRepository
    {
        List<Course> findAll(decimal? min, decimal? max);
        Course findOne(string code);
        void saveCourse(Course course);
    }
}
