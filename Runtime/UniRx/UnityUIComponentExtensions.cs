// for uGUI(from 4.6)

#if !(UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)

using System;

using TMPro;

namespace UniRx
{
	public static partial class UnityUIComponentExtensions
	{
		public static IDisposable SubscribeToText(this IObservable<string> source, TextMeshProUGUI text)
		{
			return source.SubscribeWithState(text, (x, t) => t.text = x);
		}

		public static IDisposable SubscribeToText<T>(this IObservable<T> source, TextMeshProUGUI text)
		{
			return source.SubscribeWithState(text, (x, t) => t.text = x.ToString());
		}

		public static IDisposable SubscribeToText<T>
			(this IObservable<T> source, TextMeshProUGUI text, Func<T, string> selector)
		{
			return source.SubscribeWithState2(text, selector, (x, t, s) => t.text = s(x));
		}

		/// <summary>Observe onEndEdit(Submit) event.</summary>
		public static IObservable<string> OnEndEditAsObservable(this TMP_InputField inputField)
		{
			return inputField.onEndEdit.AsObservable();
		}

		/// <summary>Observe onValueChanged with current `text` value on subscribe.</summary>
		public static IObservable<string> OnValueChangedAsObservable(this TMP_InputField inputField)
		{
			return Observable.CreateWithState<string, TMP_InputField>(
				inputField,
				(i, observer) =>
				{
					observer.OnNext(i.text);
					return i.onValueChanged.AsObservable().Subscribe(observer);
				});
		}

#if UNITY_5_3_OR_NEWER

		/// <summary>Observe onValueChanged with current `value` on subscribe.</summary>
		public static IObservable<int> OnValueChangedAsObservable(this TMP_Dropdown dropdown)
		{
			return Observable.CreateWithState<int, TMP_Dropdown>(
				dropdown,
				(d, observer) =>
				{
					observer.OnNext(d.value);
					return d.onValueChanged.AsObservable().Subscribe(observer);
				});
		}

#endif
	}
}

#endif
