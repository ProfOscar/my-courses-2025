using MyCourses.Models.Enums;
using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services
{
    /// <summary>
    /// Servizio di test con dati creati in modo pseudocasuale.
    /// </summary>
    public class TestCourseService : ICourseService
    {
        public List<CourseViewModel> GetCourses()
        {
            // dovrà leggere i dati dal DB e restituire la lista dei corsi
            // provvisoriamente creiamo dati casuali di test in memoria
            var courseList = new List<CourseViewModel>();
            var rnd = new Random();
            for (int i = 1; i <= 20; i++)
            {
                var price = Convert.ToDecimal(rnd.NextDouble() * 10 + 10);
                var fullPrice = rnd.NextDouble() > 0.5 ? price : price + 1;
                var course = new CourseViewModel
                {
                    Id = i,
                    Title = $"Corso {i}",
                    ImagePath = "/logo.svg",
                    Author = "Nome Cognome",
                    Rating = rnd.Next(10, 51) / 10.0, // importante il .0 per fare una divisione con la virgola
                    FullPrice = new Money(Currency.EUR, fullPrice),
                    CurrentPrice = new Money(Currency.EUR, price)
                };
                courseList.Add(course);
            }
            return courseList;
        }

        public CourseDetailViewModel GetCourse(int id)
        {
            var rnd = new Random();
            var price = Convert.ToDecimal(rnd.NextDouble() * 10 + 10);
            var fullPrice = rnd.NextDouble() > 0.5 ? price : price + 1;
            var course = new CourseDetailViewModel
            {
                Id = id,
                Title = $"Corso {id}",
                Description = $"Description {id}",
                ImagePath = "/logo.svg",
                Author = "Nome Cognome",
                Rating = rnd.Next(10, 51) / 10.0,
                FullPrice = new Money(Currency.EUR, fullPrice),
                CurrentPrice = new Money(Currency.EUR, price),
                Lessons = new List<LessonViewModel>()
            };
            for (int i = 0; i < 5; i++)
            {
                var lesson = new LessonViewModel
                {
                    Title = $"Lesson {i}",
                    Duration = TimeSpan.FromSeconds(rnd.Next(40, 90))
                };
                course.Lessons.Add(lesson);
            }
            return course;
        }
    }
}
