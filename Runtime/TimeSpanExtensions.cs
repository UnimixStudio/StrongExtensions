using System;

namespace StrongExtensions
{
	public static class TimeSpanExtensions
	{
		public static TimeSpan ToSeconds(this int seconds) =>
			TimeSpan.FromSeconds(seconds);

		public static TimeSpan ToSeconds(this float seconds) =>
			TimeSpan.FromSeconds(seconds);

		public static TimeSpan ToSeconds(this double seconds) =>
			TimeSpan.FromSeconds(seconds);

		public static TimeSpan ToMinutes(this int minutes) =>
			TimeSpan.FromMinutes(minutes);

		public static TimeSpan ToMinutes(this float minutes) =>
			TimeSpan.FromMinutes(minutes);

		public static TimeSpan ToMinutes(this double minutes) =>
			TimeSpan.FromMinutes(minutes);

		public static TimeSpan ToHours(this int hours) =>
			TimeSpan.FromHours(hours);

		public static TimeSpan ToHours(this float hours) =>
			TimeSpan.FromHours(hours);

		public static TimeSpan ToHours(this double hours) =>
			TimeSpan.FromHours(hours);

		public static TimeSpan ToDays(this int days) =>
			TimeSpan.FromDays(days);

		public static TimeSpan ToDays(this float days) =>
			TimeSpan.FromDays(days);

		public static TimeSpan ToDays(this double days) =>
			TimeSpan.FromDays(days);

		public static TimeSpan ToMilliseconds(this int milliseconds) =>
			TimeSpan.FromMilliseconds(milliseconds);

		public static TimeSpan ToMilliseconds(this float milliseconds) =>
			TimeSpan.FromMilliseconds(milliseconds);

		public static TimeSpan ToMilliseconds(this double milliseconds) =>
			TimeSpan.FromMilliseconds(milliseconds);

		public static TimeSpan ToTicks(this int ticks) =>
			TimeSpan.FromTicks(ticks);

		public static TimeSpan ToTicks(this float ticks) =>
			TimeSpan.FromTicks((long)ticks);

		public static TimeSpan ToTicks(this double ticks) =>
			TimeSpan.FromTicks((long)ticks);

		public static TimeSpan ToTimeSpan(this int timeSpan) =>
			TimeSpan.FromTicks(timeSpan);

		public static TimeSpan ToTimeSpan(this float timeSpan) =>
			TimeSpan.FromTicks((long)timeSpan);

		public static TimeSpan ToTimeSpan(this double timeSpan) =>
			TimeSpan.FromTicks((long)timeSpan);
	}
}
