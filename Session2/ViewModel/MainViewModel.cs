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
using System.Windows.Media;


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
        private string windowstate;
        public string WindowState
        {
            get { return windowstate; }
            set
            {
                windowstate = value;
                OnPropertyChanged(nameof(WindowState));
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
        private ObservableCollection<EmployeeCard> employeesList;
        public ObservableCollection<EmployeeCard> EmployeesList
        {
            get { return employeesList; }
            set
            {
                employeesList = value;
                OnPropertyChanged(nameof(EmployeesList));
            }
        }
        private EmployeeCard selectedemployee;
        public EmployeeService employeeService;
        public DepartmentService departmentService;
        public EmployeeCard SelectedEmployee
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
            WindowState = "Normal";
            LoadData();
            Load();

            PersonViewModel.EmployeeUpdated += OnEmployeeUpdated;
            PersonViewModel.EmployeeAdded += OnEmployeeUpdated;
        }

        private async void OnEmployeeUpdated()
        {
            int ex_depid = Depid;
            await Task.Run(() => LoadData());
            Load();
            
            OnPropertyChanged(nameof(EmployeesList));
            Depid = ex_depid;
            FilterEmployeesByDepartment(ex_depid);

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
           

            
                TitleWindow = "Организационная структура";
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
                EmployeesList = new ObservableCollection<EmployeeCard>();
                foreach (Employee emp in Employees)
                    {
                    if (emp.IsFired == null || DateTime.Now - DateTime.Parse(emp.IsFired.ToString()).AddDays(30) < TimeSpan.Zero)
                    {
                        EmployeeCard cardEmp = new EmployeeCard
                        {
                            IdEmployee = emp.IdEmployee,
                            Surname = emp.Surname,
                            FirstName = emp.FirstName,
                            SecondName = emp.SecondName,
                            Position = emp.Position,
                            PhoneWork = emp.PhoneWork,
                            Cabinet = emp.Cabinet,
                            Email = emp.Email,
                            IdDepartment = emp.IdDepartment
                        };
                        if (emp.IsFired != null)
                        {

                            cardEmp.Color = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                            cardEmp.Disabled = false;
                        }
                        else
                        {
                            cardEmp.Color = new SolidColorBrush(Color.FromRgb(120, 178, 75));
                            cardEmp.Disabled = true;
                        }
                        EmployeesList.Add(cardEmp);
                    }
                    
                }
                
            GraphVM = new GraphViewModel(Vertices);
            Depid = Deps.First().IdDepartment;
            
            
           
        }
        public void FilterEmployeesByDepartment(int departmentId)
        {
            Depid = departmentId;
            EmployeesList = new ObservableCollection<EmployeeCard>();
            List<Department> depList = new List<Department>();

            var department = Deps.FirstOrDefault(p => p.IdDepartment == Depid);
            if (department == null) return;

            depList.Add(department);

            for (int i =0; i <=4; i++)
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

                if (d != null)
                {
                    listMain.AddRange(Employees.Where(p => p.IdDepartment == d.IdDepartment));
                }
            }
            listMain.Sort();
            List<Employee> empsTemp = listMain.Distinct().ToList();
            foreach (Employee emp in empsTemp)
            {
                EmployeeCard cardEmp = new EmployeeCard
                {
                    IdEmployee = emp.IdEmployee,
                    Surname = emp.Surname,
                    FirstName = emp.FirstName,
                    SecondName = emp.SecondName,
                    Position = emp.Position,
                    PhoneWork = emp.PhoneWork,
                    Cabinet = emp.Cabinet,
                    Email = emp.Email,
                    IdDepartment = emp.IdDepartment,
                    Disabled = true
                };

                if (emp.IsFired != null)
                {
                    cardEmp.Color = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                    cardEmp.Disabled = false;
                }
                else
                {   
                    cardEmp.Color = new SolidColorBrush(Color.FromRgb(120, 178, 75));
                    
                }
                EmployeesList.Add(cardEmp);
            }
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
                      Employee new_emp = new Employee();
                      new_emp.IdDepartment = Deps.FirstOrDefault(p => p.IdDepartmentParent == null)!.IdDepartment;
                     PersonWindow window = new PersonWindow(new_emp, Depid);
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
                      if(o != null)
                      {
                          EmployeeCard employee = o as EmployeeCard;
                          PersonWindow window = new PersonWindow(employees.FirstOrDefault(p => p.IdEmployee == employee!.IdEmployee)!, employee!.IdDepartment);
                          window.Show();
                      }
                      
                      
                     
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
                      LoadData();
                      Load();
                      OnPropertyChanged(nameof(EmployeesList));
                  }));
            }
        }
        private RelayCommand? stateminCommand;
        public RelayCommand StateminCommand
        {
            get
            {
                return stateminCommand ??
                  (stateminCommand = new RelayCommand((o) =>
                  {
                      WindowState = "Minimized";
                  }));
            }
        }
        private RelayCommand? statemaxCommand;
        public RelayCommand StatemaxCommand
        {
            get
            {
                return statemaxCommand ??
                  (statemaxCommand = new RelayCommand((o) =>
                  {
                      if(WindowState == "Normal")
                      {
                          WindowState = "Maximized";
                      }
                      else
                      {
                          WindowState = "Normal";
                      }
                  }));
            }
        }

        private RelayCommand? closeWindowCommand;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ?? (
                    closeWindowCommand = new RelayCommand((o) => {
                        var result = MessageBox.Show("При закрытии программы несохраненные изменения будут утеряны. " +
                                "Выйти из программы?",
                            "Подтверждение выхода",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);

                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                Cleanup();
                                Application.Current.Shutdown();
                                break;
                            case MessageBoxResult.No:
                                return;
                        }

                    }));
            }
        }

        public void Cleanup()
        {
            PersonViewModel.EmployeeUpdated -= OnEmployeeUpdated;
            PersonViewModel.EmployeeAdded -= OnEmployeeUpdated;
        }

    }
}
