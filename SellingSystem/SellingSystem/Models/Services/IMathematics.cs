using SellingSystem.Models.DataModels;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SellingSystem.Models.Services
{
    public interface IMathematics
    {
        Aes CreateCipher();
        string Decrypt(string text, string memberIV);
        void Deduction(int x, int memberId);
        void Deposit(int x, int memberId);
        string Encrypt(string text, string memberIV);
        List<Selling_requestModel.KeyIV> GetKeyIV(string uniqueId);
        byte[] HexToByteArray(string hexString);
        string Transaction(string base64CipherText, string IV);
    }
}