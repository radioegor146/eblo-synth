using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EbloSynth.Modules;

namespace EbloSynth
{
    internal class Processor
    {
        public ProcessorConfig Config { get; } = new ProcessorConfig();

        public HashSet<Module> Modules { get; } = new HashSet<Module>();

        public List<ModuleFactory> Factories { get; } = new List<ModuleFactory>();

        public ReaderWriterLockSlim GraphLock { get; } = new ReaderWriterLockSlim();

        public MainForm MainForm { get; private set; }

        public void PerformLockedModuleOperation(Action action)
        {
            GraphLock.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                GraphLock.ExitWriteLock();
            }
        }

        public bool CanConnect(Output source, Input destination)
        {
            if (source.ConnectionType != destination.ConnectionType)
                return false;

            var outputs = new Queue<Output>();
            foreach (var output in destination.Module.Outputs)
                outputs.Enqueue(output);

            while (outputs.Any())
            {
                var output = outputs.Dequeue();

                if (output == source)
                    return false;

                if (output.ConnectedInput == null)
                    continue;

                foreach (var nextOutput in output.ConnectedInput.Module.Outputs)
                    outputs.Enqueue(nextOutput);
            }

            return true;
        }

        private void LoadFactories()
        {
            Factories.Add(new InputModuleFactory());
            Factories.Add(new OutputModuleFactory());
            Factories.Add(new LevelControlModuleFactory());
            Factories.Add(new SineSynthModuleFactory());
            Factories.Add(new KeyTriggerModuleFactory());
            Factories.Add(new SplitterModuleFactory<float>("Sound"));
            Factories.Add(new SplitterModuleFactory<double>("CV"));
        }

        public void Start()
        {
            LoadFactories();

            Application.Run(MainForm = new MainForm(this));

            foreach (var module in Modules.ToList())
                RemoveModule(module);
        }

        public void Connect(Output source, Input destination)
        {
            Console.WriteLine($@"{source} -> {destination}");
            PerformLockedModuleOperation(() => destination.Connect(source));
        }

        public void Disconnect(Output source, Input destination)
        {
            Console.WriteLine($@"{source} -/> {destination}");
            PerformLockedModuleOperation(destination.Disconnect);
        }

        public void AddModule(Module module) => PerformLockedModuleOperation(() => Modules.Add(module));

        public void RemoveModule(Module module) => PerformLockedModuleOperation(() =>
        {
            foreach (var input in module.Inputs)
                input.Disconnect();
            foreach (var output in module.Outputs)
                output.Disconnect();
            Modules.Remove(module);
            module.Dispose();
        });
    }
}