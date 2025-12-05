namespace AmpEx_GUI_1
{
    partial class LoadPresetForm
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.PresetsListBox = new System.Windows.Forms.ListBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(126, 415);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // PresetsListBox
            // 
            this.PresetsListBox.FormattingEnabled = true;
            this.PresetsListBox.Location = new System.Drawing.Point(0, 0);
            this.PresetsListBox.Name = "PresetsListBox";
            this.PresetsListBox.Size = new System.Drawing.Size(120, 446);
            this.PresetsListBox.TabIndex = 2;
            this.PresetsListBox.SelectedIndexChanged += new System.EventHandler(this.PresetsListBox_SelectedIndexChanged);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(126, 29);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(84, 13);
            this.InfoLabel.TabIndex = 3;
            this.InfoLabel.Text = "AAAAAAAAAAA";
            // 
            // LoadPresetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 446);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.PresetsListBox);
            this.Controls.Add(this.LoadButton);
            this.Name = "LoadPresetForm";
            this.Text = "LoadPresetForm";
            this.Load += new System.EventHandler(this.LoadPresetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ListBox PresetsListBox;
        private System.Windows.Forms.Label InfoLabel;
    }
}