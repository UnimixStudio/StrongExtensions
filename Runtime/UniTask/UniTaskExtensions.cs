
using System.Collections.Generic;

namespace StrongExtensions.UniTask
{
	using UniTask = Cysharp.Threading.Tasks.UniTask;
	
	public static class UniTaskExtensions
	{
		public static  UniTask WhenAll(this IEnumerable<UniTask> tasks) =>
			UniTask.WhenAll(tasks);
	}
}
