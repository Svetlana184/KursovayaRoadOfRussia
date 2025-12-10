using Microsoft.Identity.Client;
using Desktop.Model;
using Desktop.View;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("При закрытии программы несохраненные изменения не сохранятся. " +
                "Выйти из программы?",
            "Подтверждение выхода",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }
    }
}