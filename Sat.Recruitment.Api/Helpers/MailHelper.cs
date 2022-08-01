using System;

namespace Sat.Recruitment.Api.Helpers
{
    public static class MailHelper
    {
        public static string Normalize (string mail)
        {            
            var aux = mail.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
            mail = string.Join("@", new string[] { aux[0], aux[1] });
            return mail;
        }
    }
}
