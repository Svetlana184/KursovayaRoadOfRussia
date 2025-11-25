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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

   

        
        private void Hyperlink_MouseDown_1(object sender, RoutedEventArgs e)
        {
            RegistWindow regWindow = new RegistWindow();
            regWindow.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
