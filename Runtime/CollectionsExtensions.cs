using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace StrongExtensions
{
    public static class CollectionsExtensions
    {
        public static int IndexOf<T>(this Array collection, T item) =>
            Array.IndexOf(collection, item);

        public static bool IsNullOrEmpty<T>(this ICollection<T> collection) =>
            collection == null || collection.Count == 0;

        public static bool IsNotNullOrEmpty<T>(this ICollection<T> collection) =>
            collection != null && collection.Count > 0;

        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                return default;

            T[] array = collection.ToArray();

            return array[Random.Range(0, array.Length)];
        }
    }
}