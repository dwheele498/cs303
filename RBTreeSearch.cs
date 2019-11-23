using BTSC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BSTC
{
    class RBTreeSearch : BSTreeSearch
    {
        public void InOrderTreeWalk(RBNode node)
        {
            if (node != null)
            {
                InOrderTreeWalk(node.left);
                Console.WriteLine(node.key + " " + node.data + " is red? " + node.isRed);
                InOrderTreeWalk(node.right);
            }
        }

        public void Insert(RBTree tree, RBNode node)
        {
            RBNode y = null;
            RBNode x = tree.root;
            tree.size++;

            while (x != null)
            {
                y = x;
                if (node.key < x.key)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }
            node.parent = y;
            if (y == null)
            {
                tree.root = node;
            }
            else if (node.key < y.key)
            {
                y.left = node;
            }
            else
            {
                y.right = node;
            }
            node.left = null;
            node.right = null;
            node.isRed = true;
            RBInsertFixup(tree, node);
        }

        public void RBInsertFixup(RBTree tree, RBNode node)
        {
                while (node != tree.root && node.parent.isRed == true)
                {
                if (node.parent == node.parent.parent.left)
                {
                    RBNode y = node.parent.parent.right;
                    if (y != null && y.isRed == true)
                    {
                        node.parent.isRed = false;
                        y.isRed = false;
                        node.parent.parent.isRed = true;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if (node == node.parent.right)
                        {
                            node = node.parent;
                            LeftRotate(tree, node);
                        }

                        else
                        {

                            node.parent.isRed = false;
                            node.parent.parent.isRed = true;
                            RightRotate(tree, node.parent.parent);
                        }
                    }

                }

                else
                {
                    RBNode y = node.parent.parent.left;
                    if (y != null && y.isRed == true)
                    {
                        node.parent.isRed = false;
                        y.isRed = false;
                        node.parent.parent.isRed = true;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if (node == node.parent.left)
                        {
                            node = node.parent;
                            RightRotate(tree, node);
                        }

                        else
                        {

                            node.parent.isRed = false;
                            node.parent.parent.isRed = true;
                            LeftRotate(tree, node.parent.parent);
                        }
                    }
                }
                //tree.root.isRed = false;
            }
                tree.root.isRed = false;
            
        }

        public void LeftRotate(RBTree tree, RBNode node)
        {
            RBNode y = node.right;
            node.right = y.left;
            if(y.left!=null)
            {
                y.left.parent = node;
            }
            y.parent = node.parent;
            if(node.parent==null)
            {
                tree.root = y;
            }
            else if(node == node.parent.left)
            {
                node.parent.left = y;
            }
            else
            {
                node.parent.right = y;
            }
            y.left = node;
            node.parent = y;
        }

        public void RightRotate(RBTree tree, RBNode node)
        {
            RBNode y = node.left;
            node.left = y.right;
            if (y.right != null)
            {
                y.right.parent = node;
            }
            y.parent = node.parent;
            if (node.parent == null)
            {
                tree.root = y;
            }
            else if (node == node.parent.left)
            {
                node.parent.left = y;
            }
            else
            {
                node.parent.right = y;
            }
            y.right = node;
            node.parent = y;
        }

        public RBNode TreeSearch(RBNode node, long key)
        {
            if (node == null || key == node.key)
            {
                return node;
            }
            if (key < node.key)
            {
                return TreeSearch(node.left, key);
            }
            else return TreeSearch(node.right, key);
        }

        public void RBCheckList(string filePath, List<string> l1, List<string> l2)
        {
            char[] splitter = { '\n', '\r', ',' };
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

        public string[] RBMakeCheckList(string filePath, List<string> l1)
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

        public List<string> UPCMake(string filePath, List<string> l1)
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

        public RBTree TreeMake(List<string> l1)
        {
            char[] splitter = { '\n', '\r', ',' };
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();


            for (int i = 0; i < l1.Count; i++)
            {
                string[] temp = l1[i].Split(splitter);
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
            RBTree rBTree = new RBTree();
            for (int i = 0; i < a1.Length; i++)
            {
               RBNode node = new RBNode(long.Parse(a1[i]), a2[i]);
                Insert(rBTree, node);

            }
            //l1.Clear();
            return rBTree;

        }

        public void Driver(string[] checkList, RBNode root)
        {
            for(int i =0;i<checkList.Length;i++)
            {
                var timer = new Stopwatch();
                timer.Start();
               var node = TreeSearch(root, long.Parse(checkList[i]));
                timer.Stop();
                Console.WriteLine(node.key + " found in " + timer.Elapsed);
            }
        }


        public static void Main()
        {
            int[] test = { 10, 7, 12, 4, 6, 22, 2, 18, 5, 8 };
            RBTreeSearch bsTreeSearch = new RBTreeSearch();
            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            List<string> l3 = new List<string>();
            bsTreeSearch.CheckList("input.dat", l1, l2);
            var a1 = l1.ToArray();
            var a2 = l2.ToArray();
           RBTree bsTree = new RBTree();
         /**   for (int i = 0; i < a1.Length; i++)
            {
                RBNode node = new RBNode(long.Parse(a1[i]), a2[i]);
                bsTreeSearch.Insert(bsTree, node);
            }
            bsTreeSearch.InOrderTreeWalk(bsTree.root);*/
            
            var a3 = bsTreeSearch.RBMakeCheckList("input.dat", l3);
            l1.Clear();
            var upc = bsTreeSearch.UPCMake("UPC-random.csv", l1);
            RBTree rBTree2 = bsTreeSearch.TreeMake(upc);
            bsTreeSearch.Driver(a3, rBTree2.root);
            
            Console.ReadKey();
        }

    }
}
