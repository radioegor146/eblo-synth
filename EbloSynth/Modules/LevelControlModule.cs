using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbloSynth.Modules
{
    internal class LevelControlModule : Module
    {
        public Input<float> SoundInput { get; }

        public Input<double> CvInput { get; }

        public Output<float> SoundOutput { get; }

        public LevelControlModule(Processor processor) : base(processor)
        {
            SoundInput = new Input<float>("Input", this);
            CvInput = new Input<double>("CV", this);
            SoundOutput = new Output<float>("Output", this, processor.Config.BufferSize);
        }

        public override string Name => "Level Control";

        public override List<Input> Inputs => new List<Input>
        {
            SoundInput,
            CvInput
        };

        public override List<Output> Outputs => new List<Output>
        {
            SoundOutput
        };

        public volatile float Level;

        public override void RequestProcessing(int samples)
        {
            var inputData = new float[samples];
            SoundInput.Read(inputData, 0, inputData.Length);

            double[] levelData = null;
            if (CvInput.IsConnected)
            {
                levelData = new double[samples];
                CvInput.Read(levelData, 0, levelData.Length);
            }

            for (var i = 0; i < samples; i++)
                inputData[i] = (float) (inputData[i] * Math.Max(0.0, Math.Min(1.0, levelData?[i] ?? Level)));

            SoundOutput.Write(inputData, 0, inputData.Length);
        }

        protected override ModuleForm CreateModuleForm() => new LevelControlModuleForm(this);
    }

    internal class LevelControlModuleFactory : ModuleFactory
    {
        public override Module Create(Processor processor) => new LevelControlModule(processor);

        public override string Name => "Level control";
    }
}
