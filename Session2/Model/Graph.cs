using Desktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop.Model
{
    struct Paint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Graph
    {
        public VertexControl v { get; }
        public List<VertexControl> vertices { get; set; }
        public int MaxLevel  { get; set; }

        public Graph(VertexControl _v)
        {
            this.v = _v;
            vertices = new List<VertexControl>();
        }
        public void AddVertex(VertexControl _v)
        {
            vertices.Add(_v);
        }
        
            
        
    }
}
