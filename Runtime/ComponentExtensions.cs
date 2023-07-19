using System;
using System.Reflection;
using UnityEngine;

namespace StrongExtensions
{
    public static class ComponentExtensions
    {
        public static T SetPositionAndRotation<T>(this T component, Transform point) where T : Component =>
            component.With(x => x.transform.SetPositionAndRotation(point.position, point.rotation));

        public static T CopyComponent<T>(this T original, GameObject destination) where T : Component
        {
            Type type = original.GetType();

            Component copy = destination.AddComponent(type);

            FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo field in fields)
                field.SetValue(copy, field.GetValue(original));

            return copy as T;
        }

        public static void Activate<T>(this T component) where T : Component =>
            component.gameObject.Activate();

        public static void Deactivate<T>(this T component) where T : Component =>
            component.gameObject.Deactivate();
    }
}