using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.DAL
{
    public class StudentGatway
    {
        public string studentConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public Student GetStudentByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(studentConString);

            string query = "SELECT * FROM tbl_student WHERE student_regNo = '" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Student students = null;


            while (reader.Read())
            {

                if (students == null)
                {
                    students = new Student();
                }

                students.studentId = int.Parse(reader["student_id"].ToString());
                students.studentRegNo = reader["student_regNo"].ToString();
                students.studentName = reader["student_name"].ToString();
                students.studentAddress = reader["student_address"].ToString();
            }
            reader.Close();
            connection.Close();

            return students;
        }

        public int Save(Student students)
        {
            SqlConnection connection = new SqlConnection(studentConString);
            string query = "INSERT INTO tbl_student VALUES('" + students.studentId + "','" + students.studentRegNo +
                           "','" + students.studentName + "','" + students.studentAddress + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(studentConString);

            string query = "SELECT * FROM tbl_student";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Student> studentList = new List<Student>();

            while (reader.Read())
            {
                Student students = new Student();
                students.studentId = int.Parse(reader["student_id"].ToString());
                students.studentRegNo = reader["student_regNo"].ToString();
                students.studentName = reader["student_name"].ToString();
                students.studentAddress = reader["student_address"].ToString();
            }
            reader.Close();
            connection.Close();

            return studentList;
        }
    }
}
