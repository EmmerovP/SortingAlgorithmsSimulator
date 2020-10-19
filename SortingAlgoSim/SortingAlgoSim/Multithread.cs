using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class Multithread
    {
        //counter of generated SVG images
        public static int cnt;

        //method used to run sorting on n separate threads
        //we get a number of threads to sort on, unsorted array, and an object containing an algorithm to sort with
        public static void RunThreads(int threadCount, int[] array, SortingAlgorithm Sorting)
        {         
            cnt = 0;

            //get name of sorting algorithm from name of it's class
            string name = Sorting.GetType().Name;

            //generate first frame of unsorted array
            SVGgenerate.GenerateSVG(name, threadCount, cnt++, 0, 0, array, 0);

            //size of an subarray, which will be sorted by one thread
            int part = array.Length / threadCount;

            //an array containing borders of each part
            int[] parts = new int[threadCount];

            //array containing all threads we are sorting with
            Thread[] objThread = new Thread[threadCount];

            //Stopwatch for measuring sorting time
            var watch = new Stopwatch();
            watch.Start();

            //we create a thread for each part and add that thread to an array of threads
            for (int i = 0; i < threadCount - 1; i++)
            {
                //we save the iterator to new integer, else it's value would be non-deterministic in multithreading
                int c = i;

                Thread ThreadSorting = new Thread(() => Sorting.Sort(array, c * part, (c + 1) * part - 1, true));

                objThread[c] = ThreadSorting;

                parts[i] = (c + 1) * part - 1;

            }

            //we create last part, which is supposed to be bigger and contain last elements
            Thread LastThread = new Thread(() => Sorting.Sort(array, (threadCount - 1) * part, array.Length - 1, true));
            objThread[threadCount - 1] = LastThread;
            parts[threadCount - 1] = array.Length - 1;

            //starting of all threads
            foreach (var thread in objThread)
            {
                thread.Start();
            }

            //waiting for all threads to finish
            foreach (var thread in objThread)
            {
                thread.Join();
            }

            //generate a picture of an array after it is sorted by threads
            //due to the non-deterministic nature of threads, we are not able to generate it sooner
            //however, the user can use sorting without multithreading to see the progress of each algorithm
            SVGgenerate.GenerateSVG(name, threadCount, cnt++, 0, 0, array, watch.ElapsedTicks);

            //Merge all threads together
            MergeThreads(array, threadCount, parts, name, watch);

            watch.Stop();

            //create an info file about this sorting
            InfoFile.CreateInfoFile(name, array.Length, watch.ElapsedTicks, 0, 0, threadCount);

        }

        //Merges all threads together
        public static void MergeThreads(int[] array, int count, int[] parts, string name, Stopwatch watch)
        {
            //we always merge the sorted block at the beginning with next block
            //the first block is getting bigger with each cycle
            for (int i = 0; i < count - 1; i++)
            {
                int[] temp = new int[array.Length];
                Array.Copy(array, temp, array.Length);
                Merge(array, temp, 0, parts[i], parts[i+1]);

                //after each merge, generate a svg image showing current progress
                SVGgenerate.GenerateSVG(name, count, cnt++, 0, 0, array, watch.ElapsedTicks);

            }
        }
      
        //Merging two parts of an array together
        public static void Merge(int[] array, int[] temp, int from, int mid, int end)
        {
            int i = from;
            int j = mid + 1;
            int k = from;

            //until we reach the mid with one counter and end with second
            while (i <= mid && j <= end)
            {
                //if left element is smaller than right, put this element in temporary array and increment left counter
                if (array[i] < array[j])
                {
                    temp[k++] = array[i++];
                }
                //if not, put there the right element and increment the right counter
                else
                {
                    temp[k++] = array[j++];
                }
            }
            
            //we copy the rest to the en dof an array
            if (i<=mid)
            {
                while (i<=mid)
                {
                    temp[k++] = array[i++];

                }
            }
            else
            {
                while (j<=end)
                {
                    temp[k++] = array[j++];

                }
            }

            //we move the sorted array from temp to an actual array
            for (i = from; i <= end; i++)
            {
                array[i] = temp[i];
            }
        }
    }
}
