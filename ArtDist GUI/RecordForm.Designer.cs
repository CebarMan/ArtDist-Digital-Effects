namespace ArtDist_GUI
{
    partial class RecordForm
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
            this.RecButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RecButton
            // 
            this.RecButton.Location = new System.Drawing.Point(12, 12);
            this.RecButton.Name = "RecButton";
            this.RecButton.Size = new System.Drawing.Size(75, 23);
            this.RecButton.TabIndex = 0;
            this.RecButton.Text = "Record";
            this.RecButton.UseVisualStyleBackColor = true;
            this.RecButton.Click += new System.EventHandler(this.RecButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(103, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 87);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.RecButton);
            this.Name = "RecordForm";
            this.Text = "RecordForm";
            this.Load += new System.EventHandler(this.RecordForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RecButton;
        private System.Windows.Forms.Button StopButton;
    }
}