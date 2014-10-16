using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentApp1.BLL;
using StudentApp1.DLL.DAO;

namespace StudentApp1
{
    public partial class StudentUI : Form
    {
        private StudentBLL aStudentBll = new StudentBLL();
        private List<Student> students;

        public StudentUI()
        {
            InitializeComponent();
            ShowDataInGrid();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();

            aStudent.Name = nameTextBox.Text;
            aStudent.Email = emailTextBox.Text;
            aStudent.Address = addressTextBox.Text;

            

            string msg = aStudentBll.Save(aStudent);
            MessageBox.Show(msg);
            ShowDataInGrid();
        }

        private void ShowDataInGrid()
        {
            studentGridView.DataSource = students;
            students = aStudentBll.GetAllStudent();
        }
    }
}
