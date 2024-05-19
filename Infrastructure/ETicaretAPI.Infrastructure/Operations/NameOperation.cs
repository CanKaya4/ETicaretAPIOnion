using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Operations
{
    public static class NameOperation
    {
        public static string CharecterRegulatory(string name)
        {
            return name.Replace("/", "")
                   .Replace("!", "")
                   .Replace("'", "")
                   .Replace("+", "")
                   .Replace("%", "")
                   .Replace("&", "")
                   .Replace("/", "")
                   .Replace("(", "")
                   .Replace(")", "")
                   .Replace("=", "")
                   .Replace("?", "")
                   .Replace("_", "")
                   .Replace("-", "")
                   .Replace("@", "")
                   .Replace(":", "")
                   .Replace(";", "")
                   .Replace(".", "-")
                   .Replace(",", "")
                   .Replace("Ö", "o")
                   .Replace("ö", "o")
                   .Replace("Ü", "u")
                   .Replace("ü", "u")
                   .Replace("ı", "i")
                   .Replace("ğ", "g")
                   .Replace("Ğ", "g")
                   .Replace("İ", "i")
                   .Replace("î", "i")
                   .Replace("â", "a")
                   .Replace("Ş", "s")
                   .Replace("ş", "s")
                   .Replace("Ç", "c")
                   .Replace("ç", "c")
                   .Replace("<", "")
                   .Replace(">", "")
                   .Replace("£", "");

        }
    }
}
