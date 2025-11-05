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
using Desktop.Services;
using Session2.Model;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        public AuthService authService { get; set; }
        public RegistWindow()
        {
            InitializeComponent();
            authService = new AuthService();
        }

       
        private void Hyperlink_MouseDown_1(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Password == RepeatPassword.Password)
            {
                Employee employee = new Employee
                {
                    Password = Password.Password,
                    Email = Login.Text,
                    Surname = "ad",
                    FirstName = "start",
                    Position = "administrator",
                    PhoneWork = "+0",
                    Cabinet = "0",
                    IdDepartment = 1
                };
                Task<string> message = Task.Run(() => Register(employee));
                MessageBox.Show(message.Result);
                this.Close();

            }
                
        }
        private async Task<string> Register(Employee employee)
        {
          
                return await authService.Register(employee);
        }
    }
}
