using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbloSynth.Modules
{
    internal partial class SineSynthModuleForm : ModuleForm
    {
        private readonly SineSynthModule sineSynthModule;

        public SineSynthModuleForm(SineSynthModule sineSynthModule)
        {
            this.sineSynthModule = sineSynthModule;
            InitializeComponent();
        }

        private void frequencyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            sineSynthModule.Frequency = (float) frequencyNumericUpDown.Value;
        }

        private void cvInputButton_Click(object sender, EventArgs e)
        {
            sineSynthModule.Processor.MainForm.ConnectionPointClicked(sineSynthModule.CvInput);
        }

        private void soundOutputButton_Click(object sender, EventArgs e)
        {
            sineSynthModule.Processor.MainForm.ConnectionPointClicked(sineSynthModule.SoundOutput);
        }
    }
}
