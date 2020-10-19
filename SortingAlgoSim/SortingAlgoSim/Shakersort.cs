using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class Shakersort : SortingAlgorithm
    {
        //Shakersort algorithm implementation 
        //Also sometimes named cocktailsort, it is advanced bubblesort, that returns when it reaches an end of the array.
        public void Sort(int[] array, int start, int end, bool threaded)
        {
            //in case of two steps sorting for singlethreaded run, we copy the contents of an array to an auxiliary one
            int[] shakerarray;

            if (threaded)
            {
                shakerarray = array;
            }
            else
            {
                shakerarray = new int[array.Length];
                Array.Copy(array, shakerarray, array.Length);
            }

            //a list for storing measured time
            List<long> time = new List<long>();

            //start measuring time from the beginning of sorting
            var watch = new Stopwatch();
            watch.Start();

            time.Add(watch.ElapsedTicks);

            //go through the current array
            for (int i = start; i < end; i++)
            {
                //indicator showing if the elements were swapped
                bool swap = false;

                //go from current element to the end of an array
                for (int j = i; j < end; j++)
                {
                    //if the left element is bigger than the right, swap them
                    if (shakerarray[j + 1] < shakerarray[j])
                    {
                        int temp = shakerarray[j + 1];
                        shakerarray[j + 1] = shakerarray[j];
                        shakerarray[j] = temp;
                        time.Add(watch.ElapsedTicks);
                        //mark that some elements were swapped
                        swap = true;
                    }
                }

                //return back, so go from the end of an array to current element, 
                for (int j = end; j > start; j--)
                {
                    //if the right element is smaller than the left, swap them
                    if (shakerarray[j] < shakerarray[j - 1])
                    {
                        int temp = shakerarray[j - 1];
                        shakerarray[j - 1] = shakerarray[j];
                        shakerarray[j] = temp;
                        time.Add(watch.ElapsedTicks);
                        //mark that some elements were swapped
                        swap = true;
                    }
                }

                //if no elements were swapped, that means the array is sorted
                if (swap == false)
                    break;
            }

            watch.Stop();

            //in case of multithreaded sorting, we sorted required part of an array and can exit
            if (threaded)
            {
                return;
            }

            //run a second sorting, this time the duration is already measured, so we can create frames during the run

            int frame = 0;
            int comparison = 0;
            int access = 0;

            SVGgenerate.GenerateSVG("shakersort", 0, frame, comparison, access, array, time[frame]);

            //go through the current array
            for (int i = 0; i < array.Length / 2; i++)
            {
                //indicator showing if the elements were swapped
                bool swap = false;

                //go from current element to the end of an array
                for (int j = i; j < array.Length - i - 1; j++)
                {
                    comparison++;

                    access = access + 2;

                    //if the left element is bigger than the right, swap them
                    if (array[j + 1] < array[j])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;

                        frame++;
                        SVGgenerate.GenerateSVG("shakersort",0, frame, comparison, access, array, time[frame]);
                        //mark that some lements were swapped
                        swap = true;
                    }
                }

                //return back, so go from the end of an array to current element
                for (int j = array.Length - 2 - i; j > i; j--)
                {
                    comparison++;

                    access = access + 2;

                    //if the right element is smaller than the left, swap them
                    if (array[j] < array[j - 1])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;

                        frame++;
                        SVGgenerate.GenerateSVG("shakersort", 0, frame, comparison, access, array, time[frame]);
                        //mark that some lements were swapped
                        swap = true;
                    }
                }

                //if no elements were swapped, that means the array is sorted
                if (swap == false)
                    break;
            }

            //before we exit, we create an info file summarizing the result of an algorithm
            InfoFile.CreateInfoFile("shakersort", array.Length, time.Last(), comparison, access, 0);

        }

    }
}
