using EntityFramework.IDao;
using EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DaoImpl
{
    class UserDaoImpl : IUser
    {
        public void addStudent(Student student)
        {
            // Thông tin của sinh viên được thêm mới
            /*var student = new Student();
            student.StudentID = 3;
            student.StudentName = "Lê Thị Hồng";
            student.StudentGender = "Nam";
            student.Address = "Bình Dương";
            student.Email = "vietem@gmail.com";
            student.PhoneNumber = "113";*/
            // Thêm vào database
            using (var db = new EntityFrameworkEntities())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void deleteStudent(int studentID)
        {
            using (var db = new EntityFrameworkEntities())
            {
                var delete = (from d in db.Students where d.StudentID == studentID select d).Single();
                db.Students.Remove(delete);
                db.SaveChanges();
            }
        }

        public List<Student> getAllStudent()
        {
            List<Student> students = new List<Student>();
            //Console.OutputEncoding = Encoding.UTF8;
            using (var db = new EntityFrameworkEntities())
            {
                var select = from s in db.Students select s;
                foreach (var data in select)
                {
                    students.Add(data);
                }
            }
            return students;
        }

        public void updateStudent(Student student)
        {
            using (var db = new EntityFrameworkEntities())
            {
                var update = (from u in db.Students where u.StudentID == student.StudentID select u).Single();
                update.StudentGender = student.StudentGender;
                update.StudentName = student.StudentName;
                update.PhoneNumber = student.PhoneNumber;
                update.Email = student.Email;
                db.SaveChanges();
            }
        }
    }
}
