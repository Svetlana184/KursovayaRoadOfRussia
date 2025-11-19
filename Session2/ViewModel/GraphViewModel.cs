using Desktop.Utilits;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Desktop.ViewModel
{
    public class GraphViewModel : ViewModelBase
    {
        public NodeViewModel v { get; }
        public int MaxLevel { get; set; }

        public List<NodeViewModel> vertices { get; } = new List<NodeViewModel>();
        public ObservableCollection<NodeViewModel> Nodes { get; } = new ObservableCollection<NodeViewModel>();

        public GraphViewModel(List<NodeViewModel> vertices_)
        {
            v = vertices_.FirstOrDefault(x => x.ParentDepartment == 1);
            vertices = vertices_;
            InitializeGraph();
            
        }
        public void InitializeGraph()
        {
            Nodes.Clear();
            
            CountingLevels();

            //добавление узлов 
            //AddNode(50, 20, v.Title);
            Nodes.Add(v);
            int y = 20;
            for (int i = 2; i <= MaxLevel; i++)
            {
                y += 75; int x = 50;
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (vertices[j].Level == i)
                    {
                        vertices[j].X = x;
                        vertices[j].Y = y;
                        Nodes.Add(vertices[j]);
                        x += 250;
                    }
                }
            }
            Application.Current.Dispatcher.Invoke(() => {
                foreach (var node in Nodes)
                {
                    node.OnPropertyChanged(nameof(node.X));
                    node.OnPropertyChanged(nameof(node.Y));
                    node.OnPropertyChanged(nameof(node.Title));
                }
            });
        }
        public void AddNode(double x, double y, string title)
        {
            Nodes.Add(new NodeViewModel {  X = x, Y = y, Title = title });
        } 
        public void CountingLevels()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].ParentDepartment == 987)
                    vertices[i].Level = 2;
            }
            MaxLevel = 2;
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    if (vertices[i].Department == vertices[j].ParentDepartment)
                    {
                        vertices[j].Level = vertices[i].Level + 1;
                        if (vertices[j].Level > MaxLevel) MaxLevel = vertices[j].Level;

                    }
                }
            }
        }
    }
}
