using System;
using System.Collections.Generic;
using Priority_Queue;

namespace Graph
{
    public class Graph
    {
        public Dictionary<string, Vertex> gDict = new Dictionary<string, Vertex>();
        public List<string> toppo = new List<string>();
        public void AddVertex(string vertex)
        {
            if (!(gDict.ContainsKey(vertex.ToString())))
              {
                var v = new Vertex(vertex)
                {
                    color = 'w'
                };
                this.gDict[vertex] = v;
              }
        }

        public void AddEdge(string fromV, string toV)
        {
            if(!(gDict.ContainsKey(fromV)))
            {
                AddVertex(fromV);
                var to = new Vertex(toV);
                if (!(gDict.ContainsKey(toV)))
                {
                    AddVertex(toV);
                }
                gDict[fromV].AddNeighbor(to);
                gDict[toV].AddNeighbor(new Vertex(fromV));
            }
            else
            {
              if (!(gDict.ContainsKey(toV)))
                {
                    AddVertex(toV);
                    gDict[toV].AddNeighbor(new Vertex(fromV));
                }
                var to = new Vertex(toV);
                gDict[fromV].AddNeighbor(to);
                gDict[toV].AddNeighbor(new Vertex(fromV));

            }
        }

        public void AddDEdge(string fromV, string toV, string weight)
        {
            if (!(gDict.ContainsKey(fromV)))
            {
                AddVertex(fromV);
                var to = new Vertex(toV);
                to.Weight = Double.Parse(weight);
                gDict[fromV].AddNeighbor(to);
                
            }
            else
            {
                var to = new Vertex(toV);
                to.Weight = Double.Parse(weight);
                gDict[fromV].AddNeighbor(to);
            }
        }


        public void MSTPrim(string r)
        {
            this.gDict[r].Distance = 0;
            //SortedList<double, string> que = new SortedList<double, string>();
            SimplePriorityQueue<string> que = new SimplePriorityQueue<string>();
            foreach(string v in this.gDict.Keys)
            {
                que.Enqueue(this.gDict[v].ToString(), (float)this.gDict[v].Distance);
            }
            while(que.Count > 0)
            {
                string cV = que.Dequeue();
                foreach(Vertex neighbor in this.gDict[cV].edges)
                {
                    double cost = neighbor.Weight;
                    if(que.Contains(neighbor.ToString()) && cost < this.gDict[neighbor.ToString()].Distance)
                    {
                        this.gDict[neighbor.ToString()].AddParent(this.gDict[cV]);
                        this.gDict[neighbor.ToString()].Distance = cost;
                        que.UpdatePriority(neighbor.ToString(), (float)cost);
                    }
                }
            }
        }

        public void DFS()
        {
            string[] keys = new string[this.gDict.Keys.Count];
            this.gDict.Keys.CopyTo(keys, 0);
            Array.Sort(keys);
            foreach (string v in keys)//this.gDict.Keys)
            {
                if(this.gDict[v].color=='w')
                {
                    DFSVisit(this.gDict[v]);
                }
            }
        }

        public void DFSVisit(Vertex v)
        {
            this.gDict[v.ToString()].color = 'g';
            foreach(Vertex edge in this.gDict[v.ToString()].edges)
            {
                if(this.gDict[edge.ToString()].color=='w')
                {
                    this.gDict[edge.ToString()].parent = v;
                    DFSVisit(edge);
                }
            }
            v.color = 'b';
            toppo.Insert(0, v.ToString());

        }


        public void BFS(string start)
        {
            Queue<Vertex> que = new Queue<Vertex>();
            Vertex startV = gDict[start];
            startV.color = 'g';
            //HashSet<int> visited = new HashSet<int>();
            que.Enqueue(startV);
            while(que.Count>0)
            {
                Vertex neighbor = que.Dequeue();//gDict[que.Dequeue().ToString()];
                foreach(var edge in neighbor.edges)//(int i = 0;i<neighbor.edges.Count;i++)
                {
                    //var edgeAr = neighbor.edges.ToArray();
                    if (gDict[edge.ToString()].color=='w')//(edgeAr[i].key)))
                    {
                        //this.gDict[edgeAr[i].ToString()].AddParent(gDict[neighbor.ToString()]);
                        gDict[edge.ToString()].color = 'g';
                        this.gDict[edge.ToString()].AddParent(gDict[neighbor.ToString()]);
                        //que.Enqueue(gDict[edgeAr[i].ToString()]);
                        que.Enqueue(gDict[edge.ToString()]);
                    }
                    //visited.Add(neighbor.key);
                }
                //visited.Add(neighbor.key);
                gDict[neighbor.ToString()].color = 'b';
            }
            //int[] vArr = new int[visited.Count];
            //visited.CopyTo(vArr);
            //return visited.ToArray();
            //return visited;
        }

        public void PrintPath(string from, string to,List<string> path)
        {
            path.Add(to.ToString());
            if (gDict[from].key == gDict[to].key)
            {    
                Console.WriteLine("Path found");
                Console.Write(from.ToString() + " ");
               
            }
            else if (gDict[to].parent == null)
            {
                Console.WriteLine("No path found");
            }
            else
            {

                PrintPath(from, gDict[to].parent.ToString(),path);
                Console.Write(to.ToString() + " ");

            }

        }


        public void PrintMSTPath(string vertex)
        {
            Console.Write(this.gDict[vertex].ToString()+ "("+this.gDict[vertex].Distance +")");
            while(this.gDict[vertex].parent!=null)
            {
                Console.Write("-->" + this.gDict[vertex].parent.ToString() + "("+ this.gDict[vertex].parent.Distance + ")");
                vertex = this.gDict[vertex].parent.ToString();
            }
            Console.WriteLine();
        }
    }
}
