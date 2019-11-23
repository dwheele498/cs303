using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Graph
{
    class MainClass
    {
        public List<string> FileRead(string filePath, List<string> l1)
        {
            char[] splitter = { '\n', '\r', ',' };
            Random random = new Random();
            StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
            while (!streamReader.EndOfStream)
            {
                string readLine = streamReader.ReadLine();

                if (!String.IsNullOrWhiteSpace(readLine))
                {
                    l1.Add(readLine);
                }

            }

            return l1;
        }

        public Graph GraphMake(List<string> l1)
        {
            char[] splitter = { '\n', '\r', ',',' ' };
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();


            for (int i = 2; i < l1.Count-1; i++)
            {
                string[] temp = l1[i].Split(splitter);
                list1.Add(temp[0]);
                list2.Add(temp[1]);
            }
            var a1 = list1.ToArray();
            var a2 = list2.ToArray();
            Graph graph = new Graph();
            for (int i = 0; i < a1.Length; i++)
            {
                graph.AddEdge(a1[i], a2[i]);
               
            }
            return graph;

        }

        public Graph DGraphMake(List<string> l1)
        {
            char[] splitter = { '\n', '\r', ',', ' ' };
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();


            for (int i = 2; i < l1.Count - 1; i++)
            {
                string[] temp = l1[i].Split(splitter);
                List<string> tempClean = new List<string>();
                foreach(string s in temp)
                {
                    if(s!="")
                    {
                        tempClean.Add(s);
                    }
                }
                list1.Add(tempClean[0]);
                list2.Add(tempClean[1]);
                list3.Add(tempClean[2]);
            }
            var a1 = list1.ToArray();
            var a2 = list2.ToArray();
            var a3 = list3.ToArray();
            Graph graph = new Graph();
            for (int i = 0; i < a1.Length; i++)
            {
                graph.AddDEdge(a1[i], a2[i],a3[i]);

            }
            return graph;

        }

        public void Driver(string filePath, List<string> l1,string startNode, string fileOut)
        {
            List<string> l2 = FileRead(filePath, l1);
            Graph graph = GraphMake(l2);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            graph.BFS(startNode);
            timer.Stop();
            Console.WriteLine("Breadth First Search for " + filePath + ": " + timer.Elapsed);
            //add loop to iterate through all the stuff and print the path for each.
            Vertex[] values = new Vertex[graph.gDict.Values.Count];
            graph.gDict.Values.CopyTo(values,0);
            List<string> path = new List<string>();
            for(int i = 0; i < graph.gDict.Count-1;i++)// Vertex vertex in graph.gDict.Values)
            {
                timer.Restart();
                graph.PrintPath(startNode,values[i].ToString(),path);//vertex.ToString());
                timer.Stop();
                Console.WriteLine();
                using (StreamWriter streamWriter = File.AppendText(fileOut))
                {
                    streamWriter.WriteLine("Path search from " + startNode +" to " + values[i].ToString() /**vertex.ToString()*/ + ": " + timer.Elapsed);
                }

            }
            
        }

        public void DFSDriver(string filePath, List<string> l1, string startNode, string fileOut)
        {
            List<string> l2 = FileRead(filePath, l1);
            Graph graph = GraphMake(l2);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            //graph.BFS(startNode);
            graph.DFS();
            timer.Stop();
            Console.WriteLine("Breadth First Search for " + filePath + ": " + timer.Elapsed);
            //add loop to iterate through all the stuff and print the path for each.
            Vertex[] values = new Vertex[graph.gDict.Values.Count];
            graph.gDict.Values.CopyTo(values, 0);
            List<string> path = new List<string>();
            for (int i = 0; i < graph.gDict.Count - 1; i++)// Vertex vertex in graph.gDict.Values)
            {
                timer.Restart();
                graph.PrintPath(startNode, values[i].ToString(),path);//vertex.ToString());
                timer.Stop();
                Console.WriteLine();
                using (StreamWriter streamWriter = File.AppendText(fileOut))
                {
                    streamWriter.WriteLine("Path search from " + startNode + " to " + values[i].ToString() /**vertex.ToString()*/ + ": " + timer.Elapsed);
                }

            }

        }

        public void DirectedDriver(string filePath, List<string> l1, string startNode, string fileOut)
        {
            List<string> l2 = FileRead(filePath, l1);
            Graph graph = DGraphMake(l2);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            graph.DFS();
            timer.Stop();
            Console.WriteLine("Breadth First Search for " + filePath + ": " + timer.Elapsed);
            //add loop to iterate through all the stuff and print the path for each.
            Vertex[] values = new Vertex[graph.gDict.Values.Count];
            graph.gDict.Values.CopyTo(values, 0);
            List<string> path = new List<string>();
            /** for (int i = 0; i < graph.gDict.Count - 1; i++)// Vertex vertex in graph.gDict.Values)
             {
                 timer.Restart();
                 graph.PrintPath(startNode, values[i].ToString(),path);//vertex.ToString());
                 timer.Stop();
                 Console.WriteLine();
                 using (StreamWriter streamWriter = File.AppendText(fileOut))
                 {
                     streamWriter.WriteLine("Path search from " + startNode + " to " + values[i].ToString() /**vertex.ToString()/ + ": " + timer.Elapsed);
                 }

             }*/
            Console.WriteLine("Toplogical search results");
            foreach(string s in graph.toppo)
            {
                Console.Write(s + ", ");
            }

        }

        public void DirectedWeightedDriver(string filePath, List<string> l1, string startNode,string outPath)
        {
            List<string> l2 = FileRead(filePath, l1);
            Graph graph = DGraphMake(l2);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            graph.MSTPrim(startNode);
            timer.Stop();
            Console.WriteLine("Prim's Algorithm for " + filePath + ": " + timer.Elapsed);
            using (StreamWriter streamWriter = File.AppendText(outPath))
            {
                streamWriter.WriteLine("Prim's Algorithm for " + filePath + ": " + timer.Elapsed);
            }
            Vertex[] values = new Vertex[graph.gDict.Values.Count];
            graph.gDict.Values.CopyTo(values, 0);
            foreach( var v in values)
            {
                graph.PrintMSTPath(v.ToString());
            }

            
         

        }

        public static void Main(string[] args)
        {
            var mc = new MainClass();
            List<string> medium = new List<string>();
            List<string> large = new List<string>();
            List<string> tiny = new List<string>();
            List<string> xLarge = new List<string>();
            //mc.DFSDriver("mediumG.txt", medium, "0", "mediumResults.txt");
            List<List<string>> lists = new List<List<string>>();
            lists.Add(medium);
            lists.Add(large);
            lists.Add(xLarge);
            string[] fileNames = { "mediumDG.txt", "largeDG.txt", "XtraLargeDG.txt" };
            string[] results = { "mediumResults.txt", "largeResults.txt", "XLResults.txt" };

            mc.DirectedWeightedDriver("tinyDG.txt", tiny, "0","tinyResults.txt");
          /**for(int i =0; i < fileNames.Length;i++)
            {
                mc.DirectedWeightedDriver(fileNames[i], lists[i], "0",results[i]);
            }*/

            
        


            Console.ReadKey();
        }
    }
}
