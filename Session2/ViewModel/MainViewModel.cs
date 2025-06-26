using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session2.Model;
using Session2.Utilits;
using Session2.View;
using Session2.Services;
using System.Net;
namespace Session2.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
       private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Department> Deps{ get; set; }
        public List<Employee> EmployeesList { get; set; }
        private Employee selectedemployee;
        public EmployeeService employeeService;
        public DepartmentService departmentService;
        public Employee SelectedEmployee
        {
            get
            {
                return selectedemployee;
            }
            set
            {
                selectedemployee = value;
                OnPropertyChanged(nameof(selectedemployee));
            }
        }
        public MainViewModel()
        {

            employeeService = new EmployeeService();
            departmentService = new DepartmentService();
            Load();
        }
        private void Load()
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                Employees = new ObservableCollection<Employee>(employeeService.GetAll());
                Deps = new ObservableCollection<Department>(departmentService.GetAll());
            }
            
            EmployeesList = new List<Employee>();
            foreach(Employee emp in Employees)
            {
               
                EmployeesList.Add(emp);
            }
        }
        private RelayCommand? addCommand;
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                     PersonWindow window = new PersonWindow(new Employee(), 893);
                     window.Show();
                  }));
            }
        }
        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((o) =>
                  {
                      Employee employee = o as Employee;
                      PersonWindow window = new PersonWindow(employee, employee.IdDepartment);
                      window.Show();
                     
                  }));
            }
        }
    }
}
