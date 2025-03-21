using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services
{
    public class CourseService
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
                var course = new CourseViewModel
                {
                    Id = i,
                    Title = $"Corso {i}",
                    ImagePath = "/logo.svg"
                };
                courseList.Add(course);
            }
            return courseList;
        }
    }
}
