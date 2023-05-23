using System.Security.Cryptography;
using System.Text;

namespace MAP.AspNetCore.Security;

public static class SecurityEncryption
{
    /// <summary>
    /// Encrypt your string data
    /// you can Decrypt this method by SimpleDecrypt
    /// </summary>
    /// <param name="source">your string (password, username, ...)</param>
    /// <returns>Encrypted string</returns>
    public static string SimpleEncrypt(String source)
    {
        if (source == null) { throw new ArgumentNullException("data"); }
        String ret = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(source));
        return ret;
    }

    /// <summary>
    /// Decrypt Encrypted string by SimpleEncrypt method
    /// </summary>
    /// <param name="encrypt">Encrypted string</param>
    /// <returns>Decrypted string</returns>
    public static String SimpleDecrypt(String encrypt)
    {
        if (encrypt == null) { throw new ArgumentNullException("data"); }
        String ret = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(encrypt));
        return ret;
    }

    /// <summary>
    /// Encrypt your string source
    /// you can Decrypt this method by Decrypt3DES
    /// </summary>
    /// <param name="source">your string (password, username, ...)</param>
    /// <param name="key">Encryption key</param>
    /// <returns>Encrypted string</returns>
    /// <exception cref="ArgumentNullException">source string = null</exception>
    public static string Encrypt3DES(string source, string? key = null)
    {
        if (source == null || source == "") { throw new ArgumentNullException("source"); }
        if (key == null) { key = "L6j15"; }
        using (var tripleDESCryptoService = TripleDES.Create())
        {
            using (var hashMD5Provider = MD5.Create())
            {
                byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                tripleDESCryptoService.Key = byteHash;
                tripleDESCryptoService.Mode = CipherMode.ECB;
                byte[] data = Encoding.Unicode.GetBytes(source);
                return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
            }
        }
    }

    /// <summary>
    /// Decrypt Encrypted string by Encrypt3DES method
    /// </summary>
    /// <param name="encrypt">Encrypted string</param>
    /// <param name="key">Encryption key</param>
    /// <returns>Decrypted string</returns>
    /// <exception cref="ArgumentNullException">encrypted string = null</exception>
    public static string Decrypt3DES(string encrypt, string? key = null)
    {
        if (encrypt == null || encrypt == "") { throw new ArgumentNullException("encrypt"); }
        if (key == null) { key = "L6j15"; }
        using (var tripleDESCryptoService = TripleDES.Create())
        {
            using (var hashMD5Provider = MD5.Create())
            {
                byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                tripleDESCryptoService.Key = byteHash;
                tripleDESCryptoService.Mode = CipherMode.ECB;
                byte[] byteBuff = Convert.FromBase64String(encrypt);
                return Encoding.Unicode.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
        }
    }
}