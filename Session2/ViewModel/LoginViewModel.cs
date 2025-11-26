using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Desktop.Model;
using Desktop.Services;
using Desktop.Utilits;
using Desktop.View;

namespace Desktop.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private AuthService authService;

        public LoginViewModel()
        {
            WindowState = "Normal";
            authService = new AuthService();
            Visibility = Visibility.Visible;
            int x = 0;
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

        private Visibility visibility;
        public Visibility Visibility
        {
            get { return visibility; }
            set 
            { 
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }
        private string? email;
        public string Email
        {
            get { return email!; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string? password;
        public string LoginPassword
        {
            get { return password!; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(LoginPassword));
            }
        }
        private RelayCommand? loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                  (loginCommand = new RelayCommand(async obj =>
                  {
                      PasswordBox? password = obj as PasswordBox;
                      HttpClient client = new HttpClient();
                      Employee user = new Employee { Surname= "дефолт", FirstName= "дефолт", SecondName = "дефолт", Position = "дефолт", PhoneWork="70000000000", Cabinet="000", IdDepartment=1, Email = Email, Password = password!.Password };
                      Response response = await authService.SignIn(user);
                      if (response != null)
                      {
                          RegisterUser.email= response.email;
                          RegisterUser.access_token = response.access_token;
                          Visibility = Visibility.Hidden; 
                          MainWindow window = new MainWindow();
                          window.Show();
                      }
                      else
                          MessageBox.Show("Пользователь с таким именем или паролем " +
                                  "не существует!");

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
    }
}
