using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class Bubblesort : SortingAlgorithm
    {
        //Bubblesort algorithm implementation.
        //It is the simplest algorithm, it works by repeatedly swapping adjanced elements, that are in the wrong order. 
        public void Sort(int[] array, int start, int end, bool threaded)
        {
            //in case of two steps sorting for singlethreaded run, we copy the contents of an array to an auxiliary one
            int[] bubblearray;

            if (threaded)
            {
                bubblearray = array;
            }
            else
            {
                bubblearray = new int[array.Length];
                Array.Copy(array, bubblearray, array.Length);
            }

            //a list for storing measured time
            List<long> time = new List<long>();
            //start measuring time from the beginning of sorting
            var watch = new Stopwatch();
            watch.Start();

            time.Add(watch.ElapsedTicks);

            //go through the whole array
            for (int i = start; i <= end; i++)
            {
                //start at beginning and continue to the current element of an array
                for (int j = start; j <= end - 1; j++)
                {
                    //if the left element is bigger than the right, swap them
                    if (bubblearray[j + 1] < bubblearray[j])
                    {
                        //create a temporary integer to store a value in
                        int temp = bubblearray[j + 1];
                        bubblearray[j + 1] = bubblearray[j];
                        bubblearray[j] = temp;
                        time.Add(watch.ElapsedTicks);
                    }
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

            SVGgenerate.GenerateSVG("bubblesort", 0, frame, comparisons, accesses, array, time[frame]);

            for (int i = 0; i < array.Length - 1; i++)
            {
                //start at beginning and continue to the current element of an array
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    comparisons++;

                    accesses = accesses + 2;

                    //if the left element is bigger than the right, swap them
                    if (array[j + 1] < array[j])
                    {
                        //create a temporary integer to store a value in
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        frame++;
                        SVGgenerate.GenerateSVG("bubblesort", 0, frame, comparisons, accesses, array, time[frame]);

                    }
                }
            }

            //before we exit, we create an info file summarizing the result of an algorithm
            InfoFile.CreateInfoFile("bubblesort", array.Length, time.Last(), comparisons, accesses, 0);
        }

    }
}
