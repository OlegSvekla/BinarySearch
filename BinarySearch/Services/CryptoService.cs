using EpsiVal.BusinessLogic.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EpsiVal.BusinessLogic.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly Aes aes;

        public CryptoService()
        {
            aes = Aes.Create();
        }

        public string Encrypt(string plainText)
        {
            using (var encryptor = aes.CreateEncryptor())
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                return Convert.ToBase64String(cipherBytes);
            }
        }

        public string Decrypt(string cipherText)
        {
            using (var decryptor = aes.CreateDecryptor())
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                return Encoding.UTF8.GetString(plainBytes);
            }
        }
    }
}