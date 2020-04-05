using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbloSynth.Modules
{
    internal class SplitterModule<T> : Module
    {
        private readonly string typeName;

        public Input<T> Input { get; } 

        public Output<T> Output1 { get; }

        public Output<T> Output2 { get; }

        public SplitterModule(string typeName, Processor processor) : base(processor)
        {
            this.typeName = typeName;
            Input = new Input<T>("Input", this);
            Output1 = new Output<T>("Output 1", this, processor.Config.BufferSize);
            Output2 = new Output<T>("Output 2", this, processor.Config.BufferSize);
        }

        public override string Name => $@"{typeName} Splitter";

        public override List<Input> Inputs => new List<Input>
        {
            Input
        };

        public override List<Output> Outputs => new List<Output>
        {
            Output1,
            Output2
        };

        public override void RequestProcessing(int samples)
        {
            var buffer = new T[samples];
            Input.Read(buffer, 0, buffer.Length);
            Output1.Write(buffer, 0, buffer.Length);
            Output2.Write(buffer, 0, buffer.Length);
        }

        protected override ModuleForm CreateModuleForm() => new SplitterModuleForm<T>(this);
    }

    internal class SplitterModuleFactory<T> : ModuleFactory
    {
        private readonly string typeName;

        public SplitterModuleFactory(string typeName)
        {
            this.typeName = typeName;
        }

        public override Module Create(Processor processor) => new SplitterModule<T>(typeName, processor);

        public override string Name => $"{typeName} Splitter";
    }
}
