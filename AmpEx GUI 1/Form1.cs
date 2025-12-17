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

namespace AmpEx_GUI_1
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


        public Form1()
        {
            InitializeComponent();


            KnobDist.BackColor = System.Drawing.Color.Transparent;
            KnobGain.BackColor = System.Drawing.Color.Transparent;
            KnobVol.BackColor = System.Drawing.Color.Transparent; 
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

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
                // Här översätter du currentVolAngle till det faktiska volymvärdet (0-100)
                // float volumeValue = (newAngle / MaxAngle) * 100f; 
                textVol.Text = ((newAngle / 2.6) + 50).ToString();
            }
            else if (knobControl == KnobDist)
            {
                currentDistAngle = newAngle;
                // Lägg till din distorsionslogik här
                textDist.Text = ((newAngle / 2.6) + 50).ToString();
            }
            else if (knobControl == KnobGain)
            {
                currentGainAngle = newAngle;
                // Lägg till din gain-logik här
                textGain.Text = ((newAngle/2.6)+50).ToString();
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

        private async void button1_Click(object sender, EventArgs e)
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

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".txt");


            if (File.Exists(filePath))
            {
                SaveFileName.Text = "File already exists";
                SaveFileName.Enabled = false;
                await Delay();

                SaveFileName.Enabled = true;
                SaveFileName.Text = "File name";
                return;

            }

            else {
                try
                {
                    string settingsData =
                    currentVolAngle.ToString() + Environment.NewLine +
                    currentDistAngle.ToString() + Environment.NewLine +
                    currentGainAngle.ToString();

                    // Exempel på att skapa filen:
                    File.WriteAllText(filePath, settingsData);
                    SaveFileName.Text = $"File '{fileName}' created successfully!";
                    SaveFileName.Enabled = false;
                    await Delay();

                    SaveFileName.Enabled = true;
                    SaveFileName.Text = "File Name";
                }
                catch (Exception ex)
                {
                    // Hantera fel som kan uppstå vid skrivning (t.ex. behörighetsproblem)
                    SaveFileName.Text = "Error creating file.";
                    MessageBox.Show($"Error: {ex.Message}");
                    await Delay();
                }
            }
        }

        public bool ApplyLoadedSettings(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            try
            {
                MessageBox.Show(filePath);
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 3)
                {
                    if (float.TryParse(lines[0], out float volAngle) &&
                        float.TryParse(lines[1], out float distAngle) &&
                        float.TryParse(lines[2], out float gainAngle))
                    {
                        // Uppdatera dina globala variabler
                        currentVolAngle = volAngle;
                        currentDistAngle = distAngle;
                        currentGainAngle = gainAngle;

                        // Tvinga PictureBox-kontrollerna att rita om sig med de nya vinklarna
                        KnobVol.Invalidate();
                        KnobDist.Invalidate();
                        KnobGain.Invalidate();

                        textVol.Text = ((currentVolAngle / 2.6) + 50).ToString();
                        textGain.Text = ((currentGainAngle / 2.6) + 50).ToString();
                        textDist.Text = ((currentDistAngle / 2.6) + 50).ToString();

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunde inte ladda preset");
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
    }
}
