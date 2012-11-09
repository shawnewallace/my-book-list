namespace Griz.Core
{
	public static class BooleanExtensions
	{
		public static string ToYesNo(this bool instance)
		{
			return instance ? "yes" : "no";
		}

		public static int ToInt(this bool instance)
		{
			return instance ? 1 : 0;
		}

		public static int ToInt(this bool? instance)
		{
			return instance.HasValue
				? instance.Value.ToInt()
				: 0;
		}
	}
}
