using Desktop.Model;
using Desktop.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
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

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для VertexControl.xaml
    /// </summary>
    public partial class VertexControl : UserControl
    {
        public static readonly DependencyProperty NodeViewModelProperty =
            DependencyProperty.Register("NodeViewModel", typeof(NodeViewModel), typeof(VertexControl),
            new PropertyMetadata(null, OnNodeViewModelChanged));

        public NodeViewModel NodeViewModel
        {
            get => (NodeViewModel)GetValue(NodeViewModelProperty);
            set => SetValue(NodeViewModelProperty, value);
        }

        public VertexControl()
        {
            InitializeComponent();
            Loaded += (s, e) => {
                DataContext = NodeViewModel ?? DataContext;
            };
        }
        private static void OnNodeViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is VertexControl control)
            {
                control.DataContext = e.NewValue;
            }
        }
    }
}
