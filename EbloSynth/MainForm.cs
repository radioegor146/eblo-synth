using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbloSynth
{
    internal sealed partial class MainForm : Form
    {
        public Processor Processor { get; }

        public ConnectionPoint CurrentConnectionPoint { get; set; }

        public MainForm(Processor processor)
        {
            Processor = processor;
            InitializeComponent();

            foreach (var factory in processor.Factories)
                modulesToolStripMenuItem.DropDown.Items.Add(factory.Name, null, (s, e) =>
                {
                    var module = factory.Create(processor);
                    var moduleForm = module.ModuleForm;
                    moduleForm.SetDoubleBuffered();
                    moduleForm.MdiParent = this;

                    moduleForm.Show();
                    moduleForm.FormClosed += (_, __) => processor.RemoveModule(module);
                    processor.AddModule(module);
                });
        }

        public void ConnectionPointClicked(ConnectionPoint connectionPoint)
        {
            Console.WriteLine($@"Clicked: {connectionPoint}");

            if (connectionPoint.IsConnected)
            {
                if (CurrentConnectionPoint != null)
                    return;

                {
                    if (connectionPoint.ConnectedConnectionPoint is Input destination && connectionPoint is Output source)
                    {
                        Processor.Disconnect(source, destination);
                        return;
                    }
                }

                {
                    if (connectionPoint is Input destination && connectionPoint.ConnectedConnectionPoint is Output source)
                    {
                        Processor.Disconnect(source, destination);
                        return;
                    }
                }
            }

            if (CurrentConnectionPoint == null)
            {
                CurrentConnectionPoint = connectionPoint;
                return;
            }

            if (CurrentConnectionPoint == connectionPoint)
            {
                CurrentConnectionPoint = null;
                return;
            }

            {
                if (CurrentConnectionPoint is Input destination && connectionPoint is Output source)
                {
                    if (!Processor.CanConnect(source, destination))
                        return;
                    
                    CurrentConnectionPoint = null;
                    Processor.Connect(source, destination);
                    return;
                }
            }

            {
                if (!(connectionPoint is Input destination) ||
                    !(CurrentConnectionPoint is Output source)) 
                    return;

                if (!Processor.CanConnect(source, destination))
                    return;

                CurrentConnectionPoint = null;
                Processor.Connect(source, destination);
            }
        }
    }
}
