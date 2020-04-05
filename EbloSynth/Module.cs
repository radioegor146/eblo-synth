using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EbloSynth
{
    internal abstract class Module : IDisposable
    {
        public Processor Processor { get; }

        protected Module(Processor processor)
        {
            Processor = processor;
        }

        public abstract string Name { get; }

        public abstract List<Input> Inputs { get; }

        public abstract List<Output> Outputs { get; }

        private ModuleForm moduleForm;

        public ModuleForm ModuleForm => moduleForm ?? (moduleForm = CreateModuleForm());

        public abstract void RequestProcessing(int samples);

        protected abstract ModuleForm CreateModuleForm();

        public virtual void Dispose() { }
    }

    internal class ModuleForm : Form
    {
        public void SetDoubleBuffered()
        {
            DoubleBuffered = true;
        }

        public virtual Point GetConnectionPointPosition(ConnectionPoint connectionPoint) => throw new InvalidOperationException();
    }

    internal abstract class ModuleFactory
    {
        public abstract Module Create(Processor processor);

        public abstract string Name { get; }
    }
}