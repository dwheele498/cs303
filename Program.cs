using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace HashMap
{
    class Program 
    {

        public void CheckList(string filePath, List<string> l1, List<string> l2)
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

        public List<string> UPCMake(string filePath, List<string>l1)
        {
            char[] splitter = { '\n', '\r', ',' };
            Random random = new Random();
            StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
            //List<string> list1 = new List<string>();
            //List<string> list2 = new List<string>();



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

        public HashMap HashMapMake(List<string> l1)
        {
            char[] splitter = { '\n', '\r', ',' };
            //Random random = new Random();
            //StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
           


           /** while (!streamReader.EndOfStream)
            {
                string readLine = streamReader.ReadLine();

                if (!String.IsNullOrWhiteSpace(readLine))
                {
                    l1.Add(readLine);
                }

            }*/

           /** for (int i = 0; i < 50000; i++)
            {
                l2.Add(l1[random.Next(0, l1.Count)]);
            }*/


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
            HashMap hashmap = new HashMap();
            for (int i = 0; i < a1.Length; i++)
            {
               hashmap.Put(long.Parse(a1[i]), a2[i]);
                
            }
            //l1.Clear();
            return hashmap;

        }

        public HashMap LHashMapMake(List<string>l1)
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
                HashMap hashmap = new HashMap();
                for (int i = 0; i < a1.Length; i++)
                {
                    hashmap.LinearProbe(long.Parse(a1[i]), a2[i]);

                }
                
                return hashmap;

            }

        public HashMap QHashMapMake(List<string> l1)
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
            HashMap hashmap = new HashMap();
            for (int i = 0; i < a1.Length; i++)
            {
                hashmap.QuadraticProbe(long.Parse(a1[i]), a2[i]);

            }

            l1.Clear();
            return hashmap;

        }

        public void Driver(string[] checkList, HashMap hashMap)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < checkList.Length; i++)
            {
                timer.Start();
                string result = hashMap.Get(long.Parse(checkList[i]));
                timer.Stop();
                
                Console.Write("Found Key: " + checkList[i] + " with data " + result + " ");
                Console.WriteLine("Time of search: " + timer.Elapsed);
                timer.Reset();
                
            }
        }

        public void LDriver(string[] checkList, HashMap hashMap)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < checkList.Length; i++)
            {
                timer.Start();
                string result = hashMap.LGet(long.Parse(checkList[i]));
                timer.Stop();

                Console.Write("Found Key: " + checkList[i] + " with data " + result + " ");
                Console.WriteLine("Time of search: " + timer.Elapsed);
                timer.Reset();

            }
        }

        public void QDriver(string[] checkList, HashMap hashMap)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < checkList.Length; i++)
            {
                timer.Start();
                string result = hashMap.QGet(long.Parse(checkList[i]));
                timer.Stop();

                Console.Write("Found Key: " + checkList[i] + " with data " + result + " ");
                Console.WriteLine("Time of search: " + timer.Elapsed);
                timer.Reset();

            }
        }

        static void Main()
        {
            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            List<string> upc = new List<string>();
            Program program = new Program();
            HashMap hashMap = new HashMap();
            HashMap lHash = new HashMap();
            HashMap qHash = new HashMap();
            //program.CheckList("input.dat", l1, l2);
            //var a1 = l1.ToArray();
            //var a2 = l2.ToArray();
            // var timer = new Stopwatch();

            /**for(int i = 0; i <a1.Length;i++)
            {
                HashEntry hashEntry = new HashEntry(long.Parse(a1[i]), a2[i]);
                var timer = Stopwatch.StartNew();
                hashMap.Put(hashEntry.GetKey(), hashEntry.GetValue());
                timer.Stop();
                Console.WriteLine(timer.Elapsed);
                

                
            }*/
            upc = program.UPCMake("UPC-random.csv", l2);
            string[] a1 = program.MakeCheckList("input.dat", l1);
            hashMap = program.HashMapMake(upc);
            lHash = program.LHashMapMake(upc);
            qHash = program.QHashMapMake(upc);

            Console.WriteLine("Search using standard get");
            program.Driver(a1, hashMap);
            Console.WriteLine("Search using linear get");
            program.LDriver(a1, lHash);
            Console.WriteLine("Search using quadratic get");
            program.QDriver(a1, qHash);


            //var result = hashMap.Get(2184000098);
            //Console.WriteLine(result);



            Console.ReadKey();
        }
    }
}
