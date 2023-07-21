using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StrongExtensions
{
    using System.Collections.Generic;

    public static class GameObjectExtensions    
    {
        public static void Activate(this GameObject gameObject)
        {
            if (gameObject.activeSelf)
                return;
            gameObject.SetActive(true);
        }

        public static void Deactivate(this GameObject gameObject)
        {
            if (!gameObject.activeSelf)
                return;
            gameObject.SetActive(false);
        }

        public static void SetActive(this IEnumerable<GameObject> gameObjects, bool value)
        {
            foreach(GameObject gameObject in gameObjects)
                gameObject.SetActive(value);
        }

        [Obsolete("Use RemoveComponentsInChildren")]
        public static void RemoveComponents<TComponent>(this GameObject gameObject)
            where TComponent : Component
        {
            gameObject.RemoveComponentsInChildren<TComponent>();
        }
        
        public static void RemoveComponentsInChildren<TComponent>(this GameObject gameObject)
            where TComponent : Component
        {
            foreach(TComponent component in gameObject.GetComponentsInChildren<TComponent>())
                Object.Destroy(component);
        }

        public static TComponent TryGetOrAddComponent<TComponent>(this GameObject gameObject)
            where TComponent : Component
        {
            var component = gameObject.GetComponent<TComponent>();

            if (component == null)
                component = gameObject.AddComponent<TComponent>();

            return component;
        }
    }
}