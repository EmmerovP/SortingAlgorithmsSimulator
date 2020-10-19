using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SortingAlgoSim
{
    //interface creating templates for all sorting algorithms
    public interface SortingAlgorithm
    {
        void Sort(int[] array, int start, int end, bool threaded);
    }


    public partial class SelectParamWin : Form
    {
        //path to the folder, in which are generated images stored
        public static string filePath = null;

        //size of array, which will be sorted
        public static int size;

        //counts how many runs of sorting were run from the beginning of the program
        public static int iterator = 0;

        //number of threads we will be using for sorting
        public static int threads = 0;

        //whether we use multithreading or not
        public static bool multithread = false;

        public SelectParamWin()
        {
            InitializeComponent();
        }

        //generates an array of given size, filled with integers from 0 to size-1, in random order
        public static int[] GenerateArray(int size)
        {
            var random = new Random();
            return Enumerable.Range(0, size).OrderBy(t => random.Next()).ToArray();
        }

        //shows folder browser, to choose a folder to store generated pictures
        private void ChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //after choosing a folder and selecting OK, the window closes
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //to the static variable filePath is assigned a selected path
                filePath = fbd.SelectedPath;
                chooseFolder.Text = filePath;
            }
        }


        //shows a window announcing an error in input parameters
        public void ErrorWindow(string name, string message)
        {
            ErrorWin popup = new ErrorWin();

            //window title
            popup.Text = name;

            //message shown in a window
            popup.Errortext.Text = message;

            DialogResult dialogresult = popup.ShowDialog();

            //after selecting OK, the window closes
            if (dialogresult == DialogResult.OK)
            {
                popup.Dispose();
            }
        }


        //checking if user's parameters are correct and complete
        public bool CheckErrors()
        {
            //checking if entered size a correct integer
            try
            {
                size = Int32.Parse(arraySize.Text);
            }
            catch (Exception)
            {
                //shows window announcing an error
                ErrorWindow("Size not valid", "Size of an array is not a valid integer.");
                return true;
            }

            //checking if size is a natural number
            if (size <= 0)
            {
                ErrorWindow("Size not valid", "Size can only be a number higher than 0.");
                return true;
            }

            //we limit the maximum size of an array
            if (size > 9999)
            {
                ErrorWindow("Size not valid", "Size exceeded the allowed limit, which is 9999.");
                return true;
            }

            //checking if a folder was selected
            if (filePath == null)
            {
                ErrorWindow("Folder not selected", "Please select folder.");
                return true;
            }

            //returns false if no errors were found, else returns true
            return false;
        }


        //for each checked field, runs a sorting algorithm 
        public void Algorithms()
        {
            //first makes an array of given size with values from 0 to size-1, in random order
            int[] array = GenerateArray(size);

            List<SortingAlgorithm> toSort = new List<SortingAlgorithm>();

            //if bubblesort is selected
            if (bubble.Checked)
            {
                Bubblesort bubblesort = new Bubblesort();
                Sort(array, bubblesort);
            }

            //if selectionsort is selected
            if (selection.Checked)
            {
                Selectionsort selection = new Selectionsort();
                Sort(array, selection);
            }

            //if insertionsort is selected
            if (insertion.Checked)
            {
                Insertsort insertion = new Insertsort();
                Sort(array, insertion);
            }

            //if insertionsort is selected
            if (bucket.Checked)
            {
                Bucketsort bucket = new Bucketsort();
                Sort(array, bucket);
            }

            //if quicksort is selected
            if (quick.Checked)
            {
                Quicksort quick = new Quicksort();
                Sort(array, quick);
            }

            //if mergesort is selected
            if (merge.Checked)
            {
                Mergesort merge = new Mergesort();
                Sort(array, merge);
            }

            //if mergesort is selected
            if (shaker.Checked)
            {
                Shakersort shake = new Shakersort();
                Sort(array, shake);
            }

        }

        //calls chosem sorting algorithm
        public void Sort(int[] array, SortingAlgorithm algorithm)
        {
            //makes a copy of an array
            int[] temp = new int[size];
            Array.Copy(array, temp, array.Length);

            //runs a sorting algorithm
            //option for multithreaded sorting
            if (multithread)
            {
                Multithread.RunThreads(threads, temp, algorithm);
            }
            //option for singlethreaded sorting
            else
            {
                algorithm.Sort(temp, 0, temp.Length - 1, false);
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            //clears a label announcing status of course of the program
            labelDone.Text = "";

            //if input parameters are incomplete or wrong, the program doesn't continue
            if (CheckErrors())
                return;

            //number of arrays, that are sorted
            int iter = (int)iteratsValue.Value;

            if (multithread)
            {              
                //get number of threads we use for sorting
                threads = (int)threadCount.Value;
            }

            //update the status of program on label 
            labelDone.Text = "SVG files are generating.";
                
            for (int i = 0; i < iter; i++)
            {
                //set a filePath as path to a new folder
                filePath = Path.Combine(filePath, "AlgorithmVisualization" + iterator);

                //create that new folder
                Directory.CreateDirectory(filePath);

                //run selected sorting algorithms
                Algorithms();

                //set filePath back to it's original form
                filePath = Path.GetDirectoryName(filePath);

                //increment a number counting runs of sorting an array
                iterator++;
            }

            //update the status of program on label 
            labelDone.Text = "SVG files were generated.";
        }

        //checks whether the user chose to sort on multiple threads, updates the variable multithread accordingly
        private void isThreaded_CheckedChanged(object sender, EventArgs e)
        {
            if (isThreaded.Checked)
            {
                label_threads.Visible = true;
                threadCount.Visible = true;
                multithread = true;
            }
            else
            {
                label_threads.Visible = false;
                threadCount.Visible = false;
                multithread = false;
            }
        }


    }
}
