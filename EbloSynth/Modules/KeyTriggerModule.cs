using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbloSynth.Modules
{
    internal class KeyTriggerModule : Module
    {
        public Output<double> CvOutput { get; }

        public KeyTriggerModule(Processor processor) : base(processor)
        {
            CvOutput = new Output<double>("CV", this, processor.Config.BufferSize);
        }

        public override string Name => "Key Trigger";

        public override List<Input> Inputs => new List<Input>();

        public override List<Output> Outputs => new List<Output>
        {
            CvOutput
        };

        public volatile bool IsKeyPressed;

        public override void RequestProcessing(int samples)
        {
            var buffer = new double[samples];
            for (var i = 0; i < samples; i++)
                buffer[i] = IsKeyPressed ? 5.0 : 0.0;
            CvOutput.Write(buffer, 0, buffer.Length);
        }

        protected override ModuleForm CreateModuleForm() => new KeyTriggerModuleForm(this);
    }

    internal class KeyTriggerModuleFactory : ModuleFactory
    {
        public override Module Create(Processor processor) => new KeyTriggerModule(processor);

        public override string Name => "Key Trigger";
    }
}
