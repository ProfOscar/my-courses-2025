using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyCourses.Models.Enums;
using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services
{
    public class AdoNetCourseService : ICourseService
    {
        private readonly string _connStr;

        public AdoNetCourseService(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")!;
        }

        public List<CourseViewModel> GetCourses()
        {
            var courseList = new List<CourseViewModel>();
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            string sql = "SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CourseViewModel course = new CourseViewModel()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    ImagePath = reader.GetString(2),
                    Author = reader.GetString(3),
                    Rating = reader.GetFloat(4),
                    FullPrice = new Money(
                        Enum.Parse<Currency>(reader.GetString(5)),
                        reader.GetDecimal(6)
                    ),
                    CurrentPrice = new Money(
                        Enum.Parse<Currency>(reader.GetString(7)),
                        reader.GetDecimal(8)
                    )
                };
                courseList.Add(course);
            }
            return courseList;
        }

        public CourseDetailViewModel GetCourse(int id)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();
            string sql = "SELECT Id, Title, Description, ImagePath, Author, Rating, FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses WHERE Id=@Id;";
            sql += "SELECT Id, Title, Description, Duration FROM Lessons WHERE CourseId=@Id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("Id", id));
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CourseDetailViewModel course = new CourseDetailViewModel()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = reader.GetString(2),
                    ImagePath = reader.GetString(3),
                    Author = reader.GetString(4),
                    Rating = reader.GetFloat(5),
                    FullPrice = new Money(
                        Enum.Parse<Currency>(reader.GetString(6)),
                        reader.GetDecimal(7)
                    ),
                    CurrentPrice = new Money(
                        Enum.Parse<Currency>(reader.GetString(8)),
                        reader.GetDecimal(9)
                    )
                };
                reader.NextResult();
                List<LessonViewModel> lessons = new List<LessonViewModel>();
                while (reader.Read())
                {
                    lessons.Add(new LessonViewModel()
                    {
                        Title = Convert.ToString(reader["Title"]),
                        Duration = TimeSpan.Parse(Convert.ToString(reader["Duration"]))
                    });
                }
                course.Lessons = lessons;
                return course;
            }
            throw new InvalidOperationException($"La query dovrebbe restituire i dati del corso {id}");
        }
    }
}
