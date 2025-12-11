using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Desktop.Model;
using Desktop.Services;
using Desktop.Utilits;
using Desktop.View;

namespace Desktop.ViewModel
{
    public class RegistViewModel : ViewModelBase
    {
        private AuthService authService;
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
        private string repeatPassword;
        public string RepeatPassword
        {
            get { return repeatPassword; }
            set { 
                repeatPassword = value; 
                OnPropertyChanged(nameof(RepeatPassword));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private User _employee;
        public User SelectedEmployee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        public DepartmentService departmentService;
        public ObservableCollection<Department> Deps { get; set; }
        private List<Department> deplist;
        public List<Department> DepList
        {
            get { return deplist; }
            set
            {
                deplist = value;
                OnPropertyChanged();
            }
        }

        public RegistViewModel() 
        {
            SelectedEmployee = new User();
            Deps = new ObservableCollection<Department>();
            WindowState = "Normal";
            authService = new AuthService();
            departmentService = new DepartmentService();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Task<List<Department>> task_dep = Task.Run(() => departmentService.GetAll());
                Deps = new ObservableCollection<Department>(task_dep.Result);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private RelayCommand? createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return createCommand ??
                  (createCommand = new RelayCommand(async obj =>
                  {
                      if (!string.IsNullOrEmpty(SelectedEmployee.Error))
                      {
                          MessageBox.Show(SelectedEmployee.Error);
                          return;
                      }
                      else
                      {
                          if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(RepeatPassword))
                          {
                              MessageBox.Show("Пожалуйста, заполните пароль и подтверждение пароля!");
                              return;
                          }
                          else
                          {
                              if (Password != RepeatPassword)
                              {
                                  MessageBox.Show("Пароли не совпадают!");
                                  return;
                              }
                              else
                              {
                                  try
                                  {
                                      SelectedEmployee.Password = Password;
                                   
                                      string result = await Register(SelectedEmployee);
                                      MessageBox.Show($"{result}");

                                      SelectedEmployee = new User();
                                      Password = string.Empty;
                                      RepeatPassword = string.Empty;
                                  }
                                  catch (Exception ex)
                                  {
                                      MessageBox.Show($"Ошибка при регистрации: {ex.Message}");
                                  }
                              }
                          }
                          
                      }
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
                      WindowState = WindowState == "Normal" ? "Maximized" : "Normal";
                  }));
            }
        }
        private async Task<string> Register(User employee)
        {
            return await authService.Register(employee);
        }

    }
}
