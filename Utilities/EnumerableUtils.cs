﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kryxivia.Shared.Utilities
{
    public static class EnumerableUtils
    {
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector)
        {
            return enumerable.GroupBy(keySelector).Select(grp => grp.First());
        }
    }
}
