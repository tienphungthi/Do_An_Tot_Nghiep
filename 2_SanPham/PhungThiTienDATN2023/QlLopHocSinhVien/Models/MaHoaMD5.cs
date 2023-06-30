using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace QlLopHocSinhVien.Models
{
    public class MaHoaMD5
    {
        public static string EncryptPassword(string txtPassword)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword);
            string encryptPassword = Convert.ToBase64String(passBytes);
            return encryptPassword;
        }

        /// <summary>
        /// To Decrypt password
        /// </summary>
        /// <param name="encryptedPassword"></param>
        /// <returns>It returns plain password</returns>
        public static string DecryptPassword(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
            {
                return "";
            }
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }
    }
}
