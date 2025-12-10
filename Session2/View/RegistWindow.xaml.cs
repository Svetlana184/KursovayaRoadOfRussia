using Desktop.Model;
using Desktop.Services;
using Microsoft.IdentityModel.Tokens;
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

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        public RegistWindow()
        {
            InitializeComponent();
        }
        private void Hyperlink_MouseDown_1(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("При закрытии программы несохраненные изменения не сохранятся. " +
                "Выйти из программы?",
            "Подтверждение выхода",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }
    }
}
