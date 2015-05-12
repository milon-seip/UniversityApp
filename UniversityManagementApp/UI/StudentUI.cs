using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityManagementApp.BLL;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp
{
    public partial class StudentUI : Form
    {
        public StudentUI()
        {
            InitializeComponent();            
        }
        StudentManager stdManager = new StudentManager();
        DepartmentManager deptManager = new DepartmentManager();
        public int studentID = 0;
        private void saveButton_Click(object sender, EventArgs e)
        {
            Student students = new Student();
            students.studentRegNo = regNoTextBox.Text;
            students.studentName = nameTextBox.Text;
            students.studentAddress = addressTextBox.Text;
            students.studentId = studentID;
            int selectDepartmentId = int.Parse(departmentComboBox.SelectedValue.ToString());

            students.departmentId = selectDepartmentId;
            MessageBox.Show(stdManager.Save(students));
        }

        private void StudentUI_Load(object sender, EventArgs e)
        {
            LoadAllDepartmentComboBox();
            LoadAllStudents();
        }

        private void LoadAllStudents()
        {
            List<Student> students = stdManager.GetAllStudents();
            studentListView.Items.Clear();
            foreach (var student in students)
            {
                ListViewItem listView = new ListViewItem(student.studentId.ToString());
                listView.SubItems.Add(student.studentRegNo);
                listView.SubItems.Add(student.studentName);
                listView.SubItems.Add(student.studentAddress);

                studentListView.Items.Add(listView);
            }
        }

        public void LoadAllDepartmentComboBox()
        {
            List<Department> departments = deptManager.GetAllDepartments();

            departmentComboBox.DisplayMember = "departmentName";
            departmentComboBox.ValueMember = "departmentId";
            departmentComboBox.DataSource = null;
            departmentComboBox.DataSource = departments;
        }
    }
}
