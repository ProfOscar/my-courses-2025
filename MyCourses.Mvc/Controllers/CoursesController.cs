using Microsoft.AspNetCore.Mvc;
using MyCourses.Models;
using MyCourses.Models.Services;
using MyCourses.Models.ViewModels;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            CourseService courseService = new CourseService();
            List<CourseViewModel> courses = courseService.GetCourses();
            ViewBag.Title = "MyCourses - Catalogo";
            return View(courses);
        }

        public IActionResult Details(int id) {
            CourseService courseService = new CourseService();
            CourseDetailViewModel details = courseService.GetCourse(id);
            ViewBag.Title = $"MyCourses - {details.Title}";
            return View(details);
        }
    }
}
