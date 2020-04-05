using System;
using System.IO.Pipes;

namespace EbloSynth
{
    internal class Input<T> : Input
    {
        public override string Name { get; }

        public override Module Module { get; }
        
        private Output connectedOutput;

        public override Output ConnectedOutput => connectedOutput;

        public Input(string name, Module module)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Module = module ?? throw new ArgumentNullException(nameof(name));
        }

        public override void Disconnect()
        {
            var oldConnectedOutput = ConnectedOutput;
            connectedOutput = null;
            oldConnectedOutput?.Disconnect();
        }

        public override void Connect(Output output)
        {
            if (ConnectedOutput != null)
            {
                if (ConnectedOutput != output)
                    throw new InvalidOperationException("Already connected");
                return;
            }

            connectedOutput = output;
            output.Connect(this);
        }

        public void Read(T[] buffer, int offset, int count)
        {
            if (ConnectedOutput != null)
            {
                if (!(ConnectedOutput is Output<T> typedOutput))
                    throw new ArgumentException($@"{nameof(ConnectedOutput)} is not {nameof(Output<T>)}",
                        nameof(ConnectedOutput));
                typedOutput.Read(buffer, offset, count);
                return;
            }

            for (var i = offset; i < offset + count; i++)
                buffer[i] = default;
        }

        public override Type ConnectionType => typeof(T);
    }
}