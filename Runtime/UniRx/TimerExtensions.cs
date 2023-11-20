using System;

namespace UniRx.StrongExtensions
{
	public static class TimerExtensions
	{
		public static IDisposable Timer(this TimeSpan span, Action action) =>
			Observable.Timer(span).Subscribe(action);
	}
}