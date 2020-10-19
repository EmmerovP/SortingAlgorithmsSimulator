using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class Quicksort : SortingAlgorithm
    {
        public static int frame;
        public static int access;
        public static int comparison;

        //Quicksort algorithm implemetation
        //Divide and counter algorithm, it picks a pivot and partitions an array around the pivot.
        //This implementation is iterative, not recursive.
        public void Sort(int[] array, int start, int end, bool threaded)
        {
            int left, right;

            //stack for storing values indicating an array partition
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            stack.Push(end);

            //in case of two steps sorting for singlethreaded run, we copy the contents of an array to an auxiliary one
            int[] quickarray;

            if (threaded)
            {
                quickarray = array;
            }
            else
            {
                quickarray = new int[array.Length];
                Array.Copy(array, quickarray, array.Length);
            }

            //a list for storing measured time
            List<long> time = new List<long>();

            //start measuring time from the beginning of sorting
            var watch = new Stopwatch();
            watch.Start();

            //iterate until the stack is empty, which means that the array is sorted
            while (stack.Count != 0)
            {
                time.Add(watch.ElapsedTicks);
                //pop two values of stack, bounding the current part of an array
                right = stack.Pop();
                left = stack.Pop();

                //selects a pivot
                int pivot = FindPivot(quickarray, left, right, time, watch, false);

                //push a correct new boundaries of new partitions into the stack
                if (pivot - 1 > left)
                {
                    stack.Push(left);
                    stack.Push(pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    stack.Push(pivot + 1);
                    stack.Push(right);
                }
            }

            watch.Stop();

            //in case of multithreaded sorting, we sorted required part of an array and can exit
            if (threaded)
            {
                return;
            }

            //run a second sorting, this time the duration is already measured, so we can create frames during the run
            frame = 0;
            access = 0;
            comparison = 0;

            stack.Clear();
            stack.Push(0);
            stack.Push(array.Length - 1);

            SVGgenerate.GenerateSVG("quicksort", 0, frame, comparison, access, array, 0);

            while (stack.Count != 0)
            {

                //pop two values of stack, bounding the current part of an array
                right = stack.Pop();
                left = stack.Pop();

                //selects a pivot
                int pivot = FindPivot(array, left, right, time, watch, true);

                //push a correct new boundaries of new partitions into the stack
                comparison++;
                if (pivot - 1 > left)
                {
                    stack.Push(left);
                    stack.Push(pivot - 1);
                }

                comparison++;
                if (pivot + 1 < right)
                {
                    stack.Push(pivot + 1);
                    stack.Push(right);
                }
            }

            //before we exit, we create an info file summarizing the result of an algorithm
            InfoFile.CreateInfoFile("quicksort", array.Length, time.Last(), comparison, access, 0);

        }

        //auxiliary method for quicksort, finds a pivot
        public int FindPivot(int[] array, int left, int right, List<long> time, Stopwatch watch, bool draw)
        {
            access++;
            //begin at the first element of parted array
            int pivot = array[left];

            //until a pivot is found and a value is returned, repeat
            while (true)
            {
                comparison = comparison + 3;
                access = access + 2;
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                //if left is smaller than right, swap them
                if (left < right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;

                    //decide whether to save time into a list of times in case of first run or draw an image in case of second run 
                    if (draw)
                    {
                        frame++;
                        SVGgenerate.GenerateSVG("quicksort", 0, frame, comparison, access, array, time[frame]);                       
                    }
                    else
                    {
                        time.Add(watch.ElapsedTicks);
                    }
                }

                //if swapping isn't needed, pivot is found, return a value
                else
                    return right;
            }
        }

    }
}
