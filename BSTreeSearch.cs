using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BTSC
{
    class BSTreeSearch
    {
        public void Insert(BSTree tree, Node node)
        {
            Node y = null;
            Node x = tree.root;
            tree.size++;

            while(x!=null)
            {
                y = x;
                if(node.key<x.key)
                {
                    x = x.left;
                }
                else { x = x.right; }
            }
            node.parent = y;
            if(y==null)
            {
                tree.root = node;
            }
            else if(node.key < y.key)
            {
                y.left = node;
            }
            else
            {
                y.right = node;
            }
        }

        public void InOrderTreeWalk(Node node)
        {
            if(node!=null)
            {
                InOrderTreeWalk(node.left);
                Console.WriteLine(node.key + " " + node.data);
                InOrderTreeWalk(node.right);
            }
        }

        public Node TreeSearch(Node node,long key)
        {
            if(node==null || key==node.key)
            {
                return node;
            }
            if (key < node.key)
            {
                return TreeSearch(node.left, key);
            }
            else return TreeSearch(node.right, key);
        }


        public void CheckList(string filePath,List<string>l1, List<string>l2)
        {
            char[] splitter = { '\n', '\r', ','};
            StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
                  

            while (!streamReader.EndOfStream)
            {
                string readLine = streamReader.ReadLine();
                
                if (!String.IsNullOrWhiteSpace(readLine))
                {
                    string[] input = readLine.Split(splitter);
                    string holding = "";

                    for (int i = 0; i < input.Length; i++)
                    {
                        
                        if (i == 0)
                        {
                            l1.Add(input[i].Trim());
                        }
                        else
                        {
                            holding += input[i];
                        }

                        
                    }
                    l2.Add(holding);
                }
            }
            
        }

        public BSTree RandomChoiceTree(string filePath, List<string> l1, List<string> l2)
        {
            char[] splitter = { '\n', '\r', ',' };
            Random random = new Random();
            StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();


            while (!streamReader.EndOfStream)
            {
                string readLine = streamReader.ReadLine();
                
                if (!String.IsNullOrWhiteSpace(readLine))
                {
                   l1.Add(readLine);
                }

            }

            for(int i = 0; i<10000; i++)
            {
                l2.Add(l1[random.Next(0, l1.Count)]);
            }

            for(int i =0;i<l2.Count;i++)
            {
                string[] temp = l2[i].Split(splitter);
                string holding = "";
                for (int j = 0; j < temp.Length; j++)
                {

                    if (j == 0)
                    {
                        list1.Add(temp[j]);
                    }
                    else
                    {
                        holding += (temp[j] + " ");
                    }


                }
                list2.Add(holding);
            }
            var a1 = list1.ToArray();
            var a2 = list2.ToArray();
            BSTree bsTree = new BSTree();
            for (int i = 0; i < a1.Length; i++)
            {
                Node node = new Node(long.Parse(a1[i]), a2[i]);
                Insert(bsTree, node);
            }

            return bsTree;

        }

        public string[] MakeCheckList(string filePath, List<string> l1)
        {
            char[] splitter = { '\n', '\r', ',' };
            StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
    
            while (!streamReader.EndOfStream)
            {
                string readLine = streamReader.ReadLine();

                if (!String.IsNullOrWhiteSpace(readLine))
                {
                    string[] input = readLine.Split(splitter);
                    

                   
                    for (int i = 0; i < input.Length; i++)
                    {

                        if (i == 0)
                        {
                            l1.Add(input[i].Trim());
                        }
                    }
                }
            }
            return l1.ToArray();

        }

        public void Driver(string[] checkList, BSTree bSTree)
        {
            var timer = new Stopwatch();
            for(int i =0;i<checkList.Length;i++)
            {
                timer.Start();
                Node result = TreeSearch(bSTree.root, long.Parse(checkList[i]));
                timer.Stop();
                if(result==null)
                {
                    Console.Write("Node not found within Tree ");
                    Console.WriteLine("Time of search: " + timer.Elapsed);
                    timer.Reset();
                }
                else
                {
                    Console.Write("Found Key: " + result.key + " with data " + result.data + " ");
                    Console.WriteLine("Time of search: " + timer.Elapsed);
                    timer.Reset();
                }
            }
        }


        /**public static void Main()
        {
            int[] test = { 10, 7, 12, 4, 6, 22,2,18,5,8 };
            BSTreeSearch bsTreeSearch = new BSTreeSearch();
            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            List<string> l3 = new List<string>();
            /**bsTreeSearch.CheckList("input.dat",l1,l2);
            var a1 = l1.ToArray();
            var a2 = l2.ToArray();
            BSTree bsTree = new BSTree();
            for(int i = 0; i < a1.Length; i++)
            {
                Node node = new Node(long.Parse(a1[i]),a2[i]);
                bsTreeSearch.Insert(bsTree, node);
            }
            bsTreeSearch.InOrderTreeWalk(bsTree.root);

            Node result = bsTreeSearch.TreeSearch(bsTree.root, 2187682888);
            Console.WriteLine();
            Console.WriteLine(result.key + " " + result.data + " ");
            var checkList = bsTreeSearch.MakeCheckList("input.dat", l1);
            BSTree bSTree = bsTreeSearch.RandomChoiceTree("UPC.csv", l2, l3);
            bsTreeSearch.Driver(checkList, bSTree);

            Node node = bsTreeSearch.TreeSearch(bSTree.root, bSTree.root.left.right.left.right.key);
            Console.WriteLine(node.key + " " + node.data);

            Console.ReadKey();*/
        }

    }

