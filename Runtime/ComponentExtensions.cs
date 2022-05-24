using System;
using UnityEngine;

namespace StrongExtensions
{
    public static class ComponentExtensions
    {
        public static T SetPositionAndRotation<T>(this T component, Transform point) where T : Component
        {
            component.transform.SetPositionAndRotation(point.position, point.rotation);
            return component;
        }
        public static T CopyComponent<T>(this T original, GameObject destination) where T : Component
        {
            Type type = original.GetType();
            
            Component copy = destination.AddComponent(type);
            
            var fields = type.GetFields();
            
            foreach (System.Reflection.FieldInfo field in fields) 
                field.SetValue(copy, field.GetValue(original));
            
            return copy as T;
        }       
    }
}
