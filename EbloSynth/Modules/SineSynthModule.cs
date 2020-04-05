using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbloSynth.Modules
{
    internal class SineSynthModule : Module
    {
        public Input<double> CvInput { get; }

        public Output<float> SoundOutput { get; }

        public SineSynthModule(Processor processor) : base(processor)
        {
            CvInput = new Input<double>("CV", this);
            SoundOutput = new Output<float>("Output", this, processor.Config.BufferSize);
        }

        public override string Name => "Sine Synth";

        public override List<Input> Inputs => new List<Input>
        {
            CvInput
        };

        public override List<Output> Outputs => new List<Output>
        {
            SoundOutput
        };

        public volatile float Frequency = 228;

        private long sampleIndex;

        private static float GetFrequency(double voltage) => (float) (440 / Math.Pow(2, 2.75 + voltage));

        public override void RequestProcessing(int samples)
        {
            var buffer = new float[samples];

            double[] cvBuffer = null;

            if (CvInput.IsConnected)
            {
                cvBuffer = new double[samples];
                CvInput.Read(cvBuffer, 0, cvBuffer.Length);
            }

            for (var i = 0; i < samples; i++)
            {
                buffer[i] = (float) Math.Sin((Math.PI * 2 * (cvBuffer == null ? Frequency : GetFrequency(cvBuffer[i])) 
                                              / Processor.Config.SampleRate) * sampleIndex);
                sampleIndex++;
            }

            SoundOutput.Write(buffer, 0, buffer.Length);
        }

        protected override ModuleForm CreateModuleForm() => new SineSynthModuleForm(this);
    }

    internal class SineSynthModuleFactory : ModuleFactory
    {
        public override Module Create(Processor processor) => new SineSynthModule(processor);

        public override string Name => "Sine Synth";
    }
}
