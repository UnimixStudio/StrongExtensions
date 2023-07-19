using UnityEngine;

namespace StrongExtensions
{
    public static class DistanceExtensions
    {
        public static bool OutsideDistance(this GameObject gameObject, Transform target, float distance) =>
            OutsideDistance(gameObject.transform, target, distance);

        public static bool OutsideDistance(this GameObject gameObject, Component target, float distance) =>
            OutsideDistance(gameObject.transform, target.transform, distance);

        public static bool OutsideDistance(this GameObject gameObject, GameObject target, float distance) =>
            OutsideDistance(gameObject.transform, target.transform, distance);

        public static bool OutsideDistance(this Component component, GameObject target, float distance) =>
            OutsideDistance(component.transform, target.transform, distance);

        public static bool OutsideDistance(this Component component, Vector3 target, float distance) =>
            OutsideDistance(component.transform, target, distance);

        public static bool OutsideDistance(this Component component, Component target, float distance) =>
            OutsideDistance(component.transform, target.transform, distance);

        public static bool OutsideDistance(this Component component, Transform target, float distance) =>
            OutsideDistance(component.transform, target, distance);

        public static bool OutsideDistance(this Transform transform, GameObject target, float distance) =>
            OutsideDistance(transform, target.transform, distance);

        public static bool OutsideDistance(this Transform transform, Component target, float distance) =>
            OutsideDistance(transform, target.transform, distance);

        public static bool OutsideDistance(this Transform transform, Transform target, float distance) =>
            OutsideDistance(transform, target.position, distance);

        public static bool OutsideDistance(this Transform transform, Vector3 target, float distance) =>
            (target - transform.position).sqrMagnitude > distance * distance;

        public static bool InsideDistance(this GameObject gameObject, Transform target, float distance) =>
            InsideDistance(gameObject.transform, target, distance);

        public static bool InsideDistance(this GameObject gameObject, Component target, float distance) =>
            InsideDistance(gameObject.transform, target.transform, distance);

        public static bool InsideDistance(this GameObject gameObject, GameObject target, float distance) =>
            InsideDistance(gameObject.transform, target.transform, distance);

        public static bool InsideDistance(this Component component, GameObject target, float distance) =>
            InsideDistance(component.transform, target.transform, distance);

        public static bool InsideDistance(this Component component, Component target, float distance) =>
            InsideDistance(component.transform, target.transform, distance);

        public static bool InsideDistance(this Component component, Transform target, float distance) =>
            InsideDistance(component.transform, target, distance);
        public static bool InsideDistance(this Component component, Vector3 target, float distance) =>
            InsideDistance(component.transform, target, distance);

        public static bool InsideDistance(this Transform transform, GameObject target, float distance) =>
            InsideDistance(transform, target.transform, distance);

        public static bool InsideDistance(this Transform transform, Component target, float distance) =>
            InsideDistance(transform, target.transform, distance);

        public static bool InsideDistance(this Transform transform, Transform target, float distance) =>
            (target.position - transform.position).sqrMagnitude <= distance * distance;

        public static bool InsideDistance(this Transform transform, Vector3 target, float distance) =>
            (target - transform.position).sqrMagnitude <= distance * distance;

        public static bool InsideDistance(this Vector3 transform, Vector3 target, float distance) =>
            (target - transform).sqrMagnitude <= distance * distance;

        public static float DistanceTo(this GameObject gameObject, Transform target) =>
            DistanceTo(gameObject.transform, target);

        public static float DistanceTo(this GameObject gameObject, Component target) =>
            DistanceTo(gameObject.transform, target.transform);

        public static float DistanceTo(this GameObject gameObject, GameObject target) =>
            DistanceTo(gameObject.transform, target.transform);

        public static float DistanceTo(this Component component, GameObject target) =>
            DistanceTo(component.transform, target.transform);

        public static float DistanceTo(this Component component, Component target) =>
            DistanceTo(component.transform, target.transform);

        public static float DistanceTo(this Component component, Transform target) =>
            DistanceTo(component.transform, target);

        public static float DistanceTo(this Transform transform, Component target) =>
            DistanceTo(transform, target.transform);

        public static float DistanceTo(this Transform transform, GameObject target) =>
            DistanceTo(transform, target.transform);

        public static float DistanceTo(this Transform transform, Transform target) =>
            Vector3.Distance(transform.position, target.position);
    }
}