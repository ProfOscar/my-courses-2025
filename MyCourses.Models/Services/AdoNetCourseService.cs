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
            throw new NotImplementedException();
        }
    }
}
