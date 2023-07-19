using UnityEngine;

namespace StrongExtensions
{
    public interface IDebugColorDecorator
    {
        string DecorateName(string name);
        string DecorateValue(object value);
    }

    public abstract class DebugColorDecorator<T> : IDebugColorDecorator
    {
        public virtual string DecorateName(string name) =>
            name.ToHexColor("87d1f5");

        protected virtual string DecorateValue(T value) =>
            value.ToString().ToHexColor("aabe73");

        public string DecorateValue(object value) =>
            DecorateValue((T) value);
    }
    public class BoolDebugColorDecorator : DebugColorDecorator<bool>
    {
        protected override string DecorateValue(bool value) =>
            value
                ? "True".Green()
                : "False".Red();
    }

    public class IntDebugColorDecorator : DebugColorDecorator<int> { }

    public class FloatDebugColorDecorator : DebugColorDecorator<float> { }

    public class DoubleDebugColorDecorator : DebugColorDecorator<double> { }

    public class LongDebugColorDecorator : DebugColorDecorator<long> { }

    public class StringDebugColorDecorator : DebugColorDecorator<string>
    {
        protected override string DecorateValue(string value) =>
            value.ToHexColor("cd9069");
    }

    public class ColorDebugColorDecorator : DebugColorDecorator<Color>
    {
        protected override string DecorateValue(Color value) =>
            ColorUtility.ToHtmlStringRGBA(value).ToColor(value);
    }
    
    public class Vector3DebugColorDecorator : DebugColorDecorator<Vector3>
    {
        protected override string DecorateValue(Vector3 value) =>
            value.ToString().ToColor(Color.green);
    }
    public class Vector2DebugColorDecorator : DebugColorDecorator<Vector2>
    {
        protected override string DecorateValue(Vector2 value) =>
            value.ToString().ToColor(Color.blue);
    }
}