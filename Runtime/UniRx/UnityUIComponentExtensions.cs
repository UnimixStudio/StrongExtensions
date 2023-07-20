// for uGUI(from 4.6)

#if !(UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)

using System;

using TMPro;

namespace UniRx
{
	public static class UnityUIComponentExtensions
	{
		public static IDisposable SubscribeToText(this IObservable<string> source, TextMeshProUGUI text) =>
			source.SubscribeWithState(text, SetText);

		public static IDisposable SubscribeToText<T>(this IObservable<T> source, TextMeshProUGUI text) =>
			source.SubscribeWithState(text, SetText);

		public static IDisposable SubscribeToText<T>
			(this IObservable<T> source, TextMeshProUGUI text, Func<T, string> selector) =>
			source.SubscribeWithState2(text, selector, SetText);

		/// <summary>Observe onEndEdit(Submit) event.</summary>
		public static IObservable<string> OnEndEditAsObservable(this TMP_InputField inputField) =>
			inputField.onEndEdit.AsObservable();

		/// <summary>Observe onValueChanged with current `text` value on subscribe.</summary>
		public static IObservable<string> OnValueChangedAsObservable(this TMP_InputField inputField) =>
			Observable.CreateWithState<string, TMP_InputField>(inputField, SubscribeWithFirstSend);

#if UNITY_5_3_OR_NEWER

		/// <summary>Observe onValueChanged with current `value` on subscribe.</summary>
		public static IObservable<int> OnValueChangedAsObservable(this TMP_Dropdown dropdown) =>
			Observable.CreateWithState<int, TMP_Dropdown>(dropdown, SubscribeWithFirstSend);

#endif

		private static IDisposable SubscribeWithFirstSend(TMP_Dropdown d, IObserver<int> observer)
		{
			observer.OnNext(d.value);
			return d.onValueChanged.AsObservable().Subscribe(observer);
		}

		private static IDisposable SubscribeWithFirstSend(TMP_InputField i, IObserver<string> observer)
		{
			observer.OnNext(i.text);
			return i.onValueChanged.AsObservable().Subscribe(observer);
		}

		private static void SetText(string x, TextMeshProUGUI t) =>
			t.text = x;

		private static void SetText<T, TResult>(T x, TextMeshProUGUI t, Func<T, TResult> s) =>
			t.text = s(x).ToString();

		private static void SetText<T>(T x, TextMeshProUGUI t) =>
			t.text = x.ToString();
	}
}

#endif
