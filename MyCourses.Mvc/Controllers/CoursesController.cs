﻿using Microsoft.AspNetCore.Mvc;
using MyCourses.Models;
using MyCourses.Models.Services;
using MyCourses.Models.ViewModels;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        private ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
                _courseService = courseService;
        }

        public IActionResult Index()
        {
            List<CourseViewModel> courses = _courseService.GetCourses();
            ViewBag.Title = "MyCourses - Catalogo";
            return View(courses);
        }

        public IActionResult Details(int id) {
            CourseDetailViewModel details = _courseService.GetCourse(id);
            ViewBag.Title = $"MyCourses - {details.Title}";
            return View(details);
        }
    }
}
