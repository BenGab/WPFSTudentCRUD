using StudenstLib.DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudenstLib.DataContext
{
    public class StudentsDbContext : IStudentsDbContext
    {
        private List<Student> students;

        public StudentsDbContext()
        {
            students = new List<Student>();
        }

        public Student AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return students.AsEnumerable();
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public Student UpdateStudents(Student student)
        {
            var st = students.Single(x => x.Id == student.Id);
            st.ClassId = student.ClassId;
            st.FirstName = student.FirstName;
            st.LastName = student.LastName;

            return st;
        }
    }
}
