using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,
            out byte[] passwordHash, out byte[] passwordSalt)//ona verdiğimiz passwordun hashini ve saltını oluşturacak 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password,
             byte[] passwordHash, byte[] passwordSalt)//sonradan sisteme girenin verdiği passwordün veri kaynağımızdaki hashle ilgili salta göre eşleşip eşleşmediğini karşılaştırıyor.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;

                    }

                }
            }
            return true;
        }
    }
}
