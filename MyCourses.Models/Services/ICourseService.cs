using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services
{
    public interface ICourseService
    {
        List<CourseViewModel> GetCourses(string search);
        CourseDetailViewModel GetCourse(int id);
        List<CourseViewModel> GetBestCourses();
        List<CourseViewModel> GetMostRecentCourses();
    }
}
