using System.Security.Cryptography;
using System.Text;

namespace SpotMusic.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Criptografar(this string valor)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] texto = Encoding.UTF8.GetBytes(valor);

            var criptoResult = criptoProvider.ComputeHash(texto);

            return Convert.ToHexString(criptoResult);
        }
    }
}
