using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.ByteArrayHex
{
    public class FromByteConversion
    {
        public FromByteConversion() { }
        public byte[] StringToByteArray(string hex)
        {
            var NumberOfChar = hex.Length;
            byte[] bytes = new byte[NumberOfChar / 2];
            for (int i = 0; i < NumberOfChar; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
