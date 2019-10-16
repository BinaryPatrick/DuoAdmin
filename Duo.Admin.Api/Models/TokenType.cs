using System.Collections.Generic;

namespace Unf.Core.Duo.Models
{
    public class TokenType
    {
        public static TokenType HOPT_6 => TokenTypeLookup["h6"];
        public static TokenType HOTP_8 => TokenTypeLookup["h8"];
        public static TokenType YubiKey => TokenTypeLookup["yk"];
        public static TokenType Duo_D100 => TokenTypeLookup["d1"];

        public string Name { get; internal set; }
        public string Type { get; internal set; }
        public string Description { get; internal set; }

        public override string ToString() => Type;

        private static readonly Dictionary<string, TokenType> TokenTypeLookup = new Dictionary<string, TokenType>
        {
            {"h6" ,  new TokenType { Name = "HOPT-6", Type = "h6", Description = "HOTP-6 hardware token" } },
            {"h8" ,  new TokenType { Name = "HOPT-8", Type = "h8", Description = "HOTP-8 hardware token" } },
            {"yk" ,  new TokenType { Name = "YubiKey", Type = "yk", Description = "YubiKey AES hardware token" } },
            {"d1" ,  new TokenType { Name = "Duo-D100", Type = "d1", Description = "Duo-D100 hardware token" } },
        };
    }
}
