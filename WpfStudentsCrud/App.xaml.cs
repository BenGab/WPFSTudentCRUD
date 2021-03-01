using Ninject;
using StudenstLib.DataContext;
using StudenstLib.DataContext.Models;
using Students.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfStudentsCrud.ViewModels;

namespace WpfStudentsCrud
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            _kernel = new StandardKernel();
            RegisterServices(_kernel);
            base.OnStartup(e);
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IStudentsDbContext>().To<StudentsDbContext>().InSingletonScope();
            kernel.Bind<IRepository<Student>>().To<StudentRepository>();
        }

        public MainWindowViewModel MainVM
        {
            get
            {
                return _kernel.Get<MainWindowViewModel>();
            }
        }
    }
}
