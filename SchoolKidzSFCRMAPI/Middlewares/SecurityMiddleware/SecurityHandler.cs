using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace SchoolKidzSFCRMAPI.Middlewares.SecurityMiddleware
{
    public class SecurityHandler
    {
        private string payload = "TO_BE_ENCRYPTED";
        private string saltkey = "272288013512051428169238234207889462115";
/*        public string Encryptor()
        {

            salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: payload!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            ));
            return hashed;
        }*/

        public void Decryptor(string hash)
        {
            byte[] salt = new byte[saltkey.Length];
            for (int i = 0; i < saltkey.Length; i++)
                salt[i] = (byte)((byte)saltkey[i] - 48);

            string compare = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: payload!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            ));
            if (hash != compare)
            {
                throw new Exception("UnAuthorized");
            }
        }
    }
}
