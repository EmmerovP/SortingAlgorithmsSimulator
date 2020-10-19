using System;
using System.Collections.Generic;   
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    //Mergesort algorithm implementation.
    //It splits an array into two parts and merges them afterwards
    class Mergesort : SortingAlgorithm
    {
        public static int frame;
        public static int accesses;
        public static int comparisons;

        //Mergesort algorithm implementation
        //Sorts with the idea, that two sorted arrays can be easily merged together
        public void Sort(int[] array, int start, int end, bool threaded)
        {
            //create a copy of an array to measure time at first sorting
            int[] mergearray;

            if (threaded)
            {
                mergearray = array;
            }
            else
            {
                mergearray = new int[array.Length];
                Array.Copy(array, mergearray, array.Length);
            }

            //a list for storing measured time
            List<long> time = new List<long>();

            //start measuring time from the beginning of sorting
            var watch = new Stopwatch();
            watch.Start();

            time.Add(watch.ElapsedTicks);

            //run mergesort recursively 
            MergeSort(mergearray, start, end, false, watch, time);

            watch.Stop();

            if (threaded)
            {
                return;
            }

            //run a second sorting, this time the duration is already measured, so we can create frames during the run

            frame = 0;
            comparisons = 0;
            accesses = 0;

            SVGgenerate.GenerateSVG("mergesort",0, frame, comparisons, accesses, array, time[frame]);

            //run mergesort recursively 
             MergeSort(array, start, end, true, watch, time);

            InfoFile.CreateInfoFile("mergesort", array.Length, time.Last(), comparisons, accesses, 0);

        }

        //recursively splits an array into two parts and merges two sorted parts
        public static void MergeSort(int[] array, int start, int end, bool draw, Stopwatch watch, List<long> time)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(array, start, mid, draw, watch, time);
                MergeSort(array, mid + 1, end, draw, watch, time);
                Merge(array, start, mid, end);

                if (draw)
                {
                    frame++;
                    SVGgenerate.GenerateSVG("mergesort", 0, frame, comparisons, accesses, array, time[frame]);
                }
                else
                {
                    time.Add(watch.ElapsedTicks);
                }
            }
        }

        //auxiliary function for mergesort
        //merges two part of a sorted array together
        public static void Merge(int[] arr, int start, int mid, int end)
        {
            //create iterators
            int i = 0;
            int j = 0;

            //create indexes for borders
            int b1 = mid - start + 1;
            int b2 = end - mid;


            int[] temp_left = new int[b1];
            int[] temp_right = new int[b2];

            //copy parts of an array to two temporary arrays
            while (i < b1)
            {
                temp_left[i] = arr[start + i];
                accesses++;
                i++;
            }

            while (j < b2)
            {
                temp_right[j] = arr[mid + 1 + j];
                accesses++;
                j++;
            }

            i = 0;
            j = 0;
            int k = start;
            //until we reach the mid with one counter and end with second
            while (i < b1 && j < b2)
            {
                accesses = accesses + 2;
                comparisons++;
                //if left element is smaller than right, put this element in array and increment left counter
                if (temp_left[i] <= temp_right[j])
                {
                    arr[k] = temp_left[i];
                    i++;
                }
                //if not, put there the right element and increment the right counter
                else
                {
                    arr[k] = temp_right[j];
                    j++;
                }
                k++;
            }

            //copy the rest of an array
            while (i < b1)
            {
                arr[k] = temp_left[i];
                accesses++;
                i++;
                k++;
            }
            while (j < b2)
            {
                arr[k] = temp_right[j];
                accesses++;
                j++;
                k++;
            }
        }       
    }
}
