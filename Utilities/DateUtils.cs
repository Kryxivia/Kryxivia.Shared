using System;
using System.Collections.Generic;
using System.Text;

namespace Kryxivia.Shared.Utilities
{
    public static class DateUtils
    {
        public static long TimestampNow()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }
    }
}
