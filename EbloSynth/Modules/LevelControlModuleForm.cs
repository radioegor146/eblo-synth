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
    internal partial class LevelControlModuleForm : ModuleForm
    {
        private readonly LevelControlModule levelControlModule;

        public LevelControlModuleForm(LevelControlModule levelControlModule)
        {
            this.levelControlModule = levelControlModule;
            InitializeComponent();
        }

        private void levelTrackBar_Scroll(object sender, EventArgs e)
        {
            levelControlModule.Level = levelTrackBar.Value / 1000f;
        }

        private void soundInputButton_Click(object sender, EventArgs e)
        {
            levelControlModule.Processor.MainForm.ConnectionPointClicked(levelControlModule.SoundInput);
        }

        private void cvInputButton_Click(object sender, EventArgs e)
        {
            levelControlModule.Processor.MainForm.ConnectionPointClicked(levelControlModule.CvInput);
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            levelControlModule.Processor.MainForm.ConnectionPointClicked(levelControlModule.SoundOutput);
        }
    }
}
