using Microsoft.AspNetCore.Mvc;
using MyCourses.Models;
using MyCourses.Models.Services;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            CourseService courseService = new CourseService();
            List<Course> courses = courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Details(string id) {
            int myId;
            if (!int.TryParse(id, out myId))
            {
                myId = -1;
            }
            Course testCourse = new Course(myId, $"Test Course {myId}",
                $"Descrizione del corso {myId}", "");
            // return Content($"Sono Details di questo corso\n{testCourse}");
            return View();
        }
    }
}
