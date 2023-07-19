using UnityEngine;

namespace StrongExtensions
{
    public static class BehaviourExtensions
    {
        public static void Enable(this Behaviour component) => 
            component.enabled = true;

        public static void Disable(this Behaviour component) => 
            component.enabled = false;

        public static T Enable<T>(this Behaviour component) 
            where T : Behaviour
            =>  
                component
                    .GetComponent<T>()
                    .With(Enable);

        public static T Disable<T>(this Behaviour component) 
            where T : Behaviour
            =>  
                component
                    .GetComponent<T>()
                    .With(Disable);
    }
}