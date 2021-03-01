using StudenstLib.DataContext;
using StudenstLib.DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly IStudentsDbContext studentDbContext;

        public StudentRepository(IStudentsDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        public Student AddNew(Student item)
        {
            studentDbContext.AddStudent(item);
            return item;
        }

        public void Delete(Student item)
        {
            studentDbContext.RemoveStudent(item);
        }

        public IEnumerable<Student> GetAll()
        {
            return studentDbContext.GetStudents();
        }

        public Student GetById(Guid id)
        {
            return GetAll().Single(st => st.Id == id);
        }

        public Student Update(Student item)
        {
            return studentDbContext.UpdateStudents(item);
        }
    }
}
