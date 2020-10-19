using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class Bucketsort : SortingAlgorithm
    {
        //Bucketsort algorithm implementation
        //It doesn't use any comparing, this algorithm sorts an array by putting numbers in buckets according to the decimal value
        public void Sort(int[] array, int start, int end, bool threaded)
        {
            int buckets = array.Length;

            //in case of two steps sorting for singlethreaded run, we copy the contents of an array to an auxiliary one
            int[] bucketarray;

            if (threaded)
            {
                bucketarray = array;
            }
            else
            {
                bucketarray = new int[array.Length];
                Array.Copy(array, bucketarray, array.Length);
            }

            //a list for storing measured time
            List<long> time = new List<long>();

            int frame = 0;
            int comparisons = 0;
            int accesses = 0;

            //start measuring time from the beginning of sorting
            var watch = new Stopwatch();
            watch.Start();

            time.Add(watch.ElapsedTicks);

            //ten buckets for numbers 0..9
            Queue<int>[] sub = new Queue<int>[10];

            //initialize queues
            for (int i = 0; i < 10; i++)
            {
                sub[i] = new Queue<int>();
            }

            int k, l, m;

            //for each decimal of maximum number in the array
            for (int j = 10; j <= (buckets * 10); j = (j * 10))
            {
                k = start;
                //put every number in according bucket
                while (k <= end)
                {
                    l = (bucketarray[k]) % j;
                    m = l % (j / 10);
                    l = (l - m) / (j / 10);
                    sub[l].Enqueue(bucketarray[k]);
                    k++;
                }

                //starting index of an array
                k = start;
                //go through all ten buckets
                for (int i = 0; i < 10; i++)
                {
                    //until the current buckets isn't empty, pop an element and put it into an array
                    while (sub[i].Count != 0)
                    {
                        bucketarray[k] = sub[i].Dequeue();
                        //increment the counter
                        k++;
                        time.Add(watch.ElapsedTicks);
                    }
                }
            }

            //in case of multithreaded sorting, we sorted required part of an array and can exit
            if (threaded)
            {
                return;
            }

            watch.Stop();

            //run a second sorting, this time the duration is already measured, so we can create frames during the run

            SVGgenerate.GenerateSVG("bucketsort",0, frame, comparisons, accesses, array, time[frame]);

            //ten buckets for numbers 0..9
            Queue<int>[] secsub = new Queue<int>[10];

            //initialize queues
            for (int i = 0; i < 10; i++)
            {
                accesses++;
                secsub[i] = new Queue<int>();
            }


            //for each decimal of maximum number in the array
            for (int j = 10; j <= (buckets * 10); j = (j * 10))
            {
                k = 0;
                //put every number in according bucket
                while (k < array.Length)
                {
                    accesses++;
                    l = (array[k]) % j;
                    m = l % (j / 10);
                    l = (l - m) / (j / 10);
                    accesses++;
                    secsub[l].Enqueue(array[k]);
                    k++;
                }

                //starting index of an array
                k = 0;
                //go through all ten buckets
                for (int i = 0; i < 10; i++)
                {
                    //until the current buckets isn't empty, pop an element and put it into an array
                    while (secsub[i].Count != 0)
                    {
                        accesses++;
                        array[k] = secsub[i].Dequeue();
                        //increment the counter
                        k++;
                        frame++;
                        SVGgenerate.GenerateSVG("bucketsort", 0, frame, comparisons, accesses, array, time[frame]);
                    }
                }
            }

            //before we exit, we create an info file summarizing the result of an algorithm
            InfoFile.CreateInfoFile("bucketsort", array.Length, time.Last(), comparisons, accesses, 0);
        }

    }
}
