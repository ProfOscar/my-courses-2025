using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services
{
    public interface ICourseService
    {
        List<CourseViewModel> GetCourses();
        CourseDetailViewModel GetCourse(int id);
    }
}
