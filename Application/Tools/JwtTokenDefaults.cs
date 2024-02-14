using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAuidience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "aafeeba6959ebeeb96519d5dcf0bcc069f81e4bb56c246d04872db92666e6d4b";
        public const int Expire = 3;
    }
}
