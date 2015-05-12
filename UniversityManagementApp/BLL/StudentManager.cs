using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.DAL;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.BLL
{
    public class StudentManager
    {
        StudentGatway gatway = new StudentGatway();

        public bool IsRegNoExists(string regNo)
        {
            Student students = gatway.GetStudentByRegNo(regNo);
            if (students != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string Save(Student students)
        {
            bool checkRegNo = IsRegNoExists(students.studentRegNo);
            if (checkRegNo)
            {
                return "Reg No Exists!";
            }
            if (gatway.Save(students) > 0)
            {
                return "Added Successfully!";
            }
            else
            {
                return "Failed!";
            }
        }

        public List<Student> GetAllStudents()
        {
            return gatway.GetAllStudents();
        }
    }
}
