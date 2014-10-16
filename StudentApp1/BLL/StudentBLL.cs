using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp1.DLL.DAO;
using StudentApp1.DLL.Gateway;

namespace StudentApp1.BLL
{
    class StudentBLL
    {
        private StudentGateway atStudentGateway;
        public StudentBLL()
        {
            atStudentGateway=new StudentGateway();
        }

        public string Save(Student aStudent)
        {
            if (aStudent.Name==string .Empty|| aStudent.Email==string.Empty|| aStudent.Email==string.Empty)
            {
                return "pls fill up the box";
            }
            else
            {
                if (!HasThisEmailValid(aStudent.Email))
                {
                    return atStudentGateway.Save(aStudent);
                }
                else
                {
                    return "email already in system";
                }

            }

        }

        private bool HasThisEmailValid(string email)
        {
            return atStudentGateway.HasThisEmailValid(email);
        }

        public List<Student> GetAllStudent()
        {
            return atStudentGateway.GetAllStudent();
        }
    }
}
