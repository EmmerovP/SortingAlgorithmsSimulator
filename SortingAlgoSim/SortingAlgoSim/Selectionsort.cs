using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class Selectionsort : SortingAlgorithm
    {
        //Selectionsort algorithm implementation
        //It sorts an array by repeatedly finding a maximal element and putting it at the end of the array.
        public void Sort(int[] array, int start, int end, bool threaded)
        {
            //in case of two steps sorting for singlethreaded run, we copy the contents of an array to an auxiliary one
            int[] selectionarray;

            if (threaded)
            {
                selectionarray = array;
            }
            else
            {
                selectionarray = new int[array.Length];
                Array.Copy(array, selectionarray, array.Length);
            }

            //a list for storing measured time
            List<long> time = new List<long>();

            //start measuring time from the beginning of sorting
            var watch = new Stopwatch();
            watch.Start();

            time.Add(watch.ElapsedTicks);

            //go through the current array
            for (int i = start; i <= end; i++)
            {
                //mark a maximal value
                int max = i;

                //go through an array from a current element to the end of an array
                for (int j = i + 1; j <= end; j++)
                {
                    //if a current element is bigger than marked maximum
                    if (selectionarray[j] < selectionarray[max])
                    {
                        max = j;
                    }
                }
                //swap the last element with a maximum element
                int temp = selectionarray[i];
                selectionarray[i] = selectionarray[max];
                selectionarray[max] = temp;
                time.Add(watch.ElapsedTicks);
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

            SVGgenerate.GenerateSVG("selectionsort", 0, frame, comparison, access, array, time[frame]);

            //go through the current array
            for (int i = 0; i < array.Length - 1; i++)
            {
                //mark a maximal value
                int max = i;

                //go through an array from a current element to the end of an array
                for (int j = i + 1; j < array.Length; j++)
                {
                    comparison++;

                    access = access + 2;

                    //if a current element is bigger than marked maximum
                    if (array[j] < array[max])
                    {
                        max = j;
                    }
                }

                access = access + 2;

                //swap the last element with a maximum element
                int temp = array[i];
                array[i] = array[max];
                array[max] = temp;

                frame++;
                SVGgenerate.GenerateSVG("selectionsort", 0, frame, comparison, access, array, time[frame]);
            }

            //before we exit, we create an info file summarizing the result of an algorithm
            InfoFile.CreateInfoFile("selectionsort", array.Length, time.Last(), comparison, access, 0);

        }

    }
}
