namespace MyCourses.Models.Services
{
    public class CourseService
    {
        public List<Course> GetCourses()
        {
            // dovrà leggere i dati dal DB e restituire la lista dei corsi
            // provvisoriamente creiamo dati casuali di test in memoria
            var courseList = new List<Course>();
            var rnd = new Random();
            for (int i = 1; i <= 20; i++)
            {
                var price = Convert.ToDecimal(rnd.NextDouble() * 10 + 10);
                var course = new Course(
                        i,
                        $"Corso {i}",
                        $"Description {i}",
                        "/logo.svg"
                    );
                courseList.Add(course);
            }
            return courseList;
        }
    }
}
