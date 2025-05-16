using Microsoft.AspNetCore.Mvc;
using MyCourses.Models.Services;
using MyCourses.Models.ViewModels;

namespace MyCourses.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index() {
            ViewBag.Title = "MyCourses - Home";

            List<CourseViewModel> mostRecentCourses = _courseService.GetMostRecentCourses();
            List<CourseViewModel> bestCourses = _courseService.GetBestCourses();

            HomeViewModel viewModel = new HomeViewModel
            {
                MostRecentCourses = mostRecentCourses,
                BestCourses = bestCourses
            };

            return View(viewModel); 
        }
    }
}
