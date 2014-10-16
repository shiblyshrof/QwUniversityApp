using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using StudentApp1.DLL.DAO;

namespace StudentApp1.DLL.Gateway
{
    class StudentGateway
    {
        private SqlConnection connection;

        public StudentGateway()
        {
            string conn = @"server=SHIBLY-PC; database=QwUniversity; integrated security=true";

            connection = new SqlConnection();

            connection.ConnectionString = conn;
        }

        public string Save(Student aStudent)
        {
            connection.Open();

            string query = string.Format("INSERT INTO t_Student1 VALUES ('{0}','{1}','{2}')", aStudent.Name, aStudent.Email, aStudent.Address);

            SqlCommand command = new SqlCommand(query, connection);
           int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)

                return "insert success";

            else
                return "problem";

        }

        public bool HasThisEmailValid(string email)
        {
            connection.Open();

            string query = string.Format("SELECT * FROM t_Student1 WHERE Email='{0}'",email);

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public List<Student> GetAllStudent()
        {
            connection.Open();

            string query = string.Format("SELECT * FROM t_Student1");

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader aReader = command.ExecuteReader();
            
            List<Student> students =new List<Student>();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Student aStudent=new Student();
                    aStudent.StudentId = (int) aReader[0];
                    aStudent.Name = aReader[1].ToString();
                    aStudent.Email = aReader[2].ToString();
                    aStudent.Address = aReader[3].ToString();
                    
                    students.Add(aStudent);
                }
               
            }
            connection.Close();
            return students;


        }
    }

       
    }

