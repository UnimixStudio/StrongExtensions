using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StrongExtensions
{
    public static class UnityExtensions
    {
        public static Vector2 Pivot = Vector2.one * 0.5f;

        public static void ReNameWithID(this Object obj, string newName = "")
        {
            string name = newName.IsNullOrWhitespace() ? obj.name : newName;

            int instanceID = obj.GetInstanceID();
            obj.name = $"{name}{instanceID}";
        }

        public static void ValidateComponent<T>(this GameObject gameObject, T component) where T : Component
        {
            if (component == null)
                component = gameObject.GetComponent<T>();
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component =>
            gameObject.TryGetComponent(out T component) ? component : gameObject.AddComponent<T>();

        public static T GetOrAddComponent<T>(this Component component) where T : Component =>
            GetOrAddComponent<T>(component.gameObject);

        public static void DelayAction(this MonoBehaviour monoBehaviour, float timeDelay, Action action) =>
            monoBehaviour.StartCoroutine(DelayActionCoroutine(timeDelay, action));

        private static IEnumerator DelayActionCoroutine(float timeDelay, Action action)
        {
            yield return new WaitForSeconds(timeDelay);
            action?.Invoke();
        }

        public static void SetRect(this RectTransform rectTransform, float left = 0f, float top = 0f, float right = 0f,
            float bottom = 0f)
        {
            rectTransform.offsetMin = new Vector2(left, bottom);
            rectTransform.offsetMax = new Vector2(-right, -top);
        }

        public static void SetFullSizeOfParent(this RectTransform rectTransform,
            Vector2 anchoredPosition = new Vector2())
        {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.anchoredPosition = anchoredPosition;
        }

        public static void SetRect(this RectTransform rectTransform, float all) =>
            rectTransform.SetRect(all, all, all, all);

        public static void DoVirtualFloat(this MonoBehaviour monoBehaviour, float startValue, float endValue,
            float duration, Action<float> action, Action onComplete = null) =>
            monoBehaviour.StartCoroutine(DoVirtualFloatCoroutine(startValue, endValue, duration, action, onComplete));

        private static IEnumerator DoVirtualFloatCoroutine(float startValue, float endValue, float duration,
            Action<float> action, Action onComplete = null)
        {
            float time = 0;
            while (time <= duration)
            {
                time += Time.deltaTime / duration;
                float value = Mathf.Lerp(startValue, endValue, time);
                action(value);
                yield return null;
            }

            yield return null;

            action(endValue);
            yield return null;
            onComplete?.Invoke();
        }

        public static Transform FindNearWith(this IEnumerable<GameObject> points, Transform target) =>
            FindNearWith(points.Select(gameObject => gameObject.transform), target);

        public static Transform FindNearWith(this IEnumerable<Transform> points, Transform target) =>
            FindNearWith(points.ToList(), target);

        public static Transform FindNearWith(this List<Transform> points, Transform target)
        {
            return points.IsNullOrEmpty() ? null : points.OrderBy(SqrMagnitude).First();

            float SqrMagnitude(Transform transform) => (target.position - transform.position).sqrMagnitude;
        }

        public static T GetInterfaceType<T>(this Object obj) where T : class =>
            obj switch
            {
                T instance => instance,
                GameObject gameObject => gameObject.GetComponent<T>(),
                _ => null
            };

        public static T[] GetChildren<T>(this Component owner, bool includeInactive = false) =>
            GetChildren<T>(owner.gameObject, includeInactive);

        public static T[] GetChildren<T>(this GameObject owner, bool includeInactive = false) =>
            owner.GetComponentsInChildren<T>(includeInactive);

        public static Sprite ToSprite(this Texture2D texture2D) => Sprite.Create(texture2D, texture2D.Rect(), Pivot);

        public static Vector2 Size(this Texture texture) => new Vector2(texture.width, texture.height);

        public static Rect Rect(this Texture texture) => new Rect(Vector2.zero, texture.Size());
    }
}