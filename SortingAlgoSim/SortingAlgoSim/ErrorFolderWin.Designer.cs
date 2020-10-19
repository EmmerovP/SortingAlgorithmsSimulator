namespace SortingAlgoSim
{
    partial class ErrorWin
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
            this.Errortext = new System.Windows.Forms.Label();
            this.accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Errortext
            // 
            this.Errortext.AutoSize = true;
            this.Errortext.Location = new System.Drawing.Point(12, 21);
            this.Errortext.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Errortext.Name = "Errortext";
            this.Errortext.Size = new System.Drawing.Size(0, 13);
            this.Errortext.TabIndex = 0;
            // 
            // accept
            // 
            this.accept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.accept.Location = new System.Drawing.Point(87, 96);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(75, 23);
            this.accept.TabIndex = 1;
            this.accept.Text = "OK";
            this.accept.UseVisualStyleBackColor = true;
            // 
            // ErrorWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 160);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.Errortext);
            this.Name = "ErrorWin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button accept;
        public System.Windows.Forms.Label Errortext;
    }
}