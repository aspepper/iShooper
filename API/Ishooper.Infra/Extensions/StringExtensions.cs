using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ishooper.Infra.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Criptografa uma string e retorna um array de bytes
        /// </summary>
        /// <param name="text">String a ser criptografada</param>
        /// <param name="keyString">Chave de criptografia</param>
        /// <returns></returns>
        public static byte[] EncryptStringEAS(this string text, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, key))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Descriptografa um array de bytes e retorna uma string 
        /// </summary>
        /// <param name="cipher">Array de bytes a ser descriptografado</param>
        /// <param name="keyString">Chave de criptografia</param>
        /// <returns></returns>
        public static string DecryptStringAES(this byte[] cipher, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);
            var iv = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        public static byte[] UTF8ToByte(this string thisString) => Encoding.UTF8.GetBytes(thisString);

        public static string ByteToUTF8(this byte[] thisByte) => Encoding.UTF8.GetString(thisByte);

        public static string Hex2Bin(this byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        public static byte[] Hex2Bin(this string hexdata)
        {
            if (hexdata == null)
                throw new ArgumentNullException(nameof(hexdata));
            if (hexdata.Length % 2 != 0)
                throw new ArgumentException("hexdata should have even length");

            byte[] bytes = new byte[hexdata.Length / 2];
            for (int i = 0; i < hexdata.Length; i += 2)
                bytes[i / 2] = (byte)(HexValue(hexdata[i]) * 0x10
                + HexValue(hexdata[i + 1]));
            return bytes;
        }

        private static int HexValue(char c)
        {
            int ch = (int)c;
            if (ch >= (int)'0' && ch <= (int)'9')
                return ch - (int)'0';
            if (ch >= (int)'a' && ch <= (int)'f')
                return ch - (int)'a' + 10;
            if (ch >= (int)'A' && ch <= (int)'F')
                return ch - (int)'A' + 10;
            throw new ArgumentException("Not a hexadecimal digit.");
        }

    }
}
