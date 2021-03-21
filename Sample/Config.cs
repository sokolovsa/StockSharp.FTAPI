using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FTAPI4NetSample
{
    class Config
    {
        public static ulong UserID = 123L; //牛牛号
        public static ulong TrdAcc = 123L; //业务账号，每个市场都有独立的业务账号，可以通过getAccList获取到。
        public static string UnlockTradePwdMd5 = CalcMD5("123456");  //解锁交易密码的md5
        public static string OpendIP = "127.0.0.1";
        public static ushort OpendPort = 11111;
        public static string RsaKeyFilePath = "";  //RSA私钥文件路径，用于加密和OpenD的连接。

        static string CalcMD5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] encryptionBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            string result = BitConverter.ToString(encryptionBytes).Replace("-", "").ToLower();
            return result;
        }
    }


}
