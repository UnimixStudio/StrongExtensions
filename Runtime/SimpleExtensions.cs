using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StrongExtensions
{
    public static class SimpleExtensions
    {
        public static bool InRange(this float value, float min, float max) =>
            min <= value && value <= max;

        public static bool InRange(this int value, int min, int max) =>
            min <= value && value <= max;

        public static bool InRangeIndex<T>(this IEnumerable<T> collection, int index) =>
            index.InRange(0, collection.Count() - 1);

        public static float ToRad(this float value) =>
            Mathf.Deg2Rad * value;

        public static float ToDeg(this float value) =>
            Mathf.Rad2Deg * value;

        public static float Sqr(this float value) =>
            Mathf.Pow(value, 2);

        public static float Sqrt(this float value) =>
            Mathf.Sqrt(value);

        public static float Abs(this float value) =>
            Mathf.Abs(value);

        public static int Abs(this int value) =>
            Mathf.Abs(value);

        public static int CeilToInt(this float value) =>
            Mathf.CeilToInt(value);

        public static float Round(this float value) =>
            Mathf.Round(value);

        public static int RoundToInt(this float value) =>
            Mathf.RoundToInt(value);

        public static float Sign(this float value) =>
            Mathf.Sign(value);

        public static int Sign(this int value) =>
            (int) Mathf.Sign(value);

        public static float Pow(this float value, float power) =>
            Mathf.Pow(value, power);

        public static bool Approximately(this float value, float other) =>
            Mathf.Approximately(value, other);

        public static float Clamp01(this float value) =>
            Mathf.Clamp01(value);

        public static float Clamp(this float value, float min, float max) =>
            Mathf.Clamp(value, min, max);

        public static float Clamp(this int value, int min, int max) =>
            Mathf.Clamp(value, min, max);

        public static float LerpTo(this float fromValue, float to, float time) =>
            Mathf.Lerp(fromValue, to, time);

        public static float LerpAsTime(this float timeValue, float from, float to) =>
            Mathf.Lerp(from, to, timeValue.Clamp01());
    }
}