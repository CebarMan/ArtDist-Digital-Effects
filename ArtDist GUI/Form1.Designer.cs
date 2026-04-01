namespace ArtDist_GUI
{
    partial class Form1
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
            this.KnobGain = new System.Windows.Forms.PictureBox();
            this.KnobDist = new System.Windows.Forms.PictureBox();
            this.textGain = new System.Windows.Forms.TextBox();
            this.textDist = new System.Windows.Forms.TextBox();
            this.textVol = new System.Windows.Forms.TextBox();
            this.Savebutton = new System.Windows.Forms.Button();
            this.SaveEnter = new System.Windows.Forms.Button();
            this.SaveFileName = new System.Windows.Forms.TextBox();
            this.LoadPresetFormButton = new System.Windows.Forms.Button();
            this.AudioFilesBox = new System.Windows.Forms.ListBox();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.KnobVol = new System.Windows.Forms.PictureBox();
            this.PlayAudio = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KnobGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnobDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnobVol)).BeginInit();
            this.SuspendLayout();
            // 
            // KnobGain
            // 
            this.KnobGain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KnobGain.Image = global::ArtDist_GUI.Properties.Resources.knob1;
            this.KnobGain.Location = new System.Drawing.Point(324, 183);
            this.KnobGain.Name = "KnobGain";
            this.KnobGain.Size = new System.Drawing.Size(100, 95);
            this.KnobGain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.KnobGain.TabIndex = 2;
            this.KnobGain.TabStop = false;
            this.KnobGain.Paint += new System.Windows.Forms.PaintEventHandler(this.Generic_Knob_Paint);
            this.KnobGain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturebox_mouseDown);
            this.KnobGain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picturebox_mouseMoving);
            this.KnobGain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // KnobDist
            // 
            this.KnobDist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KnobDist.Image = global::ArtDist_GUI.Properties.Resources.knob1;
            this.KnobDist.Location = new System.Drawing.Point(559, 172);
            this.KnobDist.Name = "KnobDist";
            this.KnobDist.Size = new System.Drawing.Size(100, 106);
            this.KnobDist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.KnobDist.TabIndex = 3;
            this.KnobDist.TabStop = false;
            this.KnobDist.Paint += new System.Windows.Forms.PaintEventHandler(this.Generic_Knob_Paint);
            this.KnobDist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturebox_mouseDown);
            this.KnobDist.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picturebox_mouseMoving);
            this.KnobDist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // textGain
            // 
            this.textGain.Location = new System.Drawing.Point(307, 100);
            this.textGain.Name = "textGain";
            this.textGain.Size = new System.Drawing.Size(100, 20);
            this.textGain.TabIndex = 4;
            this.textGain.TextChanged += new System.EventHandler(this.textGain_TextChanged);
            // 
            // textDist
            // 
            this.textDist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDist.Location = new System.Drawing.Point(514, 88);
            this.textDist.Name = "textDist";
            this.textDist.Size = new System.Drawing.Size(156, 20);
            this.textDist.TabIndex = 5;
            this.textDist.TextChanged += new System.EventHandler(this.textDist_TextChanged);
            // 
            // textVol
            // 
            this.textVol.Location = new System.Drawing.Point(121, 100);
            this.textVol.Name = "textVol";
            this.textVol.Size = new System.Drawing.Size(100, 20);
            this.textVol.TabIndex = 6;
            this.textVol.TextChanged += new System.EventHandler(this.textVol_TextChanged);
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(27, 51);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(75, 20);
            this.Savebutton.TabIndex = 7;
            this.Savebutton.Text = "Save layout";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // SaveEnter
            // 
            this.SaveEnter.AccessibleName = "SaveEnter";
            this.SaveEnter.Location = new System.Drawing.Point(255, 48);
            this.SaveEnter.Name = "SaveEnter";
            this.SaveEnter.Size = new System.Drawing.Size(75, 23);
            this.SaveEnter.TabIndex = 8;
            this.SaveEnter.Text = "Enter";
            this.SaveEnter.UseVisualStyleBackColor = true;
            this.SaveEnter.Visible = false;
            this.SaveEnter.Click += new System.EventHandler(this.SaveEnter_Click);
            // 
            // SaveFileName
            // 
            this.SaveFileName.Location = new System.Drawing.Point(121, 51);
            this.SaveFileName.MaxLength = 100000;
            this.SaveFileName.Name = "SaveFileName";
            this.SaveFileName.Size = new System.Drawing.Size(128, 20);
            this.SaveFileName.TabIndex = 9;
            this.SaveFileName.Text = "File name";
            this.SaveFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SaveFileName.Visible = false;
            this.SaveFileName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LoadPresetFormButton
            // 
            this.LoadPresetFormButton.Location = new System.Drawing.Point(27, 85);
            this.LoadPresetFormButton.Name = "LoadPresetFormButton";
            this.LoadPresetFormButton.Size = new System.Drawing.Size(75, 23);
            this.LoadPresetFormButton.TabIndex = 10;
            this.LoadPresetFormButton.Text = "Load Files";
            this.LoadPresetFormButton.UseVisualStyleBackColor = true;
            this.LoadPresetFormButton.Click += new System.EventHandler(this.LoadPresetFormButton_Click);
            // 
            // AudioFilesBox
            // 
            this.AudioFilesBox.FormattingEnabled = true;
            this.AudioFilesBox.Location = new System.Drawing.Point(5, 151);
            this.AudioFilesBox.Name = "AudioFilesBox";
            this.AudioFilesBox.Size = new System.Drawing.Size(97, 264);
            this.AudioFilesBox.TabIndex = 11;
            this.AudioFilesBox.SelectedIndexChanged += new System.EventHandler(this.AudioFilesBox_SelectedIndexChanged);
            // 
            // LabelInfo
            // 
            this.LabelInfo.AutoSize = true;
            this.LabelInfo.Location = new System.Drawing.Point(2, 135);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(35, 13);
            this.LabelInfo.TabIndex = 12;
            this.LabelInfo.Text = "label1";
            // 
            // KnobVol
            // 
            this.KnobVol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KnobVol.Image = global::ArtDist_GUI.Properties.Resources.knob1;
            this.KnobVol.Location = new System.Drawing.Point(121, 183);
            this.KnobVol.Name = "KnobVol";
            this.KnobVol.Size = new System.Drawing.Size(87, 95);
            this.KnobVol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.KnobVol.TabIndex = 1;
            this.KnobVol.TabStop = false;
            this.KnobVol.Paint += new System.Windows.Forms.PaintEventHandler(this.Generic_Knob_Paint);
            this.KnobVol.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picturebox_mouseDown);
            this.KnobVol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturebox_mouseDown);
            this.KnobVol.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picturebox_mouseMoving);
            this.KnobVol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // PlayAudio
            // 
            this.PlayAudio.Location = new System.Drawing.Point(5, 421);
            this.PlayAudio.Name = "PlayAudio";
            this.PlayAudio.Size = new System.Drawing.Size(75, 23);
            this.PlayAudio.TabIndex = 13;
            this.PlayAudio.Text = "Play Audio";
            this.PlayAudio.UseVisualStyleBackColor = true;
            this.PlayAudio.Click += new System.EventHandler(this.PlayAudio_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(86, 421);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 14;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ArtDist_GUI.Properties.Resources.amp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(775, 463);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.PlayAudio);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.AudioFilesBox);
            this.Controls.Add(this.LoadPresetFormButton);
            this.Controls.Add(this.SaveFileName);
            this.Controls.Add(this.SaveEnter);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.textVol);
            this.Controls.Add(this.textDist);
            this.Controls.Add(this.textGain);
            this.Controls.Add(this.KnobVol);
            this.Controls.Add(this.KnobDist);
            this.Controls.Add(this.KnobGain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KnobGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnobDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnobVol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox KnobGain;
        private System.Windows.Forms.PictureBox KnobDist;
        private System.Windows.Forms.TextBox textGain;
        private System.Windows.Forms.TextBox textDist;
        private System.Windows.Forms.TextBox textVol;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button SaveEnter;
        private System.Windows.Forms.TextBox SaveFileName;
        private System.Windows.Forms.Button LoadPresetFormButton;
        private System.Windows.Forms.ListBox AudioFilesBox;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.PictureBox KnobVol;
        private System.Windows.Forms.Button PlayAudio;
        private System.Windows.Forms.Button RefreshButton;
    }
}

