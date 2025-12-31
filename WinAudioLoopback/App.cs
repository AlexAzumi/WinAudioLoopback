using WinAudioLoopback.Audio;

namespace WinAudioLoopback
{
    public partial class App : Form
    {
        private AudioManager _audioManager = new();
        private bool activeLoopback = false;

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            foreach (var item in _audioManager.inputDevices)
            {
                inputDevicesCB.Items.Add(item.FriendlyName);
            }

            inputDevicesCB.Text = _audioManager.inputDevices[0].FriendlyName;

            foreach (var item in _audioManager.outputDevices)
            {
                outputDevicesCB.Items.Add(item.FriendlyName);
            }

            outputDevicesCB.Text = _audioManager.outputDevices[0].FriendlyName;
        }

        private void toggleBtn_Click(object sender, EventArgs e)
        {
            if (activeLoopback)
            {
                _audioManager.DisableLoopback();
                toggleBtn.Text = "Enable loopback";
                toggleBtn.ForeColor = Color.Black;
                volumeTb.Enabled = false;
                activeLoopback = false;

                return;
            }

            _audioManager.EnableLoopback(inputDevicesCB.Text, outputDevicesCB.Text);
            toggleBtn.Text = "Disable loopback";
            toggleBtn.ForeColor = Color.IndianRed;
            volumeTb.Enabled = true;
            activeLoopback = true;
        }

        private void volumeTb_ValueChanged(object sender, EventArgs e)
        {
            if (activeLoopback)
            {
                _audioManager.SetVolume(volumeTb.Value);
                volumeGb.Text = $"Volume: {volumeTb.Value}%";
            }
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            _audioManager.DisableLoopback();
        }
    }
}
