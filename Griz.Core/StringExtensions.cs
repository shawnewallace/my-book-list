using System;
using System.Globalization;

namespace Griz.Core
{
	public static class StringExtensions
	{
		public static string Humanize(this string instance)
		{
			instance = instance.Replace("_", " ");

			return instance;
		}

		public static bool IsNumeric(this string instance)
		{
			double result;
			return Double.TryParse(instance, NumberStyles.Number, CultureInfo.CurrentCulture, out result);
		}

		public static string Left(this string instance, int length)
		{
			if (length > instance.Length) return instance;

			return length <= 0
				? instance
				: instance.Substring(0, length);
		}

		public static string Right(this string instance, int length)
		{
			return length <= 0
				? instance
				: instance.Substring(instance.Length - length, length);
		}

		public static bool ToBoolean(this char instance)
		{
			return instance == 'Y' || instance == 'y';
		}

		public static int ToInt32(this string instance)
		{
			return Convert.ToInt32(instance);
		}

		public static bool IsNullOrEmpty(this string instance)
		{
			return string.IsNullOrEmpty(instance);
		}

		public static bool IsNotNullOrEmpty(this string instance)
		{
			return !instance.IsNullOrEmpty();
		}

		public static string MakeHumanReadable(this string instance)
		{
			return instance.Capitalize().Humanize();
		}

		public static string Capitalize(this string instance)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(instance).Humanize();
		}
	}

}