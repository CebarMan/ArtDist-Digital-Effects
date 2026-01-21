using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmpEx_GUI_1
{
    internal class PresetManager
    {
        public void Save(string fileName, float vol, float gain, float dist) 
        {

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".txt");


            if (File.Exists(filePath))
            {
                MessageBox.Show("File already exists");
                return;

            }

            else
            {
                try
                {
                    string settingsData =
                    vol + Environment.NewLine +
                    dist + Environment.NewLine +
                    gain.ToString();

                    // Exempel på att skapa filen:
                    File.WriteAllText(filePath, settingsData);

                    MessageBox.Show(filePath + " successfully created");
                }
                catch (Exception ex)
                {
                    // Hantera fel som kan uppstå vid skrivning (t.ex. behörighetsproblem)
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        public float[] Load(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".txt");

            // 1. Kolla om filen finns INNAN vi försöker läsa den
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Filen hittades inte: " + filePath);
                return null;
            }

            try
            {
                // 2. Läs alla rader till en array
                string[] lines = File.ReadAllLines(filePath);

                // 3. Kontrollera att vi har tillräckligt med rader [4]
                if (lines.Length >= 3)
                {
                    // 4. Konvertera varje specifik rad (index 0, 1, 2) [4]
                    if (float.TryParse(lines[0], out float volAngle) &&
                        float.TryParse(lines[1], out float distAngle) &&
                        float.TryParse(lines[2], out float gainAngle))
                    {
                        // SUCCESS: Skicka tillbaka värdena som en array
                        return new float[] { volAngle, distAngle, gainAngle };
                    }
                }

                MessageBox.Show("Filen har fel format eller saknar data.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tekniskt fel vid laddning: {ex.Message}");
                return null;
            }
        }

        public void Delete(string fileName) 
        { 
        
        }


    }
}
