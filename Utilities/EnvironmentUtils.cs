using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryxivia.Shared.Utilities
{
    public static class EnvironmentUtils
    {
        public static string GetAspNetCoreEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        }

        public static bool IsDevelopment()
        {
            return GetAspNetCoreEnvironment() == "Development";
        }

        public static bool IsEip1559TxnSupported()
        {
            bool.TryParse(Environment.GetEnvironmentVariable("EIP1559_TXN_SUPPORTED"), out bool isEip1559TxSupported);
            return isEip1559TxSupported;
        }
    }
}
