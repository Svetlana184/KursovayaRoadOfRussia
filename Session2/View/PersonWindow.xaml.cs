using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;

using Desktop.Model;
using Desktop.ViewModel;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для PersonWindow.xaml
    /// </summary>
    /// 
    public partial class PersonWindow : Window
    {
        public PersonWindow(Employee employee, int depid)
        {
            InitializeComponent();
            DataContext = new PersonViewModel(employee, depid);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
