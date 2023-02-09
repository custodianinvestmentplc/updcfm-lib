using BCrypt.Net;

namespace Custodian.Properties.Estates.Helpers.Services
{
    public class Encryption
    {
        public static string EnhanceHashPasswordWithBcrypt(string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA512);

            return hashedPassword;
        }

        public static bool VerifyEnhancePasswordWithBcrypt(string hashedPassword, string password)
        {
            try
            {
                var verify = BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword, HashType.SHA512);

                return verify;

            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Password", ex);
            }

        }
    }
}
