namespace SortingAlgoSim
{
    partial class SelectParamWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.algorithm = new System.Windows.Forms.Label();
            this.bubble = new System.Windows.Forms.CheckBox();
            this.selection = new System.Windows.Forms.CheckBox();
            this.insertion = new System.Windows.Forms.CheckBox();
            this.bucket = new System.Windows.Forms.CheckBox();
            this.quick = new System.Windows.Forms.CheckBox();
            this.label_size = new System.Windows.Forms.Label();
            this.arraySize = new System.Windows.Forms.TextBox();
            this.folder = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chooseFolder = new System.Windows.Forms.Button();
            this.generate = new System.Windows.Forms.Button();
            this.labelDone = new System.Windows.Forms.Label();
            this.iteratLabel = new System.Windows.Forms.Label();
            this.iteratsValue = new System.Windows.Forms.NumericUpDown();
            this.merge = new System.Windows.Forms.CheckBox();
            this.shaker = new System.Windows.Forms.CheckBox();
            this.label_threads = new System.Windows.Forms.Label();
            this.threadCount = new System.Windows.Forms.NumericUpDown();
            this.isThreaded = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.iteratsValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCount)).BeginInit();
            this.SuspendLayout();
            // 
            // algorithm
            // 
            this.algorithm.AutoSize = true;
            this.algorithm.Location = new System.Drawing.Point(13, 13);
            this.algorithm.Name = "algorithm";
            this.algorithm.Size = new System.Drawing.Size(53, 13);
            this.algorithm.TabIndex = 0;
            this.algorithm.Text = "Algorithm:";
            // 
            // bubble
            // 
            this.bubble.AutoSize = true;
            this.bubble.Location = new System.Drawing.Point(16, 43);
            this.bubble.Name = "bubble";
            this.bubble.Size = new System.Drawing.Size(76, 17);
            this.bubble.TabIndex = 1;
            this.bubble.Text = "Bubblesort";
            this.bubble.UseVisualStyleBackColor = true;
            // 
            // selection
            // 
            this.selection.AutoSize = true;
            this.selection.Location = new System.Drawing.Point(16, 66);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(87, 17);
            this.selection.TabIndex = 2;
            this.selection.Text = "Selectionsort";
            this.selection.UseVisualStyleBackColor = true;
            // 
            // insertion
            // 
            this.insertion.AutoSize = true;
            this.insertion.Location = new System.Drawing.Point(16, 89);
            this.insertion.Name = "insertion";
            this.insertion.Size = new System.Drawing.Size(83, 17);
            this.insertion.TabIndex = 3;
            this.insertion.Text = "Insertionsort";
            this.insertion.UseVisualStyleBackColor = true;
            // 
            // bucket
            // 
            this.bucket.AutoSize = true;
            this.bucket.Location = new System.Drawing.Point(16, 112);
            this.bucket.Name = "bucket";
            this.bucket.Size = new System.Drawing.Size(77, 17);
            this.bucket.TabIndex = 4;
            this.bucket.Text = "Bucketsort";
            this.bucket.UseVisualStyleBackColor = true;
            // 
            // quick
            // 
            this.quick.AutoSize = true;
            this.quick.Location = new System.Drawing.Point(16, 135);
            this.quick.Name = "quick";
            this.quick.Size = new System.Drawing.Size(71, 17);
            this.quick.TabIndex = 5;
            this.quick.Text = "Quicksort";
            this.quick.UseVisualStyleBackColor = true;
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Location = new System.Drawing.Point(13, 214);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(71, 13);
            this.label_size.TabIndex = 6;
            this.label_size.Text = "Size of array: ";
            // 
            // arraySize
            // 
            this.arraySize.Location = new System.Drawing.Point(90, 211);
            this.arraySize.Name = "arraySize";
            this.arraySize.Size = new System.Drawing.Size(100, 20);
            this.arraySize.TabIndex = 7;
            // 
            // folder
            // 
            this.folder.AutoSize = true;
            this.folder.Location = new System.Drawing.Point(19, 306);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(42, 13);
            this.folder.TabIndex = 10;
            this.folder.Text = "Folder: ";
            // 
            // chooseFolder
            // 
            this.chooseFolder.Location = new System.Drawing.Point(67, 301);
            this.chooseFolder.Name = "chooseFolder";
            this.chooseFolder.Size = new System.Drawing.Size(192, 23);
            this.chooseFolder.TabIndex = 11;
            this.chooseFolder.Text = "Select folder";
            this.chooseFolder.UseVisualStyleBackColor = true;
            this.chooseFolder.Click += new System.EventHandler(this.ChooseFolder_Click);
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(110, 341);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 12;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // labelDone
            // 
            this.labelDone.AutoSize = true;
            this.labelDone.Location = new System.Drawing.Point(23, 376);
            this.labelDone.Name = "labelDone";
            this.labelDone.Size = new System.Drawing.Size(0, 13);
            this.labelDone.TabIndex = 14;
            // 
            // iteratLabel
            // 
            this.iteratLabel.AutoSize = true;
            this.iteratLabel.Location = new System.Drawing.Point(14, 275);
            this.iteratLabel.Name = "iteratLabel";
            this.iteratLabel.Size = new System.Drawing.Size(103, 13);
            this.iteratLabel.TabIndex = 15;
            this.iteratLabel.Text = "Algorithms iterations:";
            // 
            // iteratsValue
            // 
            this.iteratsValue.Location = new System.Drawing.Point(123, 273);
            this.iteratsValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iteratsValue.Name = "iteratsValue";
            this.iteratsValue.Size = new System.Drawing.Size(42, 20);
            this.iteratsValue.TabIndex = 16;
            this.iteratsValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.iteratsValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // merge
            // 
            this.merge.AutoSize = true;
            this.merge.Location = new System.Drawing.Point(16, 160);
            this.merge.Name = "merge";
            this.merge.Size = new System.Drawing.Size(73, 17);
            this.merge.TabIndex = 17;
            this.merge.Text = "Mergesort";
            this.merge.UseVisualStyleBackColor = true;
            // 
            // shaker
            // 
            this.shaker.AutoSize = true;
            this.shaker.Location = new System.Drawing.Point(16, 183);
            this.shaker.Name = "shaker";
            this.shaker.Size = new System.Drawing.Size(77, 17);
            this.shaker.TabIndex = 18;
            this.shaker.Text = "Shakersort";
            this.shaker.UseVisualStyleBackColor = true;
            // 
            // label_threads
            // 
            this.label_threads.AutoSize = true;
            this.label_threads.Location = new System.Drawing.Point(107, 242);
            this.label_threads.Name = "label_threads";
            this.label_threads.Size = new System.Drawing.Size(97, 13);
            this.label_threads.TabIndex = 19;
            this.label_threads.Text = "Number of threads:";
            this.label_threads.Visible = false;
            // 
            // threadCount
            // 
            this.threadCount.Location = new System.Drawing.Point(216, 240);
            this.threadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCount.Name = "threadCount";
            this.threadCount.Size = new System.Drawing.Size(42, 20);
            this.threadCount.TabIndex = 20;
            this.threadCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.threadCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCount.Visible = false;
            // 
            // isThreaded
            // 
            this.isThreaded.AutoSize = true;
            this.isThreaded.Location = new System.Drawing.Point(16, 241);
            this.isThreaded.Name = "isThreaded";
            this.isThreaded.Size = new System.Drawing.Size(78, 17);
            this.isThreaded.TabIndex = 21;
            this.isThreaded.Text = "Multithread";
            this.isThreaded.UseVisualStyleBackColor = true;
            this.isThreaded.CheckedChanged += new System.EventHandler(this.isThreaded_CheckedChanged);
            // 
            // SelectParamWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 411);
            this.Controls.Add(this.isThreaded);
            this.Controls.Add(this.threadCount);
            this.Controls.Add(this.label_threads);
            this.Controls.Add(this.shaker);
            this.Controls.Add(this.merge);
            this.Controls.Add(this.iteratsValue);
            this.Controls.Add(this.iteratLabel);
            this.Controls.Add(this.labelDone);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.chooseFolder);
            this.Controls.Add(this.folder);
            this.Controls.Add(this.arraySize);
            this.Controls.Add(this.label_size);
            this.Controls.Add(this.quick);
            this.Controls.Add(this.bucket);
            this.Controls.Add(this.insertion);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.bubble);
            this.Controls.Add(this.algorithm);
            this.Name = "SelectParamWin";
            this.Text = "Sorting algorithm simulator";
            ((System.ComponentModel.ISupportInitialize)(this.iteratsValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label algorithm;
        private System.Windows.Forms.CheckBox bubble;
        private System.Windows.Forms.CheckBox selection;
        private System.Windows.Forms.CheckBox insertion;
        private System.Windows.Forms.CheckBox bucket;
        private System.Windows.Forms.CheckBox quick;
        private System.Windows.Forms.Label label_size;
        private System.Windows.Forms.TextBox arraySize;
        private System.Windows.Forms.Label folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button chooseFolder;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label labelDone;
        private System.Windows.Forms.Label iteratLabel;
        private System.Windows.Forms.NumericUpDown iteratsValue;
        private System.Windows.Forms.CheckBox merge;
        private System.Windows.Forms.CheckBox shaker;
        private System.Windows.Forms.Label label_threads;
        private System.Windows.Forms.NumericUpDown threadCount;
        private System.Windows.Forms.CheckBox isThreaded;
    }
}

