using Desktop.Utilits;
using Desktop.Model;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Desktop.View;

namespace Desktop.ViewModel
{
    public class NodeViewModel : ViewModelBase
    {
        private double x_;
        public double X { get { return x_; } set { x_ = value; OnPropertyChanged(nameof(X)); } }
        private double y_;
        public double Y { get { return y_; } set { y_ = value; OnPropertyChanged(nameof(Y)); } }
        private string title_;
        public string Title 
        { 
            get { return title_; } 
            set { 
                title_ = value;
                OnPropertyChanged(nameof(Title)); 
            } 
        }

        private int level;
        public int Level { get { return level; } set { level = value; OnPropertyChanged(nameof(Level)); } }

        private int? department;
        public int? Department { get { return department; } set { department = value; OnPropertyChanged(nameof(Department)); } }
        private int? parentdepartment;
        public int? ParentDepartment { get { return parentdepartment; } set { parentdepartment = value; OnPropertyChanged(nameof(ParentDepartment)); } }
        private RelayCommand selectVertex;
        public RelayCommand SelectVertexCommand
        {
            get
            {
                return selectVertex ??
                  (selectVertex = new RelayCommand((o) =>
                  {
                      if (o is int depId)
                      {
                          var mainVm = (MainViewModel)MainWindow.Instance.DataContext;
                          mainVm.FilterEmployeesByDepartment(depId);
                      }
                  }));
            }
        }
    }
}
