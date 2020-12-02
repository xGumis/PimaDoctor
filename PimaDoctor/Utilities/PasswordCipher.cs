﻿using System.Text;

 namespace PimaDoctor.Utilities
{
    class PasswordCipher
    {
        // standard ROT47 converter
        private static char ConvertChar(char c)
        {
            return c > 32 && c < 127
                ? (char)(33 + ((c + 14) % 94))
                : c;
        }

        public static string ConvertPassword(string password)
        {
            StringBuilder encryptedPassword = new StringBuilder();

            for (int i = 0; i < password.Length; i++)
            {
                encryptedPassword.Append(ConvertChar(password[i]));
            }

            return encryptedPassword.ToString();
        }
    }
}
