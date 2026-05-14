using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtDist_GUI
{
    internal class PresetManager
    {
        public void Save(string fileName, float vol, float gain, float dist) 
        {

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LayoutFiles", fileName + ".txt");


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

                    // Skapar filen
                    File.WriteAllText(filePath, settingsData);

                }
                catch (Exception ex)
                {
                    // Hantera fel som kan uppstå vid skrivning
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        public float[] Load(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LayoutFiles", fileName + ".txt");

            // Kollar om filen finns
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File was not found: " + filePath);
                return null;
            }

            try
            {
                // Läser alla rader till en array
                string[] lines = File.ReadAllLines(filePath);

                // Kontrollerar att vi har tillräckligt med rader [4]
                if (lines.Length >= 3)
                {
                    // Konverterar varje specifik rad (index 0, 1, 2) [4]
                    if (float.TryParse(lines[0], out float volAngle) &&
                        float.TryParse(lines[1], out float distAngle) &&
                        float.TryParse(lines[2], out float gainAngle))
                    {
                        // SUCCESS: Skickar tillbaka värdena som en array
                        return new float[] { volAngle, distAngle, gainAngle };
                    }
                }

                MessageBox.Show("File has wrong format or is missing data.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't load: {ex.Message}");
                return null;
            }
        }

        public void Delete(string fileName)
        {
            // Skapar sökvägen på samma sätt som i AudioFileReader-exemplen i källorna [4, 5]
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LayoutFiles", fileName + ".txt");

            try
            {
                // Kontrollerar om filen existerar innan vi försöker radera den
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("File was not found.");
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while deleting: " + ex.Message);
            }
        }


    }
}
