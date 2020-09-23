using System;
using System.Collections.Generic;
using System.Linq;

namespace McKabue.Extentions.Utility
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
        public static IEnumerable<TSource> Distinct<TSource, TKey>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
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

        /// <summary>
        /// https://stackoverflow.com/a/14160879
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static U Get<T, U>(this IDictionary<T, U> dict, T key, U fallback = default)
        {
            U val = fallback;
            dict.TryGetValue(key, out val);
            return val;
        }

        public static U Get<T, U>(
            this IEnumerable<KeyValuePair<T, U>> dict,
            Func<T, bool> comparer,
            U fallback = default)
        {
            KeyValuePair<T, U>? val = dict?.FirstOrDefault(i => comparer?.Invoke(i.Key) ?? false);
            return val.HasValue ? val.Value.Value : fallback;
        }

        public static U Get<T, U>(
            this IEnumerable<KeyValuePair<T, U>> dict,
            T key,
            U fallback = default)
        {
            KeyValuePair<T, U>? val = dict?.FirstOrDefault(i => i.Key.Equals(key));
            return val.HasValue ? val.Value.Value : fallback;
        }

        public static void Set<T, U>(this IDictionary<T, U> dict, T key, U val)
        {
            dict[key] = val;
        }

        /// <summary>
        /// https://stackoverflow.com/a/1177590/3563013
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static bool AddIfNone<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            return !(dict?.Keys?.Any(k => k.Equals(key)) ?? false) && (dict?.TryAdd(key, value) ?? false);
        }

        public static bool AddIfNone<T, K>(this List<T> items, T item, Func<T, K> keyComparer = null)
        {
            bool isInItems = keyComparer != null
                ? items.Any(k => keyComparer(k).Equals(keyComparer(item)))
                : items.Any(k => k.Equals(item));

            if (!isInItems)
            {
                items.Add(item);
            }
            return isInItems;
        }

        public static bool Contains<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            return items != null && items.FirstOrDefault(predicate) != null;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(
            this IEnumerable<T> items, Func<IEnumerable<T>, bool> predicate)
        {
            List<T> currentItems = new List<T>();
            foreach (T item in items)
            {
                currentItems.Add(item);

                if (predicate(currentItems))
                {
                    yield return currentItems;
                    // https://stackoverflow.com/a/22064378/3563013
                    currentItems.Clear();
                }
            }

            yield return currentItems;
        }
    }
}