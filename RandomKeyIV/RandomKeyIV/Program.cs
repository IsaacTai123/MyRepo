using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RandomKeyIV
{
    class Program
    {
        static void Main(string[] args)
        {

            ////使用ASCII字元集將位元組轉換為字元組(字串)
            //Encoding Enc = Encoding.ASCII;

            ////將字串轉換為16進位字串(Hex string)
            //byte[] bytes = Enc.GetBytes(password);
            //string hexValue = bytes.BinaryToHex();


            ////16進位轉成byte[]
            //byte[] byteValue = hexValue.HexToByteArray();

            ////測試使用Encoding.UTF8 能不能把我自己轉換的byte 換回正確的string
            //string passwordString = Encoding.UTF8.GetString(byteValue);
            //Console.WriteLine(passwordString);

            ////用Encoding ASCII 把字串轉成byte
            //byte[] EncValue = Enc.GetBytes(password);

            ////用Encoding UTF8 把字串轉成byte
            //byte[] utfValue = Encoding.UTF8.GetBytes(password);

            //bool compare = true;
            //for (int i = 0; i < EncValue.Length; i++)
            //{
            //    if (EncValue[i] != utfValue[i])
            //    {
            //        Console.WriteLine("They are not the same");
            //        compare = false;
            //        break;
            //    }
            //}

            //if (compare)
            //    //比對用Enc轉換的 跟 我自己手動轉換的是否一樣
            //    Console.WriteLine("Two of theme are the same");


            // 不論是用 ASCII OR UTF8 還是自己生成 結果都會是一樣
            //byte[] byteValue = Encoding.ASCII.GetBytes(password);
            //string str = Encoding.UTF8.GetString(byteValue);
            //Console.WriteLine(str);

            // -----------------------------------------------------------------------------------------------------------

            //// 使用 Rfc2898DeriveBytes 類別，產生指定長度的 Key 和 IV :
            //// 定義 password、salt
            //string password = "thisispassword";
            //byte[] salt = Encoding.UTF8.GetBytes("saltsaltsaltsaltsa"); //長度必須 "least eight bytes" 不然會得到 "Salt is not at least eight bytes" error
            ////byte[] salt = Encoding.UTF8.GetBytes("saltsalt");

            //// 依據 password、salt ，建立 rfc2898derivebytes 物件
            //Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password, salt);
            //byte[] bytekey = rfc2898.GetBytes(32);  //這個數值可由各演算法的 keysize 取得, 如果是要用aes 那麼他的key長度是 byte[32] 所以我們用getbytes(32)
            //byte[] byteiv = rfc2898.GetBytes(16);   //這個數值可由各演算法的 blocksize 取得, aes iv的長度是 byte[16] 所以用getbytes(16)


            //string key = Convert.ToBase64String(bytekey);
            //string iv = Convert.ToBase64String(byteiv);



            //Console.WriteLine($"{key} = {key.Length},\r\n {iv} = {iv.Length}");


            // -----------------------------------------------------------------------------------------------------------

            //// 建立一個演算法物件
            //AesCryptoServiceProvider myAlg = new AesCryptoServiceProvider();

            //// 定義 password、salt
            //string password = "ThisIspassword";
            //byte[] salt = Encoding.UTF8.GetBytes("saltsaltsaltsalt");

            //// 依據 password、salt ，建立 Rfc2898DeriveBytes 物件
            //Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt);
            //myAlg.Key = key.GetBytes(myAlg.KeySize / 8); // 除以8是因為 1byte = 8 bits, size的單位是bit
            //myAlg.IV = key.GetBytes(myAlg.BlockSize / 8);

            //string keys = Convert.ToBase64String(myAlg.Key);
            //string IV = Convert.ToBase64String(myAlg.IV);

            //Console.WriteLine($"{key} = {keys.Length},\r\n {IV} = {IV.Length}");



            // -----------------------------------------------------------------------------------------------------------

            //自做 Random string
            // create a random string with specific length
            int length = 32;
            string randomString = "abcdefghijklmnopqrstuvwxymz123456789";

            Random r = new Random();
            string rand = new string(randomString.ToCharArray().OrderBy(s => r.Next()).ToArray()); //可以去 RandomNumberDemo 看一下random的用法
            string newString = rand.Substring(0, length);

            //convert string to byte
            byte[] byteValue = Encoding.ASCII.GetBytes(newString);

            string key = Convert.ToBase64String(byteValue);
            Console.WriteLine(key);



            //char[] array = randomString.ToCharArray();
            //char[] orderArray = array.OrderBy(s => (r.Next(2) % 2 == 0)).ToArray();

            //string rand = new string(orderArray);
            //char[] c = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

        }

        //public static string shuffle(this string str)
        //{
        //    char[] charArray = str.ToCharArray();

        //    Random r = new Random();
        //    string rand = new string(str.ToCharArray().OrderBy(s => (r.Next(2) % 2 == 0)).ToArray());

        //}
    }
}
