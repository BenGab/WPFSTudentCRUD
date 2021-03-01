using StudenstLib.DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudenstLib.DataContext
{
    public interface IStudentsDbContext
    {
        IEnumerable<Student> GetStudents();

        Student AddStudent(Student student);

        Student UpdateStudents(Student student);

        void RemoveStudent(Student student);
    }
}
