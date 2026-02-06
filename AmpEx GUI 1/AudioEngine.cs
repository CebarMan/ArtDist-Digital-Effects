using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace AmpEx_GUI_1
{
    internal class AudioEngine
    {
        private IWavePlayer WaveOut;
        private AudioFileReader audiofilereader;
        
        public void play(string AudioFile)
        {
            AudioFile = AppDomain.CurrentDomain.BaseDirectory + AudioFile;
            audiofilereader = new AudioFileReader(AudioFile + ".wav");

            WaveOut = new WaveOutEvent();
            WaveOut.Init(audiofilereader);
            WaveOut.Play();
        }

    }
}
