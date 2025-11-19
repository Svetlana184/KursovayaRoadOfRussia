using Desktop.Model;
using Desktop.Services;
using Desktop.Utilits;
using Desktop.View;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Desktop.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private string titlewindow;
        public string TitleWindow
        {
            get { return titlewindow; }
            set
            {
                titlewindow = value;
                OnPropertyChanged(nameof(TitleWindow));
            }
        }
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
        private List<Employee> employeeslist;
        public List<Employee> EmployeesList 
        {
            get { return employeeslist; }
            set
            {
                employeeslist = value;
                OnPropertyChanged(nameof(EmployeesList));
            }
        }
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
        private int depid;
        public int Depid
        {
            get { return depid; }
            set
            {
                depid = value;
                OnPropertyChanged(nameof(Depid));
            }
        }
        public MainViewModel()
        {
            LoadData();
            Load();
        }
        private void LoadData()
        {
            employeeService = new EmployeeService();
            departmentService = new DepartmentService();

            try
            {
                Employees = null;
                Task<List<Employee>> task_emp = Task.Run(() => employeeService.GetAll());
                Employees = new ObservableCollection<Employee>(task_emp.Result);
                Deps = null;
                Task<List<Department>> task_dep = Task.Run(() => departmentService.GetAll());
                Deps = new ObservableCollection<Department>(task_dep.Result);

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Load()
        {
            Vertices = new List<NodeViewModel>();
           

            
                TitleWindow = "Организацонная структура";
                foreach (Department dep in Deps)
                {
                    if (dep.IdDepartmentParent != 0)
                    {
                        NodeViewModel? vv = new NodeViewModel
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
                        NodeViewModel v = new NodeViewModel
                        {
                            Department = dep.IdDepartment,
                            Level = 1,
                            ParentDepartment = 0,
                            Title = dep.DepartmentName,
                            X = 1,
                            Y = 1
                        };
                        Vertices.Insert(0, v);
                    }

                }
            EmployeesList = new List<Employee>();
                foreach (Employee emp in Employees)
                {

                    EmployeesList.Add(emp);
                }
                GraphVM = new GraphViewModel(Vertices);
            
            
           
        }
        public void FilterEmployeesByDepartment(int departmentId)
        {
            Depid = departmentId;
            List<Department> depList = new List<Department>();

            depList.Add(Deps.FirstOrDefault(p => p.IdDepartment == Depid)!);

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
                     PersonWindow window = new PersonWindow(new Employee(), Depid);
                      int x = 0;
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
        private RelayCommand? updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand((o) =>
                  {
                      Load();
                      OnPropertyChanged(nameof(EmployeesList));
                  }));
            }
        }
       

    }
}
