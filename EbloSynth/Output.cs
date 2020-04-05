using System;
using System.Diagnostics.CodeAnalysis;

namespace EbloSynth
{
    internal class Output<T> : Output
    {
        public override string Name { get; }

        public override Module Module { get; }

        public readonly CircularStream<T> DataStream;

        private Input connectedInput;

        public override Input ConnectedInput => connectedInput;

        public Output(string name, Module module, int bufferSize)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Module = module ?? throw new ArgumentNullException(nameof(name));
            DataStream = new CircularStream<T>(bufferSize * 2);
        }

        public override Type ConnectionType => typeof(T);
        
        public override void Disconnect()
        {
            var oldConnectedInput = ConnectedInput;
            connectedInput = null;
            oldConnectedInput?.Disconnect();
        }

        public override void Connect(Input input)
        {
            if (ConnectedInput != null)
            {
                if (ConnectedInput != input)
                    throw new InvalidOperationException("Already connected");
                return;
            }

            connectedInput = input;
            input.Connect(this);
        }

        [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
        public void Write(T[] buffer, int offset, int count)
        {
            if (ConnectedInput == null)
                DataStream.Reset();
            else
                DataStream.Write(buffer, offset, count);
        }

        public void Read(T[] buffer, int offset, int count)
        {
            lock (Module)
            {
                var read = 0;
                while (read < count)
                {
                    read += DataStream.Read(buffer, offset + read, count - read);
                    Module.RequestProcessing(count - read);
                }
            }
        }
    }
}