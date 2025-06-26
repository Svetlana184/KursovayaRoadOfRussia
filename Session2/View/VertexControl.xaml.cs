using Session2.Model;
using Session2.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Session2.View
{
    /// <summary>
    /// Логика взаимодействия для VertexControl.xaml
    /// </summary>
    public partial class VertexControl : UserControl
    {
        private NodeViewModel node;
        public NodeViewModel NodeViewModel 
        {
            get { return node; }
            set
            {
                node = value;
            }
        }
        public VertexControl()
        {
            InitializeComponent();
            NodeViewModel = new NodeViewModel();
            DataContext = NodeViewModel;
        }
    }
}
