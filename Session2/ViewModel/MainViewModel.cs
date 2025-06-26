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
using System.Collections.Frozen;
namespace Session2.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        public NodeViewModel RootV;
        private List<NodeViewModel> vertices;
        public List<NodeViewModel> Vertices
        {
            get { return vertices; }
            set
            {
                vertices = value;
                OnPropertyChanged();
            }
        }
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
        private GraphViewModel graphwm;
        public GraphViewModel GraphVM
        {
            get
            {
                return graphwm;
            }
            set
            {
                graphwm = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            Vertices = new List<NodeViewModel>();
            employeeService = new EmployeeService();
            departmentService = new DepartmentService();
            Load();
            GraphVM = new GraphViewModel( RootV, Vertices);
            int X = 0;
        }
        private void Load()
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                Employees = new ObservableCollection<Employee>(employeeService.GetAll());
                Deps = new ObservableCollection<Department>(departmentService.GetAll());
            }
            foreach(Department dep in Deps)
            {
                if(dep.IdDepartmentParent != 0)
                {
                    NodeViewModel? vv =  new NodeViewModel
                    {
                        Department = dep.IdDepartment,
                        Level = 1,
                        ParentDepartment = dep.IdDepartmentParent,
                        Title = dep.DepartmentName,
                        X = 1,
                        Y = 1
                    };
                    Vertices.Add(vv);
                }
                else
                {
                    RootV = new NodeViewModel
                    {
                        Department = dep.IdDepartment,
                        Level = 1,
                        ParentDepartment = 0,
                        Title = dep.DepartmentName,
                        X = 1,
                        Y = 1
                    };

                }
               
            }
            EmployeesList = new List<Employee>();
            foreach(Employee emp in Employees)
            {
               
                EmployeesList.Add(emp);
            }
        }
        public void FilterEmployeesByDepartment(int departmentId)
        {
            int depId = departmentId;
            List<Department> depList = new List<Department>();

            depList.Add(Deps.FirstOrDefault(p => p.IdDepartment == depId)!);

            for(int i =0; i <=4; i++)
            {
                List<Department> childList = new List<Department>();
                foreach (Department v in depList)
                {
                    childList.AddRange(Deps.Where(p => p.IdDepartmentParent == v.IdDepartment));
                }
                depList.AddRange(childList);

            }

            List<Employee> listMain = new List<Employee>();

            foreach (Department d in depList)
            {
                
                listMain.AddRange(Employees.Where(p => p.IdDepartment == d.IdDepartment));
            }
            listMain.Sort();
            EmployeesList = listMain.Distinct().ToList();
            OnPropertyChanged(nameof(EmployeesList));

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
