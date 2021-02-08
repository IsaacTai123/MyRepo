using System;
using System.Collections.Generic;
using System.Text;

namespace RandomKeyIV
{
    public static class Conversion
    {
        public static byte[] HexToByteArray(this string hexString)
        {
            if ( (hexString.Length % 2) != 0)
            {
                throw new ApplicationException("Hex string must be multiple of 2 in length");
            }

            int byteCount = hexString.Length / 2;
            byte[] byteValue = new byte[byteCount];

            for (int i = 0; i < byteCount; i++)
            {
                //ToByte(string? value, int frombase) 所以16指的是你的來源字串是什麼進位的 然後一律都轉成 8 位元不帶正負號整數。
                byteValue[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return byteValue;
        }


        public static string BinaryToHex(this byte[] binary)
        {
            return BitConverter.ToString(binary).Replace("-", "");
        }

    }
}
