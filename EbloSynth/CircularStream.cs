using System;
using System.Diagnostics;

namespace EbloSynth
{
    internal class CircularStream<T>
    {
        private readonly T[] buffer;
        private readonly object lockObject = new object();
        private int writePosition;
        private int readPosition;
        private int byteCount;

        public CircularStream(int bufferSize)
        {
            buffer = new T[bufferSize];
        }

        public int Write(T[] data, int offset, int count)
        {
            lock (lockObject)
            {
                var bytesWritten = 0;
                if (count > buffer.Length - byteCount) 
                    count = buffer.Length - byteCount;

                var writeToEnd = Math.Min(buffer.Length - writePosition, count);
                Array.Copy(data, offset, buffer, writePosition, writeToEnd);
                writePosition += writeToEnd;
                writePosition %= buffer.Length;
                bytesWritten += writeToEnd;
                if (bytesWritten < count)
                {
                    Debug.Assert(writePosition == 0);
                    Array.Copy(data, offset + bytesWritten, buffer, writePosition, count - bytesWritten);
                    writePosition += (count - bytesWritten);
                    bytesWritten = count;
                }
                byteCount += bytesWritten;
                return bytesWritten;
            }
        }

        public int Read(T[] data, int offset, int count)
        {
            lock (lockObject)
            {
                if (count > byteCount) 
                    count = byteCount;

                var readToEnd = Math.Min(buffer.Length - readPosition, count);
                Array.Copy(buffer, readPosition, data, offset, readToEnd);
                var bytesRead = readToEnd;
                readPosition += readToEnd;
                readPosition %= buffer.Length;

                if (bytesRead < count)
                {
                    Debug.Assert(readPosition == 0);
                    Array.Copy(buffer, readPosition, data, offset + bytesRead, count - bytesRead);
                    readPosition += count - bytesRead;
                    bytesRead = count;
                }

                byteCount -= bytesRead;
                Debug.Assert(byteCount >= 0);
                return bytesRead;
            }
        }

        public int MaxLength => buffer.Length;

        public int Available
        {
            get
            {
                lock (lockObject)
                {
                    return byteCount;
                }
            }
        }

        public void Reset()
        {
            lock (lockObject)
            {
                ResetInner();
            }
        }

        private void ResetInner()
        {
            byteCount = 0;
            readPosition = 0;
            writePosition = 0;
        }
    }
}
