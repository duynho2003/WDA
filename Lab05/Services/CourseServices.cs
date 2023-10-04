using Lab05.Models;
using Lab05.Repository;

namespace Lab05.Services
{
    public class CourseServices : CourseRepository
    {
        private DatabaseContext _db;
        public CourseServices(DatabaseContext db) { _db = db; }
        public List<Course> FindAll(decimal? min, decimal? max)
        {
            var model = _db.Course.ToList();
            if (min == null && max == null)
            {
                return model;
            }
            else 
            { 
                model = model.Where(c => c.fee >= min && c.fee <= max).ToList();
                return model;
            }
        }

        public Course FindOne(string? code)
        {
            return _db.Course.FirstOrDefault(c => c.code.Equals(code));
            //return _db.Course.Find(code!);
        }

        public void saveCourse(Course course)
        {
            var c = _db.Course.SingleOrDefault(c => c.code!.Equals(course.code));
            if (c == null)
            {
                _db.Course.Add(course);
                _db.SaveChanges();
            }
            else
            { 
                //no dothing
            }
        }
    }
}
