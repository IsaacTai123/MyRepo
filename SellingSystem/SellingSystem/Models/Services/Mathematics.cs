using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellingSystem.Models.Services;
using SellingSystem.Models.DB;
using static SellingSystem.Models.DataModels.Selling_requestModel;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace SellingSystem.Models.Services
{
    public class Mathematics : IMathematics
    {
        private readonly IMemberServicers _memberServicers;
        //private static Dictionary<string, MemberLoginModel> logincache = new Dictionary<string, MemberLoginModel>();

        public Mathematics(IMemberServicers memberServicers)
        {
            _memberServicers = memberServicers;
        }

        //public void login(Member member)
        //{

        //    logincache.Add(member.name, new MemberLoginModel()
        //    {
        //        member = member,
        //        timestamp = 123456
        //    });
        //}

        //public bool check(Member member)
        //{
        //    MemberLoginModel model = new MemberLoginModel();
        //    logincache.TryGetValue(member.name, out model);
        //    if (model != null && ((12350 - model.timestamp) >= 30))
        //    {
        //        logincache.Remove(member.name);
        //        return false;
        //    }
        //    else
        //    {
        //        logincache.Remove(member.name);
        //        model.timestamp = 123500;
        //        logincache.Add(member.name, model);
        //        return true;
        //    }
        //}


        public List<KeyIV> GetKeyIV(string uniqueId)
        {
            DataAccess dataAccess = new DataAccess();
            List<KeyIV> result = dataAccess.GetKeyIV(uniqueId);
            return result;
        }

        // decryped and convert to array to see the type, o -> deduction, 1 -> deposit
        public string Transaction(string base64CipherText, string IV) // data get from the url
        {
            // decrypt the cipherText get the data
            string response_decrypt = Decrypt(base64CipherText, IV);
            TransactionData originalTransPlainText = JsonConvert.DeserializeObject<TransactionData>(response_decrypt);

            // check is the user have login
            bool response = _memberServicers.CheckLogin(originalTransPlainText.memberId);
            if (response == false) 
            {
                return "Please login first";
            }
            else
            {
                // check user timeout
                bool checkResult = _memberServicers.CheckTimeOut(originalTransPlainText.memberId);
                if (checkResult == false)
                {
                    // we have log the user out from Remove the data in dictionary
                    return "TIME OUT!! please login again..";
                }
                else
                {
                    if (originalTransPlainText.type == 0)
                    {
                        Deduction(originalTransPlainText.amount, originalTransPlainText.memberId);
                        return "Deduction is success";
                    }
                    else
                    {
                        Deposit(originalTransPlainText.amount, originalTransPlainText.memberId);
                        return "Deposit is success";
                    }
                }
            }
        }

        public void Deduction(int x, int memberId)
        {
            // get the wallet data from Dictionary
            DataAccess dataAccess = new DataAccess();
            MemberOnlineModel memberFromDic = _memberServicers.GetMemberFromDic(memberId);
            int memberMoney = memberFromDic.member.wallet;

            // calculate the changes of the money
            int newMemberMonery = memberMoney - x;
            // update the wallet of the dictionary
            memberFromDic.member.wallet = newMemberMonery;

            // update the money to DB
            dataAccess.UpdateWallet(newMemberMonery, memberId);
        }

        public void Deposit(int x, int memberId)
        {
            // get the wallet data from Dictionary
            DataAccess dataAccess = new DataAccess();
            MemberOnlineModel memberFromDic = _memberServicers.GetMemberFromDic(memberId);
            int memberMoney = memberFromDic.member.wallet;

            // calculate the changes of the money
            int newMemberMonery = memberMoney + x;
            // update the wallet of the dictionary
            memberFromDic.member.wallet = newMemberMonery;

            // update the money to DB
            dataAccess.UpdateWallet(newMemberMonery, memberId);
        }

        public byte[] HexToByteArray(string hexString)
        {
            if (0 != (hexString.Length % 2))
            {
                throw new ApplicationException("Hex string must be multiple of 2 in length");
            }

            int byteCount = hexString.Length / 2;
            byte[] byteValues = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                byteValues[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return byteValues;
        }

        public Aes CreateCipher()
        {
            Aes cipher = Aes.Create();

            cipher.Padding = PaddingMode.ISO10126;

            cipher.Key = HexToByteArray("892C8E496E1E33355E858B327BC238A939B7601E96159F9E9CAD0519BA5055CD");

            return cipher;
        }

        public string Encrypt(string text, string memberIV)
        {
            string PlainText = text;
            Aes cipher = CreateCipher();

            //string IV = Convert.ToBase64String(cipher.IV);
            cipher.IV = Convert.FromBase64String(memberIV); // we pass the member IV into the cipher.IV to make all the encrypt/decrypt IV the same for each member

            //create the encryptor, convert to bytes and encrypt
            ICryptoTransform cryptoTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(PlainText);
            byte[] cipherText = cryptoTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            //Convert to base64 for display
            string base64CipherText = Convert.ToBase64String(cipherText);
            return base64CipherText;
        }

        #region Decrypt
        public string Decrypt(string text, string memberIV)
        {
            string CipherText = text;
            Aes cipher = CreateCipher();

            cipher.IV = Convert.FromBase64String(memberIV);

            ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(CipherText);
            byte[] plainText = cryptoTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

            string OriginalPlainText = Encoding.UTF8.GetString(plainText);

            return OriginalPlainText;
        }
        #endregion
    }

    //public class MemberLoginModel
    //{
    //    public Member member { get; set; }
    //    public long timestamp { get; set; }
    //}
    //public class MemberModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Password { get; set; }

    //}


}
