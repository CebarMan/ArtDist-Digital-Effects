using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ArtDist_GUI
{
    public partial class LoadPresetForm : Form
    {
        private Form1 _mainForm;
        private readonly string _saveDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public delegate void ClickButton();
        PresetManager presetManager = new PresetManager();
        public LoadPresetForm(Form1 mainForm)
        {
            InitializeComponent();
            // Lagra referensen till Form1
            _mainForm = mainForm;
            LoadPresetFiles();
        }

        private void LoadPresetForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadPresetFiles()
        {
            PresetsListBox.Items.Clear();

            InfoLabel.Text = string.Empty;

            if (!Directory.Exists(_saveDirectory)) {
                MessageBox.Show("Save list was not found", "Error");
                return;
            }
            try
            {
                string[] filePaths = Directory.GetFiles(_saveDirectory, "*.txt");

                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    // Lägg till i listan
                    PresetsListBox.Items.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not read files: {ex.Message}", "File error");
            }

        }

        private void PresetsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (PresetsListBox.SelectedIndex >= 0)
            {
                //Hämta det valda filnamnet
                string fileName = PresetsListBox.SelectedItem.ToString();
                _mainForm.ApplyLoadedSettings(presetManager.Load(fileName));
                this.Close();
            }
            else
            {
                InfoLabel.Text = "Nothing selected";
                Delay(1000);
                InfoLabel.Text = string.Empty;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (PresetsListBox.SelectedItem != null)
            {
                string selectedFileName = PresetsListBox.SelectedItem.ToString();

             
                presetManager.Delete(selectedFileName);

                
                LoadPresetFiles();
            }
            else
            {
                MessageBox.Show("Please choose a file to delete.");
            }
        }

        private void Delay(int TimeMs)
        {
            System.Threading.Thread.Sleep(TimeMs);
        }


    }
}
