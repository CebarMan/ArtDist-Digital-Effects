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

namespace AmpEx_GUI_1
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
                MessageBox.Show("Sparkatalogen hittades inte", "Fel");
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
                MessageBox.Show($"Kunde inte läsa filer från mappen: {ex.Message}", "Filfel");
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
            }
            else
            {
                InfoLabel.Text = "Nothing selected";
            }
        }



    }
}
