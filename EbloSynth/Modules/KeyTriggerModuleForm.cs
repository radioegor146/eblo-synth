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
    internal partial class KeyTriggerModuleForm : ModuleForm
    {
        private readonly KeyTriggerModule keyTriggerModule;

        public KeyTriggerModuleForm(KeyTriggerModule keyTriggerModule)
        {
            this.keyTriggerModule = keyTriggerModule;
            InitializeComponent();
        }

        private void cvOutputButton_Click(object sender, EventArgs e)
        {
            keyTriggerModule.Processor.MainForm.ConnectionPointClicked(keyTriggerModule.CvOutput);
        }

        private void triggerButton_MouseDown(object sender, MouseEventArgs e)
        {
            keyTriggerModule.IsKeyPressed = true;
        }

        private void triggerButton_MouseUp(object sender, MouseEventArgs e)
        {
            keyTriggerModule.IsKeyPressed = false;
        }
    }
}
