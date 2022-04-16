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
    }
}