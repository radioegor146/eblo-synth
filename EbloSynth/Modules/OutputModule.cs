using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace EbloSynth.Modules
{
    internal class OutputModule : Module, IWaveProvider
    {
        public Input<float> SoundInputL { get; }

        public Input<float> SoundInputR { get; }

        private WasapiOut wasapiOut;

        public WaveFormat WaveFormat { get; }

        public OutputModule(Processor processor) : base(processor)
        {
            SoundInputL = new Input<float>("Input L", this);
            SoundInputR = new Input<float>("Input R", this);
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(processor.Config.SampleRate, 2);
        }

        public override string Name => "Output";

        public override List<Input> Inputs => new List<Input> 
        {
            SoundInputL,
            SoundInputR
        };

        public override List<Output> Outputs => new List<Output>();

        protected override ModuleForm CreateModuleForm() => new OutputModuleForm(this);

        public override void RequestProcessing(int samples) =>
            throw new ArgumentException("Can't process no-output module");

        public override void Dispose()
        {
            lock (this)
            {
                wasapiOut?.Stop();
            }
        }

        public void DeviceChanged(MMDevice device)
        {
            lock (this)
            {
                wasapiOut?.Stop();
                wasapiOut = new WasapiOut(device, AudioClientShareMode.Shared, true, 40);
                wasapiOut.Init(this);
                wasapiOut.Play();
            }
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            Processor.GraphLock.EnterReadLock();
            try
            {
                var samplesRequired = Math.Min(count / sizeof(float) / 2, Processor.Config.BufferSize);

                var bufferL = new float[samplesRequired];
                var bufferR = new float[samplesRequired];
                
                SoundInputL.Read(bufferL, offset, samplesRequired);
                SoundInputR.Read(bufferR, offset, samplesRequired);

                for (var i = 0; i < samplesRequired; i++)
                {
                    var bytesL = BitConverter.GetBytes(bufferL[i]);
                    for (var byteIndex = 0; byteIndex < sizeof(float); byteIndex++)
                    {
                        buffer[i * 2 * sizeof(float) + byteIndex] = bytesL[byteIndex];
                    }

                    var bytesR = BitConverter.GetBytes(bufferR[i]);
                    for (var byteIndex = 0; byteIndex < sizeof(float); byteIndex++)
                    {
                        buffer[(i * 2 + 1) * sizeof(float) + byteIndex] = bytesR[byteIndex];
                    }
                }

                return samplesRequired * sizeof(float) * 2;
            }
            finally
            {
                Processor.GraphLock.ExitReadLock();
            }
        }
    }

    internal class OutputModuleFactory : ModuleFactory
    {
        public override Module Create(Processor processor) => new OutputModule(processor);

        public override string Name => "Output";
    }
}