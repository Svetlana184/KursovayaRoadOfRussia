using System;
using System.Collections.Generic;
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
                Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private Employee _employee;
        public Employee SelectedEmployee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        public RegistViewModel() 
        {
            WindowState = "Normal";
            authService = new AuthService();
        }
        private RelayCommand? createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return createCommand ??
                  (createCommand = new RelayCommand(async obj =>
                  {
                      if (SelectedEmployee.Password == RepeatPassword)
                      {
                         
                          Task<string> message = Task.Run(() => Register(SelectedEmployee));
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
                      if (WindowState == "Normal")
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
        private async Task<string> Register(Employee employee)
        {
            return await authService.Register(employee);
        }

    }
}
