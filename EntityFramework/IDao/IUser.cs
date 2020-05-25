using EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.IDao
{
    interface IUser
    {
        List<Student> getAllStudent();
        void addStudent(Student student);
        void updateStudent(Student student);
        void deleteStudent(int studentID);
    }
}
