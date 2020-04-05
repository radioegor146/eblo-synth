using System;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EbloSynth
{
    internal static class Program
    {
        private static void Main() => new Processor().Start();
    }
}
