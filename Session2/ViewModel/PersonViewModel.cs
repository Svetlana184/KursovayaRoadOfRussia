using Microsoft.EntityFrameworkCore;
using Session2.Model;
using Session2.Services;
using Session2.Utilits;
using Session2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Session2.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        public Employee Employee { get;set; }

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Department> Deps { get; set; }
        public bool IsEditable { get; set; }
        public EmployeeForForm EmployeeForForm { get; set; }
        public EmployeeService employeeService;
        public DepartmentService departmentService;
        private RelayCommand changeEditability;
        public RelayCommand ChangeEditability
        {
            get
            {
                return changeEditability ??
                  (changeEditability = new RelayCommand((o) =>
                  {
                      if (IsEditable) IsEditable = false;
                      else IsEditable = true;
                  }));
            }
        }
        private RelayCommand addEmp;
        public RelayCommand AddEmp
        {
            get
            {
                return addEmp ??
                  (addEmp = new RelayCommand((o) =>
                  {
                      Employee = new Employee
                      {
                          Surname = EmployeeForForm.Surname_,
                          FirstName = EmployeeForForm.Firstname_,
                          SecondName = EmployeeForForm.Secondname_,
                          Position = EmployeeForForm.Position_,
                          PhoneWork = EmployeeForForm.Phonework_,
                          Phone = EmployeeForForm.Phone_,
                          Email = EmployeeForForm.Email_,
                          Other = EmployeeForForm.Other_,
                          BirthDay = EmployeeForForm.Birthday_,
                          IdDepartment = Deps.FirstOrDefault(x=> x.DepartmentName == EmployeeForForm.Department_)!.IdDepartment
                      };
                      employeeService.Add(Employee);
                  }));
            }
        }
        public PersonViewModel(Employee employee)
        {
            IsEditable = false;
            Employee = employee;
            employeeService = new EmployeeService();
            departmentService = new DepartmentService();
            Load();
            if(Employee != null)
            {
                EmployeeForForm = new EmployeeForForm
                {
                    IdEmployeeForForm = Employee.IdEmployee,
                    Surname_ = Employee.Surname,
                    Firstname_ = Employee.FirstName,
                    Secondname_ = Employee.SecondName,
                    Position_ = Employee.Position,
                    Phonework_ = Employee.PhoneWork,
                    Phone_ = Employee.Phone,
                    Email_ = Employee.Email,
                    Other_ = Employee.Other,
                    Birthday_ = Employee.BirthDay,
                    Department_ = "ttt",
                    //Boss_ = Employees.FirstOrDefault(x => x.IdEmployee == Employee.IdBoss)!.Surname,
                    //Helper_ = Employees.FirstOrDefault(x => x.IdEmployee == Employee.IdHelper)!.Surname,


                };
            }
            
        }
        private void Load()
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                Employees = new ObservableCollection<Employee>(employeeService.GetAll());
                Deps = new ObservableCollection<Department>(departmentService.GetAll());
            }
        }
    }
}
