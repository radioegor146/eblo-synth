using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace EbloSynth.Modules
{
    internal partial class OutputModuleForm : ModuleForm
    {
        private readonly OutputModule outputModule;

        public OutputModuleForm(OutputModule outputModule)
        {
            this.outputModule = outputModule;
            InitializeComponent();
            RefreshDeviceList();
        }

        private Device currentDevice;

        private class Device
        {
            public MMDevice SoundDevice { get; }

            public Device(MMDevice device)
            {
                SoundDevice = device ?? throw new ArgumentNullException(nameof(device));
            }

            private bool Equals(Device other) => SoundDevice.Equals(other.SoundDevice);

            public override bool Equals(object obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((Device) obj);
            }

            public override int GetHashCode() => SoundDevice.GetHashCode();

            public override string ToString() => SoundDevice.FriendlyName;
        }

        private void RefreshDeviceList()
        {
            var enumerator = new MMDeviceEnumerator();

            deviceComboBox.Items.Clear();
            foreach (var device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                deviceComboBox.Items.Add(new Device(device));
        }

        private void refreshDeviceListButton_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(deviceComboBox.SelectedItem is Device device))
                return;

            if (Equals(device, currentDevice)) 
                return;
            
            currentDevice = device;
            outputModule.DeviceChanged(device.SoundDevice);
        }

        private void inputLButton_Click(object sender, EventArgs e)
        {
            outputModule.Processor.MainForm.ConnectionPointClicked(outputModule.SoundInputL);
        }

        private void inputRButton_Click(object sender, EventArgs e)
        {
            outputModule.Processor.MainForm.ConnectionPointClicked(outputModule.SoundInputR);
        }
    }
}
