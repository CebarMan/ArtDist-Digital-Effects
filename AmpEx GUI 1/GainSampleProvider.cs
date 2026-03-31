using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace ArtDist_GUI
{
    internal class GainSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider source;
        public float GainFactor { get; set; } = 1.0f;

        // Den här måste ha ett värde för att .Init() ska fungera!
        public WaveFormat WaveFormat
        {
            get { return source.WaveFormat; }
        }

        public GainSampleProvider(ISampleProvider source)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);

            // 1. Loopa igenom ljudet
            for (int n = 0; n < samplesRead; n++)
            {
                // Multiplicera med Gain-ratten
                buffer[offset + n] *= GainFactor;
            }

            // 2. CENTRERA LJUDET (Lösningen på höger/vänster-problemet!)
            // Om ljudet är i stereo (2 kanaler), tvinga höger kanal att spela samma sak som vänster
            if (WaveFormat.Channels == 2)
            {
                // I stereo ligger ljudet i arrayen som [Vänster, Höger, Vänster, Höger...]
                // Vi hoppar fram 2 steg i taget (n += 2)
                for (int n = 0; n < samplesRead; n += 2)
                {
                    float leftChannel = buffer[offset + n];

                    // Skriv över höger kanal (n + 1) med ljudet från vänster kanal
                    buffer[offset + n + 1] = leftChannel;
                }
            }

            return samplesRead;
        }
    }
}
