using System;

namespace Griz.Core
{
	public static partial class Extensions
	{
		public static int SecondsToMinutes(this int instance)
		{
			return instance / 60;
		}

		public static int MinutesToHours(this int instance)
		{
			return instance / 60;
		}

		public static int HoursToDays(this int instance)
		{
			return instance / 24;
		}

		public static bool WithinWorkingHours(this DateTime instance)
		{
			return instance.Hour >= 7 && instance.Hour < 18;
		}

		public static bool Between(this DateTime instance, DateTime left, DateTime right)
		{
			if (left > right)
			{
				var temp = right;
				right = left;
				left = temp;
			}

			return left <= instance && instance <= right;
		}
	}

	public static partial class Extensions
	{
		public static string ToDateTimeString(this DateTime instance)
		{
			return string.Format("{0} {1}", instance.ToShortDateString(), instance.ToShortTimeString());
		}

		public static string ToDateTimeString(this DateTime instance, bool adjustForLocalTime)
		{
			if (adjustForLocalTime) instance = instance.ToLocalTime();

			return instance.ToDateTimeString();
		}

		public static string ToDateTimeString(this DateTime? instance)
		{
			return !instance.HasValue
				? ""
				: instance.Value.ToDateTimeString();
		}

		public static string ToDateTimeString(this DateTime? instance, bool adjustForLocalTime)
		{
			return !instance.HasValue
				? ""
				: instance.Value.ToDateTimeString(adjustForLocalTime);
		}

		public static string ToBuildMonitorMinutes(this TimeSpan instance)
		{
			if (instance.IsNullOrEmpty()) return "";

			return instance.TotalMinutes.ToString("0.00");
		}
	}

	//public static partial class Extentions
	//{
	//	public static List<T> FindByName<T>(this IEnumerable<T> instance, string name) where T : IName
	//	{
	//		return instance.Where(i => i.Name.ToUpper() == name.ToUpper()).ToList();
	//	}

	//	public static List<T> FindByNamePart<T>(this IEnumerable<T> instance, string name) where T : IName
	//	{
	//		return instance.Where(i => i.Name.ToUpper().Contains(name.ToUpper())).ToList();
	//	}

	//	public static List<T> FindByName<T>(this IEnumerable<T> instance, IEnumerable<string> names) where T : IName
	//	{
	//		var result = new List<T>();

	//		foreach (var name in names)
	//		{
	//			result.AddRange(instance.FindByName(name));
	//		}

	//		return result.Distinct().ToList();
	//	}
	//}
}