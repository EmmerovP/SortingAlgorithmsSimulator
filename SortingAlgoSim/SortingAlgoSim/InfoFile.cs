using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    class InfoFile
    {
        //method for creating an infofile summarizing the result of sorting
        public static void CreateInfoFile(string algorithm, int length, long time, int comparisons, int accesses, int threads)
        {
            //creation of a filepath to a new text file, to which we will be writing the summarization
            string File = Path.Combine(SelectParamWin.filePath, algorithm + ".txt");

            //create an array with three lines, containing information about size of an array, sorting algorithm, measured time, and others
            string[] lines = new string[3];

            lines[0] = "An array with " + length + " items has been sorted.";
            lines[1] = "It took " + time + " ticks to finish sorting with " + algorithm + ".";

            if (threads == 0)
            {
                lines[2] = "There were needed " + comparisons + " comparisons and " + accesses + " accesses to the elements of an array.";
            }
            else
            {
                lines[2] = "There were " + threads + " threads sorting the array.";
            }

            //write everything into the file
            System.IO.File.WriteAllLines(File, lines);
        }

    }
}
