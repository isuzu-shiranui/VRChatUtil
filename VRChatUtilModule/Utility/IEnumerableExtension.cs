using System;
using System.Collections.Generic;
using System.Linq;

namespace VRChatUtilModule.Utility
{
    public static class EnumerableExtension
    {
        private sealed class CommonSelector<T, TKey> : IEqualityComparer<T>
        {
            private readonly Func<T, TKey> selector;

            public CommonSelector(Func<T, TKey> selector) => this.selector = selector;

            public bool Equals(T x, T y)
            {
                return this.selector(x).Equals(this.selector(y));
            }

            public int GetHashCode(T obj)
            {
                return this.selector(obj).GetHashCode();
            }
        }

        public static IEnumerable<T> Distinct<T, TKey>(
            this IEnumerable<T> source,
            Func<T, TKey> selector
        )
        {
            return source.Distinct(new CommonSelector<T, TKey>(selector));
        }

        public static IEnumerable<T> ToLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            var target = source.Where(predicate);
            var a = source.Except(target);
            return a.Concat(target);
        }
    }
}