using GalaSoft.MvvmLight;
using StudenstLib.DataContext.Models;
using System;

namespace WpfStudentsCrud.Models
{
    public class StudentsVM : ObservableObject
    {
        string firstName;
        string lastName;
        private Student student;

        public StudentsVM()
        {
            student = new Student();
            GuId = string.Empty;
            firstName = "empty";
            lastName = "empty";
        }

        public StudentsVM(Student student)
        {
            this.student = student;
            GuId = this.student.Id.ToString();
            firstName = this.student.FirstName;
            lastName = this.student.LastName;
        }

        public string GuId { get; set; }

        public string FirstName { get => firstName; set => Set(ref firstName, value); }

        public string LastName { get => lastName; set => Set(ref lastName, value); } 

        public Student ToStudent()
        {
            student.FirstName = firstName;
            student.LastName = lastName;
            return student;
        }

        public void SetStudent(Student student)
        {
            this.student = student;
            GuId = student.Id.ToString();
        }
    }
}
