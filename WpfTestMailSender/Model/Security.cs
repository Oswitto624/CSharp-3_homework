using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTestMailSender.Model
{
    public class Security
    {
        const string engAlphNum = "AB1CD2EF3GH4IJ5KL6MN7OP8QR9ST0UVWXYZ";

        private string CodeEncode(string text, int k)
        {
            string fullAlfabet = engAlphNum + engAlphNum.ToLower();
            var letterQty = fullAlfabet.Length;
            string retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        public string Encrypt(string plainMessage, int key) => CodeEncode(plainMessage, key);
        public string Decrypt(string encryptedMessage, int key) => CodeEncode(encryptedMessage, -key);
    }
}
