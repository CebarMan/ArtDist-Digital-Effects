using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using NAudio.Wave;

namespace ArtDist_GUI
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private int dragStartY;
        private float startAngle;
        private readonly float MaxAngle = 130.0f; // Max rotation du tillåter (0 till 300 grader)

        // Rotationstillstånd (Unikt för varje knapp)
        private float currentVolAngle = -130.0f;
        private float currentDistAngle = -130.0f;
        private float currentGainAngle = -130.0f;

        
        PresetManager presetmanager = new PresetManager();
        AudioEngine audioEngine = new AudioEngine();
        

        private readonly string _saveDirectory = AppDomain.CurrentDomain.BaseDirectory;


        public Form1()
        {
            InitializeComponent();
            LoadAudioFiles();
            KnobDist.BackColor = System.Drawing.Color.Transparent;
            KnobGain.BackColor = System.Drawing.Color.Transparent;
            KnobVol.BackColor = System.Drawing.Color.Transparent;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            AudioFilesBox.AllowDrop = true;

            LabelInfo.Text = "Welcome to ArtDist!";
        }

        private void Generic_Knob_Paint(object sender, PaintEventArgs e)
        {
            PictureBox knobControl = sender as PictureBox;

            if (knobControl == null || knobControl.Image == null) return;

            // 1. Hämta RÄTT vinkel för denna kontroll
            float angleToUse;
            if (knobControl == KnobVol) angleToUse = currentVolAngle;
            else if (knobControl == KnobDist) angleToUse = currentDistAngle;
            else if (knobControl == KnobGain) angleToUse = currentGainAngle;
            else return;

            // Rotationslogik
            GraphicsState state = e.Graphics.Save();

            float controlWidth = knobControl.Width;
            float controlHeight = knobControl.Height;

            // Flytta nollpunkten till mitten
            e.Graphics.TranslateTransform(controlWidth / 2.0f, controlHeight / 2.0f);

            // Rotera
            e.Graphics.RotateTransform(angleToUse);

            // Rita bilden centrerad och skalad till PictureBoxens storlek
            float drawX = -controlWidth / 2.0f;
            float drawY = -controlHeight / 2.0f;

            e.Graphics.DrawImage(knobControl.Image, drawX, drawY, controlWidth, controlHeight);

            e.Graphics.Restore(state);
        }
        
        private void UpdateKnobSettings(PictureBox knobControl, int mouseY)
        {
            // 1. Beräkna ny vinkel baserat på dragning
            int deltaY = dragStartY - mouseY;
            float sensitivity = 1f; // Justera för känslighet (1.5f = 1.5 grader per pixel)
            float newAngle = startAngle + (deltaY * sensitivity);
            

            // 2. Begränsa vinkeln till det tillåtna intervallet (0 till MaxAngle)
            if (newAngle < -130) { newAngle = -130; }
            if (newAngle > MaxAngle) { newAngle = MaxAngle; }

            // 3. Uppdatera RÄTT variabel och trigga omdragning
            if (knobControl == KnobVol)
            {
                currentVolAngle = newAngle;

                // 1. Skapa ett värde mellan 0.0 och 1.0 baserat på rattens vinkel
                // (-130 grader blir 0.0, +130 grader blir 1.0)
                float volumeValue = (newAngle + 130f) / 260f;

                // 2. Skicka värdet till vår nya metod i ljudmotorn!
                audioEngine.SetVolume(volumeValue);

                // Uppdatera texten så den visar 0 - 100%
                textVol.Text = ((newAngle / 2.6) + 50).ToString();
            }
            else if (knobControl == KnobDist)
            {
                currentDistAngle = newAngle;

                // 1. Skapa ett normaliserat värde mellan 0.0 och 1.0
                float normalizedValue = (newAngle + 130f) / 260f;

                // 2. Skapa en "Drive". 
                // Vi börjar på 1.0 (inget dist) och går upp till t.ex. 20.0 (väldigt mycket dist).
                float driveValue = 1.0f + (normalizedValue * 49.0f);

                // 3. Skicka till ljudmotorn
                if (audioEngine.CurrentDistortionProvider != null)
                {
                    audioEngine.CurrentDistortionProvider.DriveFactor = driveValue;
                }

                textDist.Text = ((newAngle / 2.6) + 50).ToString("0");
            }
            else if (knobControl == KnobGain)
            {
                currentGainAngle = newAngle;

                // 1. Skapa ett basvärde mellan 0.0 och 1.0
                float normalizedValue = (newAngle + 130f) / 260f;

                // 2. Multiplicera med 4 för att skapa äkta "Amp Gain".
                // Nu går ratten från 0.0 (tyst) till 4.0 (extremt högt/distspräck!)
                // Testa att ändra 4.0f till en egen siffra för att hitta rätt känsla.
                float gainValue = normalizedValue * 4.0f;

                if (audioEngine.CurrentGainProvider != null)
                {
                    audioEngine.CurrentGainProvider.GainFactor = gainValue;
                }

                textGain.Text = ((newAngle / 2.6) + 50).ToString();
            }

            knobControl.Invalidate();
        }

        private void picturebox_mouseDown(object sender, MouseEventArgs e)
        {
            PictureBox knobControl = sender as PictureBox;
            if (knobControl == null) return;

            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartY = e.Y;

                // Spara RÄTT startvinkel för den kontroll som klickades
                if (knobControl == KnobVol) startAngle = currentVolAngle;
                else if (knobControl == KnobDist) startAngle = currentDistAngle;
                else if (knobControl == KnobGain) startAngle = currentGainAngle;

            }


            // OBS: Vi anropar INTE UpdateSettingsAndImage här. Uppdateringen sker vid dragning.
        }
        private void picturebox_mouseMoving(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                PictureBox knobControl = sender as PictureBox;
                if (knobControl == null) return;

                UpdateKnobSettings(knobControl, e.Y);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
        
            isDragging = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textDist_TextChanged(object sender, EventArgs e)
        {

        }

        private void textGain_TextChanged(object sender, EventArgs e)
        {

        }

        private void textVol_TextChanged(object sender, EventArgs e)
        {

        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            SaveEnter.Visible = true;
            SaveFileName.Visible = true;
        }

        private async void SaveEnter_Click(object sender, EventArgs e)
        {
            string fileName = SaveFileName.Text.Trim();

            if (string.IsNullOrWhiteSpace(fileName) || fileName.Equals("File name", StringComparison.OrdinalIgnoreCase))
            {
                SaveFileName.Text = "File name not entered";
                SaveFileName.Enabled = false;
                await Delay();

                SaveFileName.Enabled = true;
                SaveFileName.Text = "File name";
                return;
            }

            presetmanager.Save(fileName, currentVolAngle, currentGainAngle, currentDistAngle);
        }

        public bool ApplyLoadedSettings(float[] settings)
        {

            try
            {
                
                 // Uppdatera dina globala variabler
                 currentVolAngle = settings[0];
                 currentDistAngle = settings[1];
                 currentGainAngle = settings[2];

                 // Tvinga PictureBox-kontrollerna att rita om sig med de nya vinklarna
                 KnobVol.Invalidate();
                 KnobDist.Invalidate();
                 KnobGain.Invalidate();

                 textVol.Text = ((currentVolAngle / 2.6) + 50).ToString();
                 textGain.Text = ((currentGainAngle / 2.6) + 50).ToString();
                 textDist.Text = ((currentDistAngle / 2.6) + 50).ToString();

                 return true;
                    
                
            }
            catch (Exception)
            {
                MessageBox.Show("Could not load preset");
            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task<int> Delay()
        {
            await Task.Delay(2000);
            return 0;
        }

        private void LoadPresetFormButton_Click(object sender, EventArgs e)
        {
            // Skapa en instans av laddningsformuläret och skicka med en referens till huvudformen (this).
            LoadPresetForm loadForm = new LoadPresetForm(this);
            loadForm.ShowDialog();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadAudioFiles()
        {
            AudioFilesBox.Items.Clear();

            LabelInfo.Text = "Welcome to ArtDist!";

            if (!Directory.Exists(_saveDirectory))
            {
                MessageBox.Show("Save list was not found", "Error");
                return;
            }
            try
            {
                string[] filePaths = Directory.GetFiles(_saveDirectory, "*.wav");

                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    // Lägg till i listan
                    AudioFilesBox.Items.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not read files: {ex.Message}", "File error");
            }

        }

        private void AudioFilesBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void PlayAudio_Click(object sender, EventArgs e)
        {
            if (AudioFilesBox.SelectedItem != null)
            {
                string AudioFile = AudioFilesBox.SelectedItem.ToString();
                audioEngine.play(AudioFile);

                // NYTT: Tvinga ljudmotorn att hämta de aktuella värdena från rattarna direkt när ljudet startar!

                // Räkna ut volymen baserat på rattens nuvarande position
                float currentVol = (currentVolAngle + 130f) / 260f;
                audioEngine.SetVolume(currentVol);



                // Räkna ut gain baserat på rattens nuvarande position
                float currentGain = ((currentGainAngle + 130f) / 260f) * 4.0f;

                float currentDist = ((currentDistAngle + 130f) / 260f) * 49.0f;


                if (audioEngine.CurrentGainProvider != null)
                {
                    audioEngine.CurrentGainProvider.GainFactor = currentGain;
                }

                if (audioEngine.CurrentDistortionProvider != null)
                {
                    audioEngine.CurrentDistortionProvider.DriveFactor = currentDist;
                }
            }
            else
            {
                LabelInfo.Text = "Nothing selected";
                await Delay();
                LabelInfo.Text = "Welcome to AmpEx!";
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadAudioFiles();
        }
    }
}
