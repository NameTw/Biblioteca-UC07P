
using System;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Models
{
    public class Criptografia
    {
        public static string HashPassword(string input)
        {
            StringBuilder strBuilder = new StringBuilder();

            byte[] textBytes = Encoding.ASCII.GetBytes(input);
            using (MD5 md5 = MD5.Create())
            {
                byte[] computerHash = md5.ComputeHash(textBytes);
                for (int i = 0; i < computerHash.Length; i++)
                {
                    strBuilder.Append(computerHash[i].ToString("x2"));  
                }
                return strBuilder.ToString();
            }
        }
    }
}