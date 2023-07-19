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
        public static int IndexOf<T>(this IEnumerable<T> collection, T item) =>
            Array.IndexOf(collection.ToArray(), item);

        public static bool IsNullOrEmpty<T>(this ICollection<T> collection) =>
            collection == null || collection.Count == 0;
        
        public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable) => 
            enumerable.Any();

        public static bool IsNotNullOrEmpty<T>(this ICollection<T> collection) =>
            collection is { Count: > 0 };
    
        public static bool Exist<T>(this ICollection<T> collection, Func<T,bool> predicate) =>
            collection.Any(predicate);

        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                return default;

            T[] array = collection.ToArray();

            return array[Random.Range(0, array.Length)];
        }
    }
}