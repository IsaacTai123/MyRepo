using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// https://www.youtube.com/watch?v=rLEJLuA3hd0

namespace Cryptography
{
    class Program
    {
        public string IV;
        public string CipherText;
        public string PlainText;
        public string OriginalPlainText;
        public string testIV = "7hweEcwhA+ZrLhcScx0Dzw==";

        static void Main(string[] args)
        {
            // using SHA512 string convert to byte array
            //string plaintext = "Here is some data to encrypt.";
            //SHA512 hashSvc = SHA512.Create();


            //byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
            //string hex = BitConverter.ToString(hash).Replace("-", "");

            //Console.WriteLine(hex);
            //Console.WriteLine(hex.Length);

            Person person = new Person()
            {
                memberId = 1,
                Type = 0,
                Amount = "1000"
            };

            // store the json Data to the file
            string jsonPerson = JsonConvert.SerializeObject(person, Formatting.None);
            //File.WriteAllText(@"student.json", jsonPerson);
            //Console.WriteLine(jsonPerson);

            //jsonPerson = string.Empty;
            //jsonPerson = File.ReadAllText(@"student.json");
            //Person resultPerson = JsonConvert.DeserializeObject<Person>(jsonPerson); // convert data back from json to object
            //Console.WriteLine(resultPerson.ToString());

            Program encryptOrDecrypt = new Program();
            //string response_encrypt = encryptOrDecrypt.OnPostEncryptAsync(jsonPerson);

            //// Do UrlEncode
            //string UrlEncode = System.Web.HttpUtility.UrlEncode(response_encrypt);

            //Console.WriteLine(response_encrypt);

            //string response_decrypt = encryptOrDecrypt.OnPostDecryptAsync(response_encrypt);
            //Console.WriteLine(response_decrypt);

            //Person OriginalPersonObject = JsonConvert.DeserializeObject<Person>(response_decrypt);
            //Console.WriteLine(OriginalPersonObject.Amount);


            //// test if the IV will be the same if the plaintext is different
            //string secondPlainText = "test the IV";
            //string secondEncrypt = encryptOrDecrypt.OnPostEncryptAsync(secondPlainText);
            //string secondDecrypt = encryptOrDecrypt.OnPostDecryptAsync(secondEncrypt);



            string encrypt = encryptOrDecrypt.Aes256Encrypt(jsonPerson);
            Console.WriteLine("encrypt String = " + encrypt);

            // Do UrlEncode 如果你貼在URL 上必須經過urlEncode
            string UrlEncode = System.Web.HttpUtility.UrlEncode(encrypt);

            string Decrypt = encryptOrDecrypt.Aes256Decrypt(encrypt);
            Console.WriteLine("Decrypt String = " + Decrypt);

        }

        private Aes CreateCipher()
        {
            //Symmetric Algorithms
            //the primary one that most people use is AES encryption
            Aes cipher = Aes.Create(); // Defaults - keysize 256, Mode CBC, Padding PKC27

            cipher.Padding = PaddingMode.ISO10126; // this padding mode will take the original string and going to break it into blocks that last block isn't going magically be the right size 128 bits
            //so the algorithm needs to pad out the rest of that block by using this paddingmode it's going to put random data at the rest of that block which again just helps with cryptography to be 
            //able to use more more random data when you're doing things 

            //cipher.Padding = PaddingMode.Zeros;
            //cipher.Mode = CipherMode.ECB;
            //PaddingMode.ISO10126

            //Create() makes new key each time, use a consistent key for encrypt/decrypt
            cipher.Key = Conversions.HexToByteArray("892C8E496E1E33355E858B327BC238A939B7601E96159F9E9CAD0519BA5055CD");

            return cipher;
        }

        public string OnPostEncryptAsync(string text)
        {
            PlainText = text;
            Aes cipher = CreateCipher();

            //Show the IV on page (will use for decrypt, normally send in clear along with ciphertext)
            IV = Convert.ToBase64String(cipher.IV);

            //sign the IV to cipher.IV, make the IV allways the same to decrypt all the info we encrypt
            //cipher.IV = Convert.FromBase64String(testIV);

            //我想要看一下 64位數的16進位 換成byte 再用convert.ToBase64 轉成字串後 是多長
            int keyLength = Convert.ToBase64String(cipher.Key).Length; //出來後長度為44

            //create the encryptor, convert to bytes, and encrypt
            ICryptoTransform cryptoTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(PlainText);
            byte[] cipherText = cryptoTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            //Convert to base64 for display
            string CipherText = Convert.ToBase64String(cipherText);
            return CipherText;
        }

        public string OnPostDecryptAsync(string text)
        {
            CipherText = text;
            Aes cipher = CreateCipher();

            //Read back in the IV used to randomize the first block
            cipher.IV = Convert.FromBase64String(testIV);

            //create the decryptor, convert from base64 to bytes, decrypt
            ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(CipherText);
            byte[] plainText = cryptoTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

            //Convert to base64 for display
            OriginalPlainText = Encoding.UTF8.GetString(plainText);

            return OriginalPlainText;
        }


        // using Rijndeal
        public string Aes256Encrypt(string plaintext)
        {
            RijndaelManaged aesEncrypt = new RijndaelManaged();

            aesEncrypt.BlockSize = 128;
            aesEncrypt.KeySize = 256;
            aesEncrypt.Mode = CipherMode.CBC;
            aesEncrypt.Padding = PaddingMode.PKCS7;

            aesEncrypt.Key = Convert.FromBase64String("Y2RlZmdoamtsbW5wcXN2eHkxMjM0OGFiaW9ydHV3bXo=");
            aesEncrypt.IV = Convert.FromBase64String(testIV);

            ICryptoTransform crypToTransforn = aesEncrypt.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(plaintext);
            byte[] cipherText = crypToTransforn.TransformFinalBlock(plainText, 0, plainText.Length);

            string encryptStr = Convert.ToBase64String(cipherText);
            return encryptStr;
        }

        public string Aes256Decrypt(string encryptStr)
        {
            RijndaelManaged aesDecrypt = new RijndaelManaged();

            aesDecrypt.BlockSize = 128;
            aesDecrypt.KeySize = 256;
            aesDecrypt.Mode = CipherMode.CBC;
            aesDecrypt.Padding = PaddingMode.PKCS7;

            aesDecrypt.Key = Convert.FromBase64String("Y2RlZmdoamtsbW5wcXN2eHkxMjM0OGFiaW9ydHV3bXo=");
            aesDecrypt.IV = Convert.FromBase64String(testIV);

            byte[] cipherText = Convert.FromBase64String(encryptStr);

            ICryptoTransform cryptoTransform = aesDecrypt.CreateDecryptor();
            byte[] plainText = cryptoTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);
            string PlainText = Encoding.UTF8.GetString(plainText); // 這邊要用Encoding.UTF8_GetString 把byte換回String(字串)

            return PlainText;
        }

    }
}
