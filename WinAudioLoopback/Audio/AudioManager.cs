using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace WinAudioLoopback.Audio
{
    class AudioManager
    {
        public MMDeviceCollection inputDevices;
        public MMDeviceCollection outputDevices;

        private MMDeviceEnumerator deviceEnumerator;
        [AllowNull]
        private WasapiCapture capture;
        [AllowNull]
        private WasapiOut playback;
        [AllowNull]
        private BufferedWaveProvider buffer;
        [AllowNull]
        private VolumeSampleProvider volumeProvider;

        public AudioManager()
        {
            deviceEnumerator = new MMDeviceEnumerator();

            inputDevices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            outputDevices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

            Debug.WriteLine("- Input devices -");

            foreach (var item in inputDevices)
            {
                Debug.WriteLine(item.FriendlyName);
            }

            Debug.WriteLine("- Output devices -");

            foreach (var item in outputDevices)
            {
                Debug.WriteLine(item.FriendlyName);
            }
        }

        public void EnableLoopback(string inputName, string outputName)
        {
            var inputId = GetDeviceID(DataFlow.Capture, inputName);
            var outputId = GetDeviceID(DataFlow.Render, outputName);

            var inputDevice = deviceEnumerator.GetDevice(inputId);
            var outputDevice = deviceEnumerator.GetDevice(outputId);

            capture = new WasapiCapture(inputDevice);
            capture.ShareMode = AudioClientShareMode.Shared;
            capture.WaveFormat = inputDevice.AudioClient.MixFormat;

            buffer = new BufferedWaveProvider(capture.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };

            capture.DataAvailable += (s, e) =>
            {
                buffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
            };

            var sampleProvider = buffer.ToSampleProvider();

            volumeProvider = new VolumeSampleProvider(sampleProvider)
            {
                Volume = 0.5f
            };

            playback = new WasapiOut(outputDevice, AudioClientShareMode.Shared, false, 20);

            playback.Init(volumeProvider);

            capture.StartRecording();
            playback.Play();
        }

        public void DisableLoopback()
        {
            capture?.StopRecording();
            playback?.Stop();
            capture?.Dispose();
            playback?.Dispose();
        }

        public void SetVolume(int volumePercent)
        {
            var scaledVolume = (float)volumePercent / 100;

            volumeProvider.Volume = Math.Clamp(scaledVolume, 0.0f, 1.5f);
        }

        private string? GetDeviceID(DataFlow flow, string name)
        {
            var collection = flow == DataFlow.Capture ? inputDevices : outputDevices;

            try
            {
                return collection.First(item => item.FriendlyName == name).ID;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
