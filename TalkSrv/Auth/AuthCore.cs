using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TalkSrv.Auth
{
    class AuthCore
    {
        private string userName;
        public string GetUserName()
        {
            return userName;
        }

        private string userPass; /* SHA256 + Base64 哈希后的密码 */
        public string SHA256PassEncrypt(string srcPass) /* 哈希方法 */
        {
            byte[] bytesSrcPass = Encoding.Default.GetBytes(srcPass);
            SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
            byte[] encryptBytesSrcPass = SHA256.ComputeHash(bytesSrcPass);
            return Convert.ToBase64String(encryptBytesSrcPass);
        }
        public string GetUserPass()
        {
            return userPass;
        }

        private PermissionCore userPermission; /* 用户权限 */
    }
}
