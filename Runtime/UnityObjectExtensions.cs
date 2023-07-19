using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StrongExtensions
{
    public static class UnityObjectExtensions
    {
        public static TObject Instantiate<TObject>(this TObject value) where TObject : Object =>
            Object.Instantiate(value);

        public static TObject Instantiate<TObject>(this TObject value, Transform parent) where TObject : Object =>
            Object.Instantiate(value, parent);

        public static TObject Instantiate<TObject>(this TObject value, Transform parent, bool worldPositionStays)
            where TObject : Object =>
            Object.Instantiate(value, parent, worldPositionStays);

        public static TObject Instantiate<TObject>(this TObject value, Vector3 position, Quaternion rotation)
            where TObject : Object =>
            Object.Instantiate(value, position, rotation);

        public static TObject Instantiate<TObject>(this TObject value, Vector3 position, Quaternion rotation,
            Transform parent) where TObject : Object =>
            Object.Instantiate(value, position, rotation, parent);
        public static TObject Instantiate<TObject>(this TObject value, Vector3 position, 
            Transform parent) where TObject : Object =>
            Object.Instantiate(value, position, Quaternion.identity, parent);
        public static TObject Instantiate<TObject>(this TObject value, Vector3 position) 
            where TObject : Object =>
            Object.Instantiate(value, position, Quaternion.identity);

        public static void Destroy(this Object value) => Object.Destroy(value);
        public static void Destroy(this Object value, float delay) => Object.Destroy(value, delay);

        public static void Destroy(this Object value, Action onComplete)
        {
            Object.Destroy(value);
            onComplete?.Invoke();
        }

        public static void DestroyImmediate(this Object value) => Object.DestroyImmediate(value);

        public static void DontDestroyOnLoad(this Object value) => Object.DontDestroyOnLoad(value);
    }
}