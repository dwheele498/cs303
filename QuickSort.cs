using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project3
{
    class QuickSortClass
    {
       public void QuickSort(int[] array, int p, int r)
        {
            if(p < r)
            {
                int q = Partition(array, p, r);
                QuickSort(array, p, q - 1);
                QuickSort(array, q + 1, r);
            }
        }

        public void MedianQuickSort(int[] array, int p, int r)
        {
            if(p<r)
            {
                int n = r - p + 1;
                int m = Median3(array, p, p + n / 2, r);
                int temp1 = array[r];
                array[r] = array[m];
                array[m] = temp1;
                int q = Partition(array, p, r);
                MedianQuickSort(array, p, q - 1);
                MedianQuickSort(array, q + 1, r);
            }
        }

        public int Median3(int[] array, int i, int j, int k)
        {
            int[] temp = { i, j, k };
            Array.Sort(temp);

            return temp[1];
        }

       public int Partition(int[] array, int p, int r)
        {
            int x = array[r];
            int i = p - 1;
            for(int j = p; j<r;j++)
            {
                if(array[j] <= x)
                {
                    i = i + 1;
                    int temp1 = array[j];
                    array[j] = array[i];
                    array[i] = temp1;
                }
            }
            int temp = array[r];
            array[r] = array[i + 1];
            array[i + 1] = temp;


            return i + 1;
        }
        

        public void DriverSrtRstRnd(string[] array)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < array.Length; i++)
            {
                HeapSortClass heapSortClass = new HeapSortClass();
                int[] qs = heapSortClass.CheckFile(array[i]);
                timer.Start();
                QuickSort(qs,0,qs.Length-1);
                timer.Stop();
                Console.WriteLine(timer.Elapsed + " for file " + array[i]);
                 using (StreamWriter streamWriter = File.AppendText("QuickSortSrtRstRnd.txt"))
                 {
                     streamWriter.WriteLine(timer.Elapsed + " for file " + array[i]);
                 }
                timer.Reset();

            }
        }

        public void MedianDriverSrtRstRnd(string[] array)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < array.Length; i++)
            {
                HeapSortClass heapSortClass = new HeapSortClass();
                int[] qs = heapSortClass.CheckFile(array[i]);
                timer.Start();
                MedianQuickSort(qs, 0, qs.Length - 1);
                timer.Stop();
                Console.WriteLine(timer.Elapsed + " for file " + array[i] + " using Median of 3");
                using (StreamWriter streamWriter = File.AppendText("MedianQuickSortSrtRstRnd.txt"))
                {
                    streamWriter.WriteLine(timer.Elapsed + " for file " + array[i]);
                }
                timer.Reset();

            }
        }

        public void Driver(string[] array)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < array.Length; i++)
            {
                HeapSortClass heapSortClass = new HeapSortClass();
                int[] qs = heapSortClass.CheckFile(array[i]);
                timer.Start();
                QuickSort(qs, 0, qs.Length - 1);
                timer.Stop();
                Console.WriteLine(timer.Elapsed + " for size " + qs.Length);
                using (StreamWriter streamWriter = File.AppendText("QuickSort.txt"))
                {
                    streamWriter.WriteLine(timer.Elapsed + " for size " + qs.Length);
                }
                timer.Reset();

            }
        }

        public void MedianDriver(string[] array)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < array.Length; i++)
            {
                HeapSortClass heapSortClass = new HeapSortClass();
                int[] qs = heapSortClass.CheckFile(array[i]);
                timer.Start();
                MedianQuickSort(qs, 0, qs.Length - 1);
                timer.Stop();
                Console.WriteLine(timer.Elapsed + " for size " + qs.Length + " using Median of 3");
                using (StreamWriter streamWriter = File.AppendText("MedianQuickSort.txt"))
                {
                    streamWriter.WriteLine(timer.Elapsed + " for size " + qs.Length);
                }
                timer.Reset();

            }
        }
        static void Main()
        {
            QuickSortClass quickSortClass = new QuickSortClass();
            /**int[] test = { 25, 36, 14, 3, 87 };
            //quickSortClass.QuickSort(test, 0, test.Length-1);
            quickSortClass.MedianQuickSort(test, 0, test.Length - 1);
            for(int i =0;i<test.Length;i++)
            {
                Console.Write(test[i] + " ");
            }*/

            string[] files = { "Input_Random.txt", "Input_ReversedSorted.txt", "Input_Sorted.txt" };
            string[] filesCompare = { "input_100.txt", "input_1000.txt", "input_5000.txt", "input_10000.txt", "input_50000.txt","input_100000.txt","input_500000.txt"};

           /** quickSortClass.DriverSrtRstRnd(files);
            quickSortClass.MedianDriverSrtRstRnd(files);
            quickSortClass.MedianDriver(filesCompare);
            quickSortClass.Driver(filesCompare);
    */
            HeapSortClass heapSortClass = new HeapSortClass();
            heapSortClass.Driver(filesCompare);

            Console.ReadKey();
        }
    }


    
}
