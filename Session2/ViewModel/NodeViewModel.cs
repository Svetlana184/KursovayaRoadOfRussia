using Session2.Model;
using Session2.Services;
using Session2.Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Session2.ViewModel
{
    public class NodeViewModel : ViewModelBase
    {
        private double x_;
        public double X { get { return x_; } set { x_ = value; OnPropertyChanged(); } }
        private double y_;
        public double Y { get { return y_; } set { y_ = value; OnPropertyChanged(); } }
        private string title_;
        public string Title { get { return title_; } set { title_ = value; OnPropertyChanged(); } }

        private int level;
        public int Level { get { return level; } set { level = value; OnPropertyChanged(); } }

        private int? department;
        public int? Department { get { return department; } set { department = value; OnPropertyChanged(); } }
        private int? parentdepartment;
        public int? ParentDepartment { get { return parentdepartment; } set { parentdepartment = value; OnPropertyChanged(); } }
        private RelayCommand selectVertex;
        public RelayCommand SelectVertexCommand
        {
            get
            {
                return selectVertex ??
                  (selectVertex = new RelayCommand((o) =>
                  {
                      int depid = (int)o;
                  }));
            }
        }
    }
}
