using Microsoft.AspNetCore.Mvc;
using MyCourses.Models;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            // return Content("Sono Index di Courses");
            return View();
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
