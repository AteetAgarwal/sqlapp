using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class CourseService
    {
        /*private SqlConnection GetConnection(string _connString)
        {
            return new SqlConnection(_connString);
        }*/

        public IEnumerable<Course> GetCourses(string courses)
        {
            List<Course> _lst = new List<Course>();
            /*string _statement = "Select CourseId, CourseName, Rating from Course";
            SqlConnection _sqlConn = GetConnection(_connString);
            _sqlConn.Open();
            SqlCommand _sqlCommand = new SqlCommand(_statement, _sqlConn);
            using(SqlDataReader _reader = _sqlCommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseId = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };
                    _lst.Add(_course);
                }
            }
            _sqlConn.Close();*/
            string[] courseArr = courses.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach(string course in courseArr)
            {
                string[] arr = course.Split(',', StringSplitOptions.RemoveEmptyEntries);
                Course _course = new Course()
                {
                    CourseId = Convert.ToInt32(arr[0]),
                    CourseName = arr[1],
                    Rating =Convert.ToDecimal( arr[2])
                };
                _lst.Add(_course);
            }
            return _lst;
        }
    }
}
