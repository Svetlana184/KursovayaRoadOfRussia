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
       
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Department> Deps{ get; set; }
        public List<EmployeeForList> EmployeesList { get; set; }
        private EmployeeForList selectedemployee;
        public EmployeeService employeeService;
        public DepartmentService departmentService;
        public EmployeeForList SelectedEmployee
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
            
            EmployeesList = new List<EmployeeForList>();
            foreach(Employee emp in Employees)
            {
                EmployeeForList empL = new EmployeeForList
                {
                    IdEmployeeForList = emp.IdEmployee,
                    FIO = emp.Surname + " " + emp.FirstName + " " + emp.SecondName,
                    Contacts = emp.PhoneWork + " " + emp.Email,
                    WorkPlace = Deps.FirstOrDefault(x => x.IdDepartment == emp.IdDepartment)!.DepartmentName + " - " + emp.Position,
                    Cabinet = emp.Cabinet
                };
                EmployeesList.Add(empL);
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
                     PersonWindow window = new PersonWindow(new Employee());
                      if (window.ShowDialog() == true)
                      {
                          using (RoadOfRussiaContext db = new RoadOfRussiaContext())
                          {
                             
                          }
                      }
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
                      EmployeeForList employee = o as EmployeeForList;
                      Employee emp = Employees.FirstOrDefault(x => x.IdEmployee == employee.IdEmployeeForList)!;
                      PersonWindow window = new PersonWindow(emp);
                      window.Show();
                     
                  }));
            }
        }
    }
}
