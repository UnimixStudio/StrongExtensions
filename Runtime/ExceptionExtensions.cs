using System;

namespace StrongExtensions
{
	public static class ExceptionExtensions
	{
		public static void Try<T>(this T item, Action action, Exception defaultException = null)
		{
			try
			{
				action();
			}
			catch (Exception)
			{
				if (defaultException != null)
					throw defaultException;

				throw;
			}
		}

		public static TResult Try<T, TResult>(this T item, Func<TResult> func, Exception defaultException = null)
		{
			try
			{
				return func();
			}
			catch (Exception)
			{
				if (defaultException != null)
					throw defaultException;

				throw;
			}
		}
		public static TResult Try<T, TResult>(this T item, Func<T,TResult> func, Exception defaultException = null)
		{
			try
			{
				return func(item);
			}
			catch (Exception)
			{
				if (defaultException != null)
					throw defaultException;

				throw;
			}
		}
		public static TResult Try<T, TResult>(this T item, Func<TResult> func, out bool canExecute,Exception defaultException = null)
		{
			canExecute = true;
			try
			{
				return func();
			}
			catch (Exception)
			{
				canExecute = false;
				
				if (defaultException != null)
					throw defaultException;

				throw;
			}
		}
	}
}
