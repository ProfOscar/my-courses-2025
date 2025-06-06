﻿namespace MyCourses.Models.ViewModels
{
    public class CourseDetailViewModel : CourseViewModel
    {
        public required string Description { get; set; }
        public List<LessonViewModel> Lessons { get; set; } = [];
        public TimeSpan TotalCourseDuration {
            get => TimeSpan.FromSeconds(Lessons.Sum(l => l.Duration.TotalSeconds));
        }
    }
}
