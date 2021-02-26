using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTest.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int? Id);
        IEnumerable<Student> GetAllStudents();
        Student Create(Student student);
        Student Update(Student studentChange);
        Student Delete(int Id);

    }
}
