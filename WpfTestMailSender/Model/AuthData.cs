using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WpfTestMailSender.Model
{
    public class AuthData
    {
        public string _trueLog { get; set; }
        public string _truePass { get; set; }
        public string _trueSender { get; set; }

        public static AuthData GetDataAuth(string path, AuthData User)
        {
            Security cipher = new Security();
            StreamReader sr = new StreamReader(path);

            string[] s = sr.ReadLine().Split(';');
            User._trueLog = cipher.Encrypt(s[0], s[0].Length);
            User._truePass = cipher.Encrypt(s[0], s[0].Length);
            User._trueSender = s[2];
           
            sr.Close();

            return User;
        }
        public override string ToString()
        {
            return $"{_trueLog} + {_truePass} + {_trueSender}";
        }
    }
}
