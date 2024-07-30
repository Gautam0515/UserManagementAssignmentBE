using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shared.Encryption
{
    public class Decryptor
    {
        public string Decrypt(string data, string privateKey, string publicKey)
        {
            string result;
            byte[] privateKeyBytes = { };
            privateKeyBytes = Encoding.UTF8.GetBytes(privateKey);
            byte[] publicKeyBytes = { };
            publicKeyBytes = Encoding.UTF8.GetBytes(publicKey);
            byte[] inputByteArray = new byte[data.Replace(" ", "+").Length];
            inputByteArray = Convert.FromBase64String(data.Replace(" ", "+"));
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream,
                provider.CreateDecryptor(publicKeyBytes, privateKeyBytes),
                CryptoStreamMode.Write);
                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();
                result = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return result;
        }
    }
}
