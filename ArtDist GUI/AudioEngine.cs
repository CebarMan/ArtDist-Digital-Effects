using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace ArtDist_GUI
{
    internal class AudioEngine
    {
        private IWavePlayer WaveOut;
        private AudioFileReader audiofilereader;

        public GainSampleProvider CurrentGainProvider { get; private set; }
        public DistortionSampleProvider CurrentDistortionProvider { get; private set; }

        public VolumeSampleProvider MasterVolumeProvider { get; private set; }

        public void play(string AudioFile)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AudioFile + ".wav");

            if (!File.Exists(path))
            {
                MessageBox.Show("Audio file not found.");
                return;
            }

            try
            {
                DisposeWave("");

                
                audiofilereader = new AudioFileReader(path); // 1. Ljudfilen (Källan)

                ISampleProvider sourceProvider = audiofilereader;

                
                CurrentGainProvider = new GainSampleProvider(sourceProvider); // 2. Försteget (Gain)
                                                                              
                CurrentDistortionProvider = new DistortionSampleProvider(CurrentGainProvider); // 3. Dist-effekten

                MasterVolumeProvider = new VolumeSampleProvider(CurrentDistortionProvider); // Volym

                

                MasterVolumeProvider.Volume = 1.0f; // Standardvolym

                // 4. Ljudkortet
                WaveOut = new WaveOutEvent();

                if (audiofilereader != null)
                {
                    
                    WaveOut.Init(MasterVolumeProvider);
                    WaveOut.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing audio: {ex.Message}");
            }
        }

        public void SetVolume(float volume)
        {
            // Ändra volymen i vår nya MasterVolumeProvider istället för inuti AudioFileReader
            if (MasterVolumeProvider != null)
            {
                if (volume < 0.0f) volume = 0.0f;
                if (volume > 1.0f) volume = 1.0f;

                MasterVolumeProvider.Volume = volume;
            }
        }

        public void DisposeWave(string AudioFile)
        {
            if (WaveOut != null)
            {
                WaveOut.Stop();
                WaveOut.Dispose();
                WaveOut = null;
            }
            if (audiofilereader != null)
            {
                audiofilereader.Dispose();
                audiofilereader = null;
            }
        }
    }
}