using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography
{
    /// <summary>
    /// Summary description for conversions
    /// </summary>
    public static class Conversions
    {
        public static byte[] HexToByteArray(string hexString)
        {
            if (0 != (hexString.Length % 2))
            {
                throw new ApplicationException("Hex string must be multiple of 2 in length");
            }

            // 16進位數字組成的字串轉換為Byte[]
            int byteCount = hexString.Length / 2;
            byte[] byteValues = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                //每2位16進位數字轉換為一個10進位整數
                byteValues[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return byteValues;
        }

        // Byte[]轉換為16進位數字字串
        public static string ByteArrayToHex(byte[] data)
        {
            //This converts the 64 byte hash into the string hex representation of byte values 
            // (shown by default as 2 hex characters per byte) that looks like 
            // "FB-2F-85-C8-85-67-F3-C8-CE-9B-79-9C-7C-54-64-2D-0C-7B-41-F6...", each pair represents
            // the byte value of 0-255.  Removing the "-" separator creates a 128 character string 
            // representation in hex
            return BitConverter.ToString(data).Replace("-", "");
        }
    }
}
