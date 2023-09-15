using System.Collections.Generic;

using Cysharp.Threading.Tasks;

namespace StrongExtensions.UniTask
{
	using UniTask = Cysharp.Threading.Tasks.UniTask;

	public static class UniTaskExtensions
	{
		public static UniTask WhenAll(this IEnumerable<UniTask> tasks) =>
			UniTask.WhenAll(tasks);

		public static UniTask<T> ToUniTask<T>(this T value) =>
			UniTask.FromResult(value);

		public static async UniTask<T> ToUniTaskWithReturnValue<T>(this T returnValue, UniTask task)
		{
			await task;
			return returnValue;
		}
	}
}
