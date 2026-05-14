using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;


namespace ArtDist_GUI
{
    internal class DistortionSampleProvider : ISampleProvider
    {
        // Tar ljudet från GainSampleProvider och applicerar en distorsionseffekt
        private readonly ISampleProvider source;

        // Bestämmer hur hårt ljudet pressas genom dist-funktionen
        // 1.0 = rent ljud, högre värden = mer distorsion
        public float DriveFactor { get; set; } = 1.0f;

        // Berättar vilket filformat 
        public WaveFormat WaveFormat { get { return source.WaveFormat; } }

        public DistortionSampleProvider(ISampleProvider source)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public int Read(float[] buffer, int offset, int count)
        {
            // Läs in ljudet från föregående länk i kedjan (Gain)
            int samplesRead = source.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                float sample = buffer[offset + n];

                // Lägger till Soft Clipping (Rör-förstärkarsimulering)
                // Math.Tanh håller automatiskt värdet mellan -1.0 och +1.0
                // komprimerar och distar ljudet ju högre DriveFactor är
                sample = (float)Math.Tanh(sample * DriveFactor);

                buffer[offset + n] = sample;
            }
            return samplesRead;
        }
    }
}
