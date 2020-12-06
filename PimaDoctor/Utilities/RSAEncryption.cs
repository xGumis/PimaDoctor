﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

 namespace PimaDoctor.Utilities
{
    class RSAEncryption
    {
        public static string containerName = "containerName";

        public static string Encrypt(string data)
        {
            var dataAsBytes = Encoding.UTF8.GetBytes(data);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    rsa.FromXmlString(GetPublicKey());
                    var encryptedData = rsa.Encrypt(dataAsBytes, true);
                    var base64Encryption = Convert.ToBase64String(encryptedData);
                    return base64Encryption;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string Decrypt(string data)
        {
            var dataAsBytes = Encoding.UTF8.GetBytes(data);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    rsa.FromXmlString(GetPrivateKey());
                    var resultBytes = Convert.FromBase64String(data);
                    var decryptedData = rsa.Decrypt(dataAsBytes, true);
                    var decryptedEncodedData = Encoding.UTF8.GetString(decryptedData);
                    return decryptedEncodedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string GetKeyAsString(RSAParameters key)
        {
            var stringWriter = new StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, key);
            return stringWriter.ToString();
        }

        public static void addKeysToContainer()
        {
            var parameters = new CspParameters
            {
                KeyContainerName = containerName
            };

            var rsa = new RSACryptoServiceProvider(parameters);
        }

        public static string GetPublicKey()
        {
            var parameters = new CspParameters
            {
                KeyContainerName = containerName
            };

            var rsa = new RSACryptoServiceProvider(parameters);
            var publicKey = rsa.ExportParameters(true);
            string publicKeyAsString = GetKeyAsString(publicKey);
            return publicKeyAsString;
        }

        public static string GetPrivateKey()
        {
            var parameters = new CspParameters
            {
                KeyContainerName = containerName
            };

            var rsa = new RSACryptoServiceProvider(parameters);
            var privateKey = rsa.ExportParameters(true);
            string privateKeyAsString = GetKeyAsString(privateKey);
            return privateKeyAsString;
        }
    }
}