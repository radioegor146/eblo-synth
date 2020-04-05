using System;

namespace EbloSynth
{
    internal abstract class ConnectionPoint
    {
        public abstract string Name { get; }

        public abstract Type ConnectionType { get; }

        public abstract Module Module { get; }

        public bool IsConnected => ConnectedConnectionPoint != null;

        public abstract ConnectionPoint ConnectedConnectionPoint { get; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ConnectionType)}: {ConnectionType}, {nameof(Module)}: {Module}, {nameof(IsConnected)}: {IsConnected}";
        }
    }

    internal abstract class Input : ConnectionPoint
    {
        public override ConnectionPoint ConnectedConnectionPoint => ConnectedOutput;

        public abstract Output ConnectedOutput { get; }

        public abstract void Disconnect();

        public abstract void Connect(Output output);
    }

    internal abstract class Output : ConnectionPoint
    {
        public override ConnectionPoint ConnectedConnectionPoint => ConnectedInput;

        public abstract Input ConnectedInput { get; }

        public abstract void Disconnect();

        public abstract void Connect(Input output);
    }
}