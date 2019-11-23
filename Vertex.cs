using System;
using System.Collections.Generic;

namespace Graph
{
    public class Vertex
    {
        public int key;
        public List<Vertex> edges = new List<Vertex>();
        public Vertex parent;
        public char color;
        public double Weight;
        public double Distance;


        public Vertex(string key)
        {
            this.key = Int32.Parse(key);
            this.color = 'w';
            this.Distance = double.MaxValue;
            
        }

        public override string ToString()
        {
            return key.ToString();
        }

        public void AddNeighbor(Vertex vertex)
        {
            if (!edges.Contains(vertex))
            {
                this.edges.Add(vertex);
            }
        }

        public void AddParent(Vertex vertex)
        {
            this.parent = vertex;
        }
    }
}
