using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudenstLib.DataContext.Models;
using Students.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfStudentsCrud.Models;

namespace WpfStudentsCrud.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRepository<Student> repository;
        private readonly RelayCommand _addNewCommand;
        private readonly RelayCommand _deleteCommand;
        private readonly RelayCommand _saveStudentCommand;
        private readonly Queue<StudentsVM> SaveQueue;

        public MainWindowViewModel(IRepository<Student> repository)
        {
            this.repository = repository;
            GetStudents();
            _addNewCommand = new RelayCommand(AddNewStudent);
            _deleteCommand = new RelayCommand(DeleteStudent);
            _saveStudentCommand = new RelayCommand(SaveStudent);
            SaveQueue = new Queue<StudentsVM>();
        }

        private ObservableCollection<StudentsVM> _students;

        public ObservableCollection<StudentsVM> Students
        {
            get { return _students; }
            set { Set(ref _students, value); }
        }

        private StudentsVM _selectedStudent;

        public StudentsVM SelectedStudent
        {
            get { return _selectedStudent; }
            set { Set(ref _selectedStudent, value); }
        }

        public RelayCommand AddNewCommand
        {
            get
            {
                return _addNewCommand;
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand;
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveStudentCommand;
            }
        }

        private void GetStudents()
        {
            Students = new ObservableCollection<StudentsVM>(repository.GetAll().Select(x => new StudentsVM(x)));

            if (Students.Count <= 0)
            {
                return;
            }

            _selectedStudent = _students.First();
        }

        private void AddNewStudent()
        {
            var st = new StudentsVM();
            Students.Add(st);
            SelectedStudent = st;
        }

        private void DeleteStudent()
        {
            if(_selectedStudent == null)
            {
                return;
            }

            if(!string.IsNullOrEmpty(_selectedStudent.GuId))
            {
                repository.Delete(_selectedStudent.ToStudent());
            }

            Students.Remove(_selectedStudent);
            SelectedStudent = Students.FirstOrDefault();
        }

        private void SaveStudent()
        {
            if(_selectedStudent == null)
            {
                return;
            }

            if(string.IsNullOrEmpty(_selectedStudent.GuId))
            {
                var st = repository.AddNew(_selectedStudent.ToStudent());
                _selectedStudent.SetStudent(st);
            } 
            else
            {
                repository.Update(_selectedStudent.ToStudent());
            }
        }
    }
}