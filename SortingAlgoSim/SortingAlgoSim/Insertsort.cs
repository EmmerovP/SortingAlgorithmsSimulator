using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class Insertsort : SortingAlgorithm
    {
        //Insertionsort algorithm implementation
        //Iterates through the array and when it encounters an element, puts it where it belongs in a sorted array.
        public void Sort(int[] array, int start, int end, bool threaded)
        {
            //in case of two steps sorting for singlethreaded run, we copy the contents of an array to an auxiliary one
            int[] insertarray;

            if (threaded)
            {
                insertarray = array;
            }
            else
            {
                insertarray = new int[array.Length];
                Array.Copy(array, insertarray, array.Length);
            }

            //a list for storing measured time
            List<long> time = new List<long>();

            //start measuring time from the beginning of sorting
            var watch = new Stopwatch();
            watch.Start();

            time.Add(watch.ElapsedTicks);

            //iterate through the current array
            for (int i = start; i < end; i++)
            {
                //get a current element
                int j = i + 1;
                int temp = insertarray[j];
                //iterate through a sorted array to a place where the current element belongs
                while (j > start && temp < insertarray[j - 1])
                {
                    //swap the elements to preserve a sorted array
                    insertarray[j] = insertarray[j - 1];
                    j--;
                    insertarray[j] = temp;
                    time.Add(watch.ElapsedTicks);
                }
            }

            watch.Stop();

            //in case of multithreaded sorting, we sorted required part of an array and can exit
            if (threaded)
            {
                return;
            }

            //run a second sorting, this time the duration is already measured, so we can create frames during the run

            int frame = 0;
            int comparisons = 0;
            int accesses = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                //get a current element
                int j = i + 1;
                int temp = array[j];
                accesses++;
                //iterate through a sorted array to a place where the current element belongs
                while (j > 0 && temp < array[j - 1])
                {
                    comparisons = comparisons + 2;
                    accesses = accesses + 2;

                    //swap the elements to preserve a sorted array
                    array[j] = array[j - 1];
                    j--;
                    array[j] = temp;

                    frame++;
                    SVGgenerate.GenerateSVG("insertsort", 0, frame, comparisons, accesses, array, time[frame]);
                }
            }
            //before we exit, we create an info file summarizing the result of an algorithm
            InfoFile.CreateInfoFile("insertionsort", array.Length, time.Last(), comparisons, accesses, 0);
        }
    }
}
