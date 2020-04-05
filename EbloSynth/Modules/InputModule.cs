using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace EbloSynth.Modules
{
    internal class InputModule : Module
    {
        public Output<float> SoundOutputL { get; }

        public Output<float> SoundOutputR { get; }

        private WasapiCapture currentCapture;

        public InputModule(Processor processor) : base(processor)
        {
            SoundOutputL = new Output<float>("Output L", this, processor.Config.BufferSize);
            SoundOutputR = new Output<float>("Output R", this, processor.Config.BufferSize);
        }

        public override string Name => "Input";

        public override List<Input> Inputs => new List<Input>();

        public override List<Output> Outputs => new List<Output>
        {
            SoundOutputL,
            SoundOutputR
        };

        protected override ModuleForm CreateModuleForm() => new InputModuleForm(this);

        public override void RequestProcessing(int samples)
        {
            if (currentCapture == null)
            {
                var emptySamples = new float[samples];
                
                SoundOutputL.Write(emptySamples, 0, emptySamples.Length);
                SoundOutputR.Write(emptySamples, 0, emptySamples.Length);
                return;
            }
            SpinWait.SpinUntil(() =>
                (!SoundOutputL.IsConnected || SoundOutputL.DataStream.Available >= samples) && 
                (!SoundOutputR.IsConnected || SoundOutputR.DataStream.Available >= samples));
        }

        public override void Dispose()
        {
            lock (this)
            {
                currentCapture?.StopRecording();
            }
        }

        public void DeviceChanged(MMDevice device)
        {
            lock (this)
            {
                currentCapture?.StopRecording();
                currentCapture = new WasapiCapture(device, true);
                currentCapture.DataAvailable += (s, e) =>
                {
                    var buffer = new WaveBuffer(e.Buffer);
                    var samplesL = new float[e.BytesRecorded / 8];
                    var samplesR = new float[e.BytesRecorded / 8];

                    for (var i = 0; i < e.BytesRecorded / 8; i++)
                    {
                        samplesL[i] = buffer.FloatBuffer[i * 2];
                        samplesR[i] = buffer.FloatBuffer[i * 2 + 1];
                    }
                        
                    SoundOutputL.Write(samplesL, 0, samplesL.Length);
                    SoundOutputR.Write(samplesR, 0, samplesR.Length);
                };
                currentCapture.StartRecording();
            }
        }
    }

    internal class InputModuleFactory : ModuleFactory
    {
        public override Module Create(Processor processor) => new InputModule(processor);

        public override string Name => "Input";
    }
}