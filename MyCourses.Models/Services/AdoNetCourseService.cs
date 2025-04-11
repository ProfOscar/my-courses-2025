using Microsoft.Data.SqlClient;
using MyCourses.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourses.Models.Services
{
    public class AdoNetCourseService : ICourseService
    {
        public List<CourseViewModel> GetCourses()
        {
            var courseList = new List<CourseViewModel>();
            string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Dati\\MyCourses.mdf;Integrated Security=True;Connect Timeout=30";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CourseViewModel course = new CourseViewModel()
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                ImagePath = reader.GetString(2),
                                Author = reader.GetString(3),
                                Rating = reader.GetFloat(4),
                                FullPrice = new Money(Enums.Currency.EUR, reader.GetDecimal(6)),
                                CurrentPrice = new Money(Enums.Currency.EUR, reader.GetDecimal(8))
                                //TODO: gestire correttamente la valuta
                            };
                            courseList.Add(course);
                        }
                    }
                }
            }
            return courseList;
        }

        public CourseDetailViewModel GetCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}
