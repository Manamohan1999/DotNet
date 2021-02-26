using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTest.Models
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public SqlStudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Student Create(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();

            return student;
        }

        public Student Delete(int Id)
        {
            Student student = context.Students.Find(Id);
            Address address = context.Addresses.Find(Id);
            if(student != null && address != null)
            {
                context.Students.Remove(student);
                context.Addresses.Remove(address);
                context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students;
        }

        public Student GetStudent(int? Id)
        {
            if(Id == null)
            {
                return null;
            }
            return context.Students.Find(Id);
        }

        public Student Update(Student studentChange)
        {
            var student = context.Students.Attach(studentChange);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return studentChange;
        }
    }
}
