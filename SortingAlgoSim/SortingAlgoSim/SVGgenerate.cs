using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoSim
{
    //generating SVG files
    static class SVGgenerate
    {
        /*creates an svg image showing:
         * an array vizualized as a column graph
         * time from beginning of sorting
         * current number of comparison
         * current number of access to the elements of an array
         * */
        public static void GenerateSVG(string algorithm, int threads, int frame, int comparison, int acces, int[] array, long time)
        {
            //calculates the height and width of an image
            int height = (array.Length * 10) + 120;
            int width = (array.Length * 20) + 40;

            //In case the image would be too small to fit the text in, width expands
            if (width < 250)
                width = 250;

            //filename created by combining given path with new name of file (made from name of algorithm, number of frame and .svg suffix)
            string file = Path.Combine(SelectParamWin.filePath, (algorithm + Convert.ToString(frame) + ".svg"));

            //coordinates of elements
            int x, y, h;

            using (StreamWriter sw = new StreamWriter(file))
            {
                //svg is xml based, which means that we can write the code to get an image
                //header announcing svg format, and height of width of an image
                sw.WriteLine("<svg xmlns=\"http://www.w3.org/2000/svg\" height=\"" + height + "\" width=\"" + width + "\">");

                //graph will be white on black background, for better viewing and high contrast
                sw.WriteLine("   <rect x=\"0\" y=\"0\" width=\"" + width + "\" height=\"" + height + "\" style=\"fill: rgb(0, 0, 0); \" />");

                //for each element in an array, draw a rectangle
                for (int i = 0; i < array.Length; i++)
                {
                    //calculating position of a column representing element in an array
                    x = (i * 20) + 20;
                    //height of a column
                    h = (array[i] * 10);
                    y = height - h - 110;

                    //white rectangle with black outlining
                    sw.WriteLine("   <rect x=\"" + x + "\" y=\"" + y + "\" width=\"20\" height=\"" + h + "\" style=\"fill: rgb(255, 255, 255); stroke - width:3; stroke: rgb(0, 0, 0)\" />");
                }

                //On the bottom of each image are written current parameters - name of sorting algorithm, number of threads, number of comparisons, access to elements in an array, and estimated time.
                sw.WriteLine("<text x=\"20\" y=\"" + (height - 90) + "\" fill=\"white\">Current sorting algorithm is " + algorithm + ".</text>");
                if (threads == 0)
                {
                    sw.WriteLine("<text x=\"20\" y=\"" + (height - 70) + "\" fill=\"white\">Elements in the array were compared " + comparison + " times. </text>");
                    sw.WriteLine("<text x=\"20\" y=\"" + (height - 50) + "\" fill=\"white\">Elements in array were accessed " + acces + " times. </text>");
                    sw.WriteLine("<text x=\"20\" y=\"" + (height - 30) + "\" fill=\"white\">Elapsed time is currently " + time + " ticks.</text>");
                }
                else
                {
                    sw.WriteLine("<text x=\"20\" y=\"" + (height - 70) + "\" fill=\"white\"> This sorting runs on " + threads + " threads. </text>");
                    sw.WriteLine("<text x=\"20\" y=\"" + (height - 50) + "\" fill=\"white\"> Elapsed time is currently " + time + " ticks.</text>");
                }


                sw.WriteLine("</svg>");
            }
        }
    }
}
