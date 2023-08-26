namespace StrongExtensions
{
	public static class FloatExtensions
	{
		public static bool InRange(this float value, float min, float max, bool includeBounds = true) =>
			includeBounds
				? min <= value && value <= max
				: min < value && value < max;

		public static bool Less(this float value, float other, bool include = true) =>
			include
				? value <= other
				: value < other;

		public static bool More(this float value, float other, bool include = true) =>
			include
				? value >= other
				: value > other;
		
		public static bool IsZero(this float value) => value == 0;
		public static bool IsNotZero(this float value) => value != 0;
		public static bool IsMoreZero(this float value) => value > 0;
		public static bool IsMoreOrEqualsZero(this float value) => value >= 0;
		
		public static bool IsNaN(this float value) => float.IsNaN(value);
		public static bool IsInfinity(this float value) => float.IsInfinity(value);
	}
}
