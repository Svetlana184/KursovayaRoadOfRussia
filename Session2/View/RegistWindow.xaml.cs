using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Desktop.Model;
using Desktop.Services;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        private AuthService authService;

        public RegistWindow()
        {
            InitializeComponent();
            authService = new AuthService();
        }

       
        private void Hyperlink_MouseDown_1(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Password.Password == RepeatPassword.Password)
            {
                Employee employee = new Employee
                {
                    Surname = Surname.Text,
                    FirstName = Firstname.Text,
                    SecondName = Secondname.Text,
                    Position = Position.Text,
                    PhoneWork = Phone.Text,
                    Cabinet = Cabinet.Text,
                    Email = Email.Text,
                    IdDepartment = int.Parse(Department.Text),
                    Password = Password.Password
                };
                Task<string> message = Task.Run(() => Register(employee));
            }
            Close();
        }
        
        private async Task<string> Register(Employee employee)
        {
            return await authService.Register(employee);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();        
        }
    }
}
