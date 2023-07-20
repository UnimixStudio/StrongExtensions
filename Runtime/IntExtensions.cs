namespace StrongExtensions
{
	public static class IntExtensions
	{
		public static bool InRange(this int value, int min, int max, bool includeBounds = true) =>
			includeBounds
				? min <= value && value <= max
				: min < value && value < max;

		public static bool Less(this int value, int other, bool include = true) =>
			include
				? value <= other
				: value < other;

		public static bool More(this int value, int other, bool include = true) =>
			include
				? value >= other
				: value > other;
		
		public static bool IsZero(this int value) => value == 0;
		public static bool IsNotZero(this int value) => value != 0;
		public static bool IsMoreZero(this int value) => value > 0;
		public static bool IsMoreOrEqualsZero(this int value) => value >= 0;
	}
}
