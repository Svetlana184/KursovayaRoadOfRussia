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
                      if (SelectedEmployee.Password == RepeatPassword.Password)
                      {
                         
                          Task<string> message = Task.Run(() => Register(SelectedEmployee));
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
