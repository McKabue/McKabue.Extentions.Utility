using System;
using System.Collections.Generic;

namespace Common_C_Sharp_Utility_Methods
{
    public static class Linq
    {
        /// <summary>
        /// https://stackoverflow.com/a/489421/3563013
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}