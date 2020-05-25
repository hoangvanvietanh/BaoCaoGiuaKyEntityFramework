using EntityFramework.DaoImpl;
using EntityFramework.IDao;
using EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    class StudentServices
    {
        private IUser userDao = new UserDaoImpl();

        public List<Student> getAllStudent()
        {
            return userDao.getAllStudent();
        }

        public void addStudent(Student student)
        {
            userDao.addStudent(student);
        }

        public void updateStudent(Student student)
        {
            userDao.updateStudent(student);
        }

        public void delete(int id)
        {
            userDao.deleteStudent(id);
        }
    }
}
