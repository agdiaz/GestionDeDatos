using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using System.Security.Cryptography;
using System.Data.SqlTypes;

namespace FrbaBus.Common.Helpers
{
    public static class PasswordHelper
    {
        [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic=true, DataAccess=DataAccessKind.None)]
        public static byte[] GetSHA256Value(string plainText)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] textBytes = new ASCIIEncoding().GetBytes(plainText);
            byte[] hashValue = algorithm.ComputeHash(textBytes);
            return hashValue;
        }
    }
}
