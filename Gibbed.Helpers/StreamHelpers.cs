using System;
using System.IO;

namespace Gibbed.Helpers
{
    public static partial class StreamHelpers
    {
        public static bool forceBigEndian { get; set; }

        internal static bool ShouldSwap(bool littleEndian)
        {
            if (littleEndian == true && BitConverter.IsLittleEndian == false)
            {
                return !forceBigEndian;
            }
            else if (littleEndian == false && BitConverter.IsLittleEndian == true)
            {
                return !forceBigEndian;
            }

            return forceBigEndian;
        }

        public static MemoryStream ReadToMemoryStream(this Stream stream, long size)
        {
            MemoryStream memory = new MemoryStream();

            long left = size;
            byte[] data = new byte[4096];
            while (left > 0)
            {
                int block = (int)(Math.Min(left, 4096));
                stream.Read(data, 0, block);
                memory.Write(data, 0, block);
                left -= block;
            }

            memory.Seek(0, SeekOrigin.Begin);
            return memory;
        }

        public static void WriteFromStream(this Stream stream, Stream input, long size)
        {
            long left = size;
            byte[] data = new byte[4096];
            while (left > 0)
            {
                int block = (int)(Math.Min(left, 4096));
                input.Read(data, 0, block);
                stream.Write(data, 0, block);
                left -= block;
            }
        }
    }
}
